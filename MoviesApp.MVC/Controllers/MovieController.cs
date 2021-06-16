using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesApp.Entities;
using MoviesApp.Entities.Dtos;
using MoviesApp.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoviesApp.MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly string baseApiUrl = "https://localhost:5001/api/Movies";

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var movies = new List<Movie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(baseApiUrl + "/GetAll"))
                {
                    string res = await response.Content.ReadAsStringAsync();
                    movies = JsonConvert.DeserializeObject<List<Movie>>(res);
                    //will throw an exception if not successful
                    response.EnsureSuccessStatusCode();
                }

            }
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_MovieAddModalPartial");
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieAddDto movieAddDto)
        {
            //if (ModelState.IsValid)
            //{
                var contentToSend = JsonConvert.SerializeObject(movieAddDto);
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync(baseApiUrl + "/Post", new StringContent(contentToSend)))
                    {
                        response.EnsureSuccessStatusCode();

                        string content = await response.Content.ReadAsStringAsync();
                        return PartialView("_MovieAddModalPartial");
                    }
                }
            //}
            //return Json(movieAddDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
