using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trapperkeeper_mvc.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace trapperkeeper_mvc.Controllers
{
    public class LibraryController : Controller
    {
        private readonly LibraryContext _context;

        public LibraryController(LibraryContext context)
            => _context = context;

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
