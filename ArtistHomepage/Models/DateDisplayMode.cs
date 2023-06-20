// Copyright (c) Dominique Theodora Frost. All rights reserved.

namespace ArtistHomepage.Models
{
    /// <summary>
    /// An enum for different possible display modes for the Artwork release date.
    /// </summary>
    public enum DateDisplayMode
    {
        /// <summary>Do not display the date in which the Artwork was created.</summary>
        None = 0,

        /// <summary>Only display the year in which the Artwork was created.</summary>
        Year,

        /// <summary>Only display the year and month in which the Artwork was created.</summary>
        YearAndMonth,

        /// <summary>Display the date on which Artwork was created.</summary>
        YearMonthAndDay,
    }
}
