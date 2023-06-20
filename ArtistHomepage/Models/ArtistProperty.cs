using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtistHomepage.Models
{
    public abstract class ArtistProperty
    {
        [Required]
        public string ArtistId { get; set; }

        [ForeignKey(nameof(ArtistId))]
        public virtual IdentityUser? Artist { get; set; }
    }
}
