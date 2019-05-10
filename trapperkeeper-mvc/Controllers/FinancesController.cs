using System;
using Microsoft.AspNetCore.Mvc;

namespace trapperkeeper_mvc.Controllers
{
    public class FinancesController : Controller
    {
        public FinancesController() { }

        public IActionResult Index() => View();
    }
}
