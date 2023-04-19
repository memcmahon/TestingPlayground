using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuffinCrud.DataAccess;
using MuffinCrud.Models;

namespace MuffinCrud.Controllers
{
    public class MuffinController : Controller
    {
        private readonly MuffinDbContext _context;

        public MuffinController(MuffinDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var muffins = _context.Muffins.ToList();
            return View(muffins);
        }
    }
}
