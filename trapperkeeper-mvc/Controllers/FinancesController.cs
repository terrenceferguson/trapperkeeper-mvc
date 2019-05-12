using System;
using Microsoft.AspNetCore.Mvc;
using trapperkeeper_mvc.Models.Finances;

namespace trapperkeeper_mvc.Controllers
{
    public class FinancesController : Controller
    {
        public FinancesController() { }

        public IActionResult Index() => View();

        public IActionResult CreateNewLedger()
        {
            using (var context = new FinancesContext())
            {
                var ledger = new TransactionLedger
                {
                    ID = 1,
                    Date = DateTime.Now,
                    Description = "Here we go!"
                };

                context.TransactionLedgers.Add(ledger);

                context.SaveChanges();
            } 

            return Content($"Well, I think it worked.");
        }
    }
}
