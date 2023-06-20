// Copyright (c) Dominique Theodora Frost. All rights reserved.

using System.Diagnostics;
using ArtistHomepage.Data;
using ArtistHomepage.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtistHomepage.Controllers
{
    /// <summary>
    /// Controller for the Index page.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The logger for this controller.
        /// </summary>
        private readonly ILogger<HomeController> logger;

        /// <summary>
        /// The ApplicationDbContext.
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger for this controller.</param>
        /// <param name="context">The ApplicationDbContext.</param>
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        /// <summary>
        /// Request the Index Page for this controller.
        /// </summary>
        /// <returns>The index page.</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Request the Privacy Page for this controller.
        /// </summary>
        /// <returns>The Privacy page.</returns>
        public IActionResult Privacy()
        {
            return this.View();
        }

        /// <summary>
        /// Request the Error Page for this controller.
        /// </summary>
        /// <returns>The Error page.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}