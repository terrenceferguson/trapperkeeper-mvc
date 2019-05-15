using System;
using Microsoft.AspNetCore.Mvc;
using trapperkeeper_mvc.Models;
using trapperkeeper_mvc.Models.Finances;

namespace trapperkeeper_mvc.Controllers
{
    public class FinancesController : Controller
    {
        public FinancesController() { }

        public IActionResult Index() => View();

        public IActionResult CreateNewLedger()
        {
            using (var context = new DatabaseContext())
            {
                var ledger = new TransactionLedger
                {
                    Date = DateTime.Now,
                    Description = $"{Guid.NewGuid()}"
                };

                context.TransactionLedger.Add(ledger);

                context.SaveChanges();
            }

            return RedirectToAction(nameof(FinancesController.Index));
        }
    }
}
