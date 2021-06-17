using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesApp.Entities;
using MoviesApp.Entities.Dtos;
using MoviesApp.MVC.Models;
using MoviesApp.WebAPI.Helpers.Extentions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.MVC.Controllers
{
    public class MovieController : Controller
    {

        private readonly string baseApiUrl = "https://localhost:5001/api/Movies";

        [HttpGet]
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
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = new Movie();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{baseApiUrl}/GetMovieById/{id}"))
                {
                    string res = await response.Content.ReadAsStringAsync();
                    movie = JsonConvert.DeserializeObject<Movie>(res);
                    //will throw an exception if not successful
                    response.EnsureSuccessStatusCode();
                }

            }
            return PartialView("_MovieUpdateModalPartial", movie);

        }


        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_MovieAddModalPartial");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {

            //var movieAddAjaxModel = new MovieAddAjaxModel
            //{
            //    MovieAddPartial = await this.RenderViewToStringAsync("_MovieAddModalPartial", movieAddDto),
            //    MovieAddDto= movieAddDto,
            //};

            if (ModelState.IsValid)
            {
                var contentToSend = JsonConvert.SerializeObject(movie);
                Console.WriteLine(contentToSend);
                using (var httpClient = new HttpClient())
                {
                    var jsonData = JsonConvert.SerializeObject(movie);
                    var dataToSend = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(baseApiUrl + "/Post", dataToSend))
                    {
                        response.EnsureSuccessStatusCode();
                        Console.WriteLine(response.StatusCode);
                        return PartialView("_MovieAddModalPartial", movie);
                    }
                }
            }
            return PartialView("_MovieAddModalPartial", movie);
        }



        [HttpPut]
        public async Task<IActionResult> Update(Movie movieToUpdate)
        {

            //var movieAddAjaxModel = new MovieAddAjaxModel
            //{
            //    MovieAddPartial = await this.RenderViewToStringAsync("_MovieAddModalPartial", movieAddDto),
            //    MovieAddDto= movieAddDto,
            //};

            if (ModelState.IsValid)
            {
                var contentToSend = JsonConvert.SerializeObject(movieToUpdate);
                Console.WriteLine(contentToSend);
                using (var httpClient = new HttpClient())
                {
                    var jsonData = JsonConvert.SerializeObject(movieToUpdate);
                    var dataToSend = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync(baseApiUrl + "/Put", dataToSend))
                    {
                        response.EnsureSuccessStatusCode();
                        Console.WriteLine(response.StatusCode);
                        return PartialView("_MovieAddModalPartial", movieToUpdate);
                    }
                }
            }
            return PartialView("_MovieUpdateModalPartial", movieToUpdate);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int movieToDeleteId)
        {
            if (ModelState.IsValid)
            {
                
                Console.WriteLine(movieToDeleteId);
                using (var httpClient = new HttpClient())
                {
                    //var jsonData = JsonConvert.SerializeObject(movieToDeleteId);
                    //var dataToSend = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.DeleteAsync($"{baseApiUrl}/Delete/{movieToDeleteId}"))
                    {
                        var urll = $"{baseApiUrl}/Delete/{movieToDeleteId}";
                        response.EnsureSuccessStatusCode();
                        Console.WriteLine(response.StatusCode);
                        return Ok();
                    }
                }
            }
            return Error();
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
