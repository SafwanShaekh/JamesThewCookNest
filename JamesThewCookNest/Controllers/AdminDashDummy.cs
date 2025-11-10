using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")] // ✅ Only Admin can access
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return Content("✅ admin Dashboard - James bhai kam karega maloom");
    }
}
