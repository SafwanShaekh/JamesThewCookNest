using JamesThew.Data;
using JamesThew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize] // ✅ Only logged-in users can subscribe
public class SubscriptionController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public SubscriptionController(ApplicationDbContext context,
                                  UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // ✅ Show Plans Page
    public async Task<IActionResult> Plans()
    {
        var user = await _userManager.GetUserAsync(User);

        // ✅ Check if already subscribed and active
        var subscription = await _context.Subscriptions
            .FirstOrDefaultAsync(s => s.UserId == user.Id && s.EndDate > DateTime.Now);

        bool alreadySubscribed = subscription != null;

        return View(alreadySubscribed);
    }

    // ✅ Handle Subscribe button
    [HttpPost]
    public async Task<IActionResult> Subscribe(string planName, string cardNumber)
    {
        var user = await _userManager.GetUserAsync(User);

        // ✅ Prices & duration
        decimal price = planName == "Annual" ? 100 : 10;
        int days = planName == "Annual" ? 365 : 30;

        var subscription = new Subscription
        {
            UserId = user.Id,
            PlanName = planName,
            Price = price,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(days)
        };

        _context.Subscriptions.Add(subscription);
        await _context.SaveChangesAsync();

        TempData["Success"] = $"🎉 You successfully subscribed to the {planName} plan!";
        return RedirectToAction("Details");
    }

    // ✅ Show subscription details in navbar page
    public async Task<IActionResult> Details()
    {
        var user = await _userManager.GetUserAsync(User);

        var subscription = await _context.Subscriptions
            .Where(s => s.UserId == user.Id)
            .OrderByDescending(s => s.EndDate)
            .FirstOrDefaultAsync();

        return View(subscription);
    }
}
