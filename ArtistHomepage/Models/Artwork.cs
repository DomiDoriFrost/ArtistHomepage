using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace ArtistHomepage.Models
{
    public class Artwork : ArtistProperty
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Artwork index which allows to manually sort Artworks in the artist's library.
        /// </summary>
        public int ArtworkIndex { get; set; }

        /// <summary>
        /// Gets or sets the Title of the Artwork
        /// </summary>
        [Required]
        public required string Title { get; set; }

        /// <summary>
        /// Gets or sets the medium of the artwork, e.g. Water Color, Oil Paint, Woodcarving, Digital Painting, etc.
        /// </summary>
        public string? Medium { get; set; }

        public Group? Group { get; set; }

        public required string Description { get; set; }

        public int? Year { get; set; }

        public int? Month { get; set; }

        public int? Day { get; set; }

        public bool ForSale { get; set; }

        public string? KofiLink { get; set; }
    }
}
