// Copyright (c) Dominique Theodora Frost. All rights reserved.

using System.ComponentModel.DataAnnotations;

namespace ArtistHomepage.Models
{
    /// <summary>
    /// Represents a link on a user profile.
    /// </summary>
    public class CustomLink : UserProperty
    {
        /// <summary>
        /// Gets or sets the Id of the Custom Link.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Url of the Custom Link.
        /// </summary>
        [Url]
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the text that is displayed for the link.
        /// </summary>
        public string? Text { get; set; }
    }
}
