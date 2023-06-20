// Copyright (c) Dominique Theodora Frost. All rights reserved.

namespace ArtistHomepage.Models
{
    /// <summary>
    /// Represents a user image that may appear in multiple places on the website.
    /// </summary>
    public class Image : UserProperty
    {
        /// <summary>
        /// Gets or sets the Image id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Image name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Image alt text.
        /// </summary>
        public string AltText { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the copyright information of the image.
        /// </summary>
        public string? Copyright { get; set; }

        /// <summary>
        /// Gets or sets the tags assigned to this image.
        /// </summary>
        public virtual List<Tags> Tags { get; set; } = new List<Tags>();
    }
}
