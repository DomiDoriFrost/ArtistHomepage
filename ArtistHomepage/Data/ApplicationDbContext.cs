using ArtistHomepage.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtistHomepage.Data
{
    /// <summary>
    /// Handles the Application Data storage and persistence.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The DbContextOptions.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Artworks in the Context.
        /// </summary>
        public DbSet<Artwork> Artworks { get; set; }

        /// <summary>
        /// Gets or sets the Images in the Context.
        /// </summary>
        public DbSet<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the Tags in the Context.
        /// </summary>
        public DbSet<Tags> Tags { get; set; }

        /// <summary>
        /// Gets or sets the CustomLinks in the Context.
        /// </summary>
        public DbSet<CustomLink> CustomLinks { get; set; }

        /// <summary>
        /// Gets or sets the ArtworkGroups in the Context.
        /// </summary>
        public DbSet<ArtworkGroup> ArtworkGroups { get; set; }
    }
}