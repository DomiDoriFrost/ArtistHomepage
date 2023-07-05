// Copyright (c) Dominique Theodora Frost. All rights reserved.

using Microsoft.AspNetCore.Identity;

namespace ArtistHomepage.Models
{
    public class ArtworkDraftContent
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Medium { get; set; }

        public bool ForSale { get; set; }

        public string? Tags { get; set; }

        public IdentityUser Artist { get; set; }

        public string ArtistId { get; set; }

        public int? Year { get; set; } = DateTimeOffset.UtcNow.Year;

        public int? Month { get; set; } = DateTimeOffset.UtcNow.Month;

        public int? Day { get; set; } = DateTimeOffset.UtcNow.Day;

        public List<Image> Images { get; set; } = new ();

        // Temporary storage for newly uploaded images.
        public string? NewImage;

        public string? NewImageAltText;

        public string? NewImageTags { get; set; }
        public string? ArtworkDraftId { get; internal set; }
    }
}
