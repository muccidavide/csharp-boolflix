using csharp_boolflix.Context;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace csharp_boolflix.Controllers
{
    public class EditorController : Controller
    {
        private BoolflixDbContext _db;

        public EditorController()
        {
            _db = new BoolflixDbContext();
        }
        public IActionResult Index() { 
            return View(); 
        }
        public IActionResult Film()
        {
            return View();
        }

        public IActionResult TVSerie()
        {
            return View();
        }

        public IActionResult Actor()
        {
            return View();
        }

        public IActionResult Genre()
        {
            return View();
        }

        
    }
}