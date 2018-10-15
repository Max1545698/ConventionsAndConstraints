using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConventionsAndConstraints.Infrastructure;
using ConventionsAndConstraints.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConventionsAndConstraints.Controllers
{
    //[AdditionalActions]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Result", new Result()
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            });
        }

        [ActionName("Index")]
        [UserAgent("Edge")]
        public IActionResult Other()
        {
            return View("Result", new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Other)
            });
        }

        //[ActionName("Details")]
        //[ActionNamePrefix("Do")]
        //[AddAction("Details")]
        [UserAgent("Edge")]
        public IActionResult List()
        {
            return View("Result", new Result()
            {
                Controller = nameof(HomeController),
                Action = nameof(List)
            });
        }
    }
}