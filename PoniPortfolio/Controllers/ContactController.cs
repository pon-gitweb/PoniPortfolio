using Microsoft.AspNetCore.Mvc;
using PoniPortfolio.Data;
using PoniPortfolio.Models;

namespace PoniPortfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly PoniPortfolioContext _context;
        public ContactController(PoniPortfolioContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LeaveMessage(string fullName, string email, string message)
        {

            _context.Message.Add(new Messages()
            {
                FullName = fullName,
                Email = email,
                Body = message,
                CreatedAt = DateTime.Now
            }
           );
            try
            {
                _context.SaveChanges();
                ViewData["msg"] = $"A message from {fullName}, {email} has been sent successfully. <br /> Message Body: {message}";
            }
            catch (Exception ex)
            {

                ViewData["msg"] = $"Some thing went wrong.{ex.Message}";
            }


            return View();
        }
    }
}
