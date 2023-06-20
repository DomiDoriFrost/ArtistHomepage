using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtistHomepage.Models
{
    /// <summary>
    /// A group appears as one element in the main gallery.
    /// Hovering over a group in the main gallery will open a pop-up
    /// that displays a carousal with the images in the group and switches
    /// between them on autoplay.
    /// </summary>
    public class Group : ArtistProperty
    {
        public int Id { get; set; }

        public virtual List<Artwork> Artworks { get; set; } = new();

        public required string Title { get; set; }

        public string? Description { get; set; }
    }
}
