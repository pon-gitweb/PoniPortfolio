#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoniPortfolio.Data;
using PoniPortfolio.Models;

namespace PoniPortfolio.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private readonly PoniPortfolioContext _context;

        public AdminController(PoniPortfolioContext context)
        {
            _context = context;
        }

        // GET: Admin/Messages
        public async Task<IActionResult> Messages(int page = 1)
        {
            int pageIndex = page;
            int pageSize = 10;

            IQueryable<Messages> messageIQ = from m in _context.Message select m;
            messageIQ = messageIQ.OrderByDescending(m => m.CreatedAt);

            PagedList<Messages> messages = await PagedList<Messages>.CreateAsync(messageIQ, pageIndex, pageSize);
            
            return View(messages);
        }


    }
}
