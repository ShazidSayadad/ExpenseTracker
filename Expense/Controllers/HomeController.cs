using System.Diagnostics;
using Expense.Database;
using Microsoft.AspNetCore.Mvc;
using Expense.Models;
using Microsoft.EntityFrameworkCore;

namespace Expense.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDBContext _context;

    public HomeController(ApplicationDBContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Index()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
            return RedirectToAction("Login", "User");
        var user = await _context.Users.FindAsync(userId);
        
        await _context.Users
            .Include(u => u.Transactions)
            .ThenInclude(t => t.Category)
            .FirstOrDefaultAsync(u => u.Id == userId);
        if(user==null)
            return RedirectToAction("Login", "User");
        return View(user.Transactions);
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