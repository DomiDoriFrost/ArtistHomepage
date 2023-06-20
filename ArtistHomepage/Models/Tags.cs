// Copyright (c) Dominique Theodora Frost. All rights reserved.

using System.ComponentModel.DataAnnotations;

namespace ArtistHomepage.Models
{
    /// <summary>
    /// A predefined search term to organize items in the gallery.
    /// </summary>
    public class Tags
    {
        /// <summary>
        /// Gets or sets the Id of the tag.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Key of the tag.
        /// </summary>
        [RegularExpression("^[a-z_]+$")]
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Images tagged with this tag.
        /// </summary>
        public virtual List<Image> Images { get; set; } = new List<Image>();

        /// <summary>
        /// Gets or sets the Artowrks tagged with this tag.
        /// </summary>
        public virtual List<Artwork> Artworks { get; set; } = new List<Artwork>();

        /// <summary>
        /// Gets or sets the ArtworkGroups tagged with this tag.
        /// </summary>
        public virtual List<ArtworkGroup> ArtworkGroups { get; set; } = new List<ArtworkGroup>();
    }
}
