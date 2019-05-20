using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trapperkeeper_mvc.Models;

namespace trapperkeeper_mvc.Controllers
{
    public class FinancesController : Controller
    {
        private readonly FinancesContext _context;
        
        public FinancesController(FinancesContext context) 
            => _context = context;

        public IActionResult Index()
            => View(_context.TransactionLedger.ToList());

        public IActionResult CreateNewLedger()
        {
            
            var ledger = new TransactionLedger
            {
                Date = DateTime.Now,
                Description = $"{Guid.NewGuid()}"
            };

            _context.TransactionLedger.Add(ledger);
            _context.SaveChanges();

            return RedirectToAction(nameof(FinancesController.Index));
        }
    }
}
