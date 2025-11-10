using JamesThew.Data;
using JamesThew.Models;
using JamesThewCookNest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace JamesThewCookNest.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // ✅ Agar user login nahi hua to bas normal homepage dikhao
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }

            // ✅ Current logged-in user fetch karo
            var user = await _userManager.GetUserAsync(User);

            // ✅ User ka subscription check karo
            var existingSub = _context.Subscriptions
                .FirstOrDefault(s => s.UserId == user.Id && s.EndDate > DateTime.Now);

            // ✅ Agar subscription nahi hai → plans page dikhao
            if (existingSub == null)
            {
                return RedirectToAction("Plans", "Subscription");
            }

            // ✅ Agar subscription active hai → normal homepage dikhao
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
