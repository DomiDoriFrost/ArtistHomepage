// Copyright (c) Dominique Theodora Frost. All rights reserved.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ArtistHomepage.Models
{
    /// <summary>
    /// Represents an object that is owned by an artist,
    /// for example an image.
    /// </summary>
    public abstract class UserProperty
    {
        /// <summary>
        /// Gets or sets the Id of the User who owns the artwork.
        /// </summary>
        [Required]
        public string ArtistId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Artist who owns the object.
        /// </summary>
        [ForeignKey(nameof(ArtistId))]
        public IdentityUser? Artist { get; set; }
    }
}
