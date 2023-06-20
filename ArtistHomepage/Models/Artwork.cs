// Copyright (c) Dominique Theodora Frost. All rights reserved.

using System.ComponentModel.DataAnnotations;

namespace ArtistHomepage.Models
{
    /// <summary>
    /// Represents and Artwork and it's meta-data.
    /// </summary>
    public partial class Artwork : UserProperty
    {
        /// <summary>
        /// Gets or sets the DateDisplayMode.
        /// </summary>
        public DateDisplayMode DateDisplayMode { get; set; } = DateDisplayMode.Year;

        /// <summary>
        /// Gets or sets the Id of the Artwork.
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Artwork index which allows to manually sort Artworks in the artist's library.
        /// </summary>
        public int ArtworkIndex { get; set; } = -1;

        /// <summary>
        /// Gets or sets the Title of the Artwork.
        /// </summary>
        [Required]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the medium of the artwork, e.g. Water Color, Oil Paint, Woodcarving, Digital Painting, etc.
        /// </summary>
        public string? Medium { get; set; }

        /// <summary>
        /// Gets or sets the Groups that contain this Artwork.
        /// </summary>
        public virtual List<ArtworkGroup> Groups { get; set; } = new ();

        /// <summary>
        /// Gets or sets the Images that are part of the Artwork.
        /// </summary>
        public virtual List<Image> Images { get; set; } = new ();

        /// <summary>
        /// Gets or sets the Description of the Artwork.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the year in which the Artwork was created.
        /// </summary>
        public DateTimeOffset? ReleaseDate { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// Gets or sets a value indicating whether
        /// this artwork is for sale.
        /// </summary>
        public bool ForSale { get; set; }

        /// <summary>
        /// Gets or sets the tags assigned to this Artwork.
        /// </summary>
        public virtual List<Tags> Tags { get; set; } = new List<Tags>();
    }
}
