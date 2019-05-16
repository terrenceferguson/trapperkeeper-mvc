using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trapperkeeper_mvc.Models;
using trapperkeeper_mvc.Models.Finances;

namespace trapperkeeper_mvc.Controllers
{
    public class FinancesController : BaseController
    {
        public FinancesController() { }

        public IActionResult Index()
            => View(db.TransactionLedger.ToList());

        public IActionResult CreateNewLedger()
        {
            var ledger = new TransactionLedger
            {
                Date = DateTime.Now,
                Description = $"{Guid.NewGuid()}"
            };

            db.TransactionLedger.Add(ledger);
            db.SaveChanges();

            return RedirectToAction(nameof(FinancesController.Index));
        }
    }
}
