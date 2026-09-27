using Expense.Database;
using Expense.Models;
using Expense.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense.Controllers;

public class TransactionController:Controller
{
    private readonly ApplicationDBContext _context;

    public TransactionController(ApplicationDBContext context)
    {
        _context = context;
    }

    public IActionResult AddTransaction()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddTransaction(TransactionViewModel model)
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId is { } id)
        {
            Console.WriteLine("User id is: "+id);
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == model.CategoryName);
            if (category == null)
            {
                category = new Category()
                {
                    Name = model.CategoryName,
                    UserId = id
                };
                _context.Categories.Add(category);
                
            }
            var transaction = new Transaction()
            {
                Amount = model.Amount,
                Name = model.Name,
                Category = category,
                Note = model.Note,
                Type = model.Type,
                UserId = id
            };
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }
        else
        {
            RedirectToAction("Login", "User");
        }

        

        return RedirectToAction("Index", "Home");
    }
}