using Microsoft.AspNetCore.Mvc;
using trapperkeeper_mvc.Models;

namespace trapperkeeper_mvc.Controllers
{
    public abstract class BaseController : Controller
    {
        internal readonly DatabaseContext db;
        public BaseController() => db = new DatabaseContext();
        
        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
