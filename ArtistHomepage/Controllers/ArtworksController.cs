// Copyright (c) Dominique Theodora Frost. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtistHomepage.Data;
using ArtistHomepage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArtistHomepage.Controllers
{
    /// <summary>
    /// A controller for uploading, editing and deleting Artworks.
    /// </summary>
    public class ArtworksController : Controller
    {
        /// <summary>
        /// The ApplicationDbContext.
        /// </summary>
        private readonly ApplicationDbContext context;

        private readonly UserManager<IdentityUser> userManager;

        private readonly IWebHostEnvironment he;

        private readonly ILogger<ArtworksController> logger;

        private readonly IArtworkDraft artworkDraft;

        public ArtworksController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IWebHostEnvironment he,
            IArtworkDraft artworkDraft,
            ILogger<ArtworksController> logger)
        {
            this.context = context;
            this.userManager = userManager;
            this.he = he;
            this.artworkDraft = artworkDraft;
            this.logger = logger;
        }

        /// <summary>
        /// Http Get Method for the Artwork Index view.
        /// </summary>
        /// <returns>The Artwork Index page.</returns>
        // GET: Artworks
        public async Task<IActionResult> Index()
        {
            if (this.User?.Identity?.Name == null)
            {
                return this.Unauthorized();
            }

            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var applicationDbContext = this.context.Artworks.Include(a => a.Artist).Where(a => a.Artist == currentUser);
            return this.View(await applicationDbContext.ToListAsync());
        }

        /// <summary>
        /// Http Get Method for the Artwork Details view.
        /// </summary>
        /// <param name="id">The Artwork id.</param>
        /// <returns>The Details view.</returns>
        // GET: Artworks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || this.context.Artworks == null)
            {
                return this.NotFound();
            }

            var artwork = await this.context.Artworks
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artwork == null)
            {
                return this.NotFound();
            }

            return this.View(artwork);
        }

        /// <summary>
        /// Http Get Method for the Artwork Create view.
        /// </summary>
        /// <returns>The artwork create view.</returns>
        // GET: Artworks/Create
        public async Task<IActionResult> Create()
        {
            if (this.User?.Identity?.Name == null)
            {
                return this.Unauthorized();
            }

            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            if (currentUser == null)
            {
                return this.Unauthorized();
            }

            this.ViewData["DateDisplayMode"] = new SelectList(
                Enum.GetValues(typeof(DateDisplayMode)).Cast<DateDisplayMode>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int)v).ToString(),
                }).ToList(),
                "Value",
                "Text");

            this.ViewData["ExistingImages"] = this.context.Images.Where(i => i.ArtistId == currentUser.Id).ToList();

            this.artworkDraft.ArtworkDraftContent = this.artworkDraft.GetArtworkDraftContent();
            if (this.artworkDraft.ArtworkDraftContent == null)
            {
                this.artworkDraft.ClearDraft();
            }

            return this.View(this.artworkDraft.ArtworkDraftContent);
        }

        /// <summary>
        /// Http Set Method for the Artwork Create view.
        /// </summary>
        /// <param name="model">The view model with data for the release date and eventually an image.</param>
        /// <returns>On success: The index View, on failure: the Artwork create view.</returns>
        // POST: Artworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmCreate(ArtworkDraftContent model)
        {
            var artwork = new Artwork();

            if (model.Day != null && model.Month == null)
            {
                this.ModelState.AddModelError(nameof(model.Month), "If a release day is set, setting the release month is necessary too.");
            }

            if (model.Day != null && model.Year == null)
            {
                this.ModelState.AddModelError(nameof(model.Year), "If a release day is set, setting the release year is necessary too.");
            }

            if (model.Month != null && model.Day == null)
            {
                this.ModelState.AddModelError(nameof(model.Year), "If a release month is set, setting the release year is necessary too.");
            }

            if (this.ModelState.IsValid)
            {
                // Maybe we already created the Artwork here...
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(model);
        }

        /// <summary>
        /// Http Post Method for the Image Upload.
        /// </summary>
        /// <param name="model">The Image Model.</param>
        /// <param name="newImage">The name of the uploaded image file.</param>
        /// <returns>Ok() or a partial view.</returns>
        // Create POST Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewImage(ArtworkDraftContent model, IFormFile newImage)
        {
            if (this.User?.Identity?.Name == null)
            {
                return this.Unauthorized();
            }

            var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            if (currentUser == null)
            {
                return this.Unauthorized();
            }

            if (newImage != null)
            {
                /* TODO: validate the image file. */

                // Safe the image file
                var imgName = Path.Combine(this.he.WebRootPath, "images", Path.GetFileName(newImage.FileName));

                using (var stream = new FileStream(imgName, FileMode.Create))
                {
                    await newImage.CopyToAsync(stream);
                }

                var currentImage = new Image();

                currentImage.Artist = currentUser;
                currentImage.ArtistId = currentUser.Id;
                currentImage.Name = "images/" + newImage.FileName;

                this.context.Images.Add(currentImage);

                await this.context.SaveChangesAsync();

                if (currentImage != null)
                {
                    this.artworkDraft.AddImageToDraft(currentImage);
                }

                currentImage = null;
            }

            return this.RedirectToAction(nameof(this.Create));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddExistingImage(ArtworkDraftContent model, string id)
        {
            this.context.SaveChanges();

            // Add the image if possible
            if (int.TryParse(id, out int id1))
            {
                if (this.User?.Identity?.Name == null)
                {
                    return this.Unauthorized();
                }

                var currentUser = await this.userManager.FindByNameAsync(this.User.Identity.Name);

                if (currentUser == null)
                {
                    return this.Unauthorized();
                }

                var existingImage = await this.context.Images.SingleOrDefaultAsync(i => i.Id == id1);

                if (existingImage != null && existingImage.ArtistId == currentUser.Id)
                {
                    this.artworkDraft.AddImageToDraft(existingImage);
                }
            }
            else
            {
                this.ModelState.AddModelError("Images", "Please select the existing item you want to pick.");
            }

            return this.RedirectToAction(nameof(this.Create));
        }

        /// <summary>
        /// Http Get Method for the Artwork Edit view.
        /// </summary>
        /// <param name="id">The artwork Id.</param>
        /// <returns>The Artwork Edit view.</returns>
        // GET: Artworks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || this.context.Artworks == null)
            {
                return this.NotFound();
            }

            var artwork = await this.context.Artworks.FindAsync(id);
            if (artwork == null)
            {
                return this.NotFound();
            }

            this.ViewData["ArtistId"] = new SelectList(this.context.Users, "Id", "Id", artwork.ArtistId);
            return this.View(artwork);
        }

        /// <summary>
        /// Http Set Method for the Artwork Edit view.
        /// </summary>
        /// <param name="id">The Artwork Id.</param>
        /// <param name="artwork">The Artwork Model.</param>
        /// <returns>On success: The Artwork Index View.</returns>
        // POST: Artworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DateDisplayMode,Id,ArtworkIndex,Title,Medium,Description,ReleaseDate,ForSale,ArtistId")] Artwork artwork)
        {
            if (id != artwork.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(artwork);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ArtworkExists(artwork.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["ArtistId"] = new SelectList(this.context.Users, "Id", "Id", artwork.ArtistId);
            return this.View(artwork);
        }

        /// <summary>
        /// Http Get Method for the Artwork Edit view.
        /// </summary>
        /// <param name="id">The artwork Id.</param>
        /// <returns>The Artwork Edit view.</returns>
        // GET: Artworks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || this.context.Artworks == null)
            {
                return this.NotFound();
            }

            var artwork = await this.context.Artworks
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artwork == null)
            {
                return this.NotFound();
            }

            return this.View(artwork);
        }

        /// <summary>
        /// Http Set Method for the Artwork Delete view.
        /// </summary>
        /// <param name="id">The artwork Id.</param>
        /// <returns>The Artwork Delete view.</returns>
        // POST: Artworks/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (this.context.Artworks == null)
            {
                return this.Problem("Entity set 'ApplicationDbContext.Artworks'  is null.");
            }

            var artwork = await this.context.Artworks.FindAsync(id);
            if (artwork != null)
            {
                this.context.Artworks.Remove(artwork);
            }

            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// A function to determien wether an Artwork exists.
        /// </summary>
        /// <param name="id">The artwork id.</param>
        /// <returns>A boolean value.</returns>
        private bool ArtworkExists(int id)
        {
            return (this.context.Artworks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
