using ArtistHomepage.Data;
using ArtistHomepage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArtistHomepage.Controllers
{
    public class ImageUploadComponent : ViewComponent
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment he;
        private readonly ILogger<ImageUploadComponent> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageUploadComponent"/> class.
        /// </summary>
        /// <param name="context">The ApplicationDbContext.</param>
        /// <param name="userManager">The UserManager.</param>
        /// <param name="he">The Webhost Environment.</param>
        /// <param name="logger">The Logger.</param>
        public ImageUploadComponent(
            UserManager<IdentityUser> userManager,
            ApplicationDbContext context,
            IWebHostEnvironment he,
            ILogger<ImageUploadComponent> logger)
        {
            this.context = context;
            this.he = he;
            this.logger = logger;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(ArtworkDraftContent model)
        {
            if (model == null)
            {
                return View("Error: View model not initialized");
            }

            return View(model);
        }
    }
}
