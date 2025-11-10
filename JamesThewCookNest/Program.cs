using JamesThew.Data;
using JamesThew.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JamesThew.Services;


var builder = WebApplication.CreateBuilder(args);

// ✅ Ensure appsettings.json is read correctly
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// ✅ Dummy Email Sender — for testing (no real email sending)
builder.Services.AddScoped<IEmailSender, EmailSender>();


// ✅ Database connection (SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// ✅ Identity configuration — Custom ApplicationUser + Roles Support
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // ✅ testing easy
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders(); // ✅ For password reset / token generation

// ✅ Very important for Register/Login Razor Pages
builder.Services.AddRazorPages();


// ✅ Authorization service
builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ✅ Production error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ Required for identity login system
app.UseAuthentication();
app.UseAuthorization();

// ✅ This enables Identity pages like Register, Login, Logout, Manage
app.MapRazorPages();

// ✅ Default MVC Route

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//App run hote hi Admin + User roles create ho jayenge
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
Console.WriteLine("✅ Loaded Email: " + builder.Configuration["EmailSettings:SenderEmail"]);
Console.WriteLine("✅ Loaded Port: " + builder.Configuration["EmailSettings:Port"]);
;

app.Run();
