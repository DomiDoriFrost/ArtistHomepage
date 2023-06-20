// Copyright (c) Dominique Theodora Frost. All rights reserved.

namespace ArtistHomepage.Models
{
    /// <summary>
    /// A group appears as one element in the main gallery.
    /// Hovering over a group in the main gallery will open a pop-up
    /// that displays a carousal with the images in the group and switches
    /// between them on autoplay.
    /// </summary>
    public class ArtworkGroup : UserProperty
    {
        /// <summary>
        /// Gets or sets the id of the Id of the ArtworkGroup.
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Gets or sets the List of Artworks associated with the Group.
        /// </summary>
        public virtual List<Artwork> Artworks { get; set; } = new ();

        /// <summary>
        /// Gets or sets the Artwork Title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Artwork Description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the tags assigned to this Artwork Group.
        /// </summary>
        public virtual List<Tags> Tags { get; set; } = new List<Tags>();
    }
}
