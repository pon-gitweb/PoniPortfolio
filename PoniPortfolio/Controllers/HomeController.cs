using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using PoniPortfolio.Data;
using PoniPortfolio.Models;

namespace PoniPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly PoniPortfolioContext _context;
        public HomeController(PoniPortfolioContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = new ListModel();
            model.SkillsModel = await _context.Skills.ToListAsync();
            model.MediaModel = await _context.Media.ToListAsync();
            model.ExperienceModel = await _context.Experience.ToListAsync();
            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}