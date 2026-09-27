using Expense.Database;
using Expense.Helpers;
using Expense.Models;
using Expense.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense.Controllers;

public class UserController:Controller
{
    private readonly ApplicationDBContext _context;

    public UserController(ApplicationDBContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.FirstOrDefault(x =>
                (x.Email == model.Email) && (x.Password == PasswordManager.Hash((model.Password))));
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId",user.Id);
                return RedirectToAction("Index","Home");
            }
        }
        return RedirectToAction("Login");
    }
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserViewModel model,string name)
    {
        if (ModelState.IsValid)
        {
            User user = new()
            {
                Name = name,
                Email = model.Email,
                Password = PasswordManager.Hash(model.Password)
            };
            var isPresent = await _context.Users.AnyAsync(x=>x.Email==model.Email);
            if(isPresent)
                return RedirectToAction("Login");
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login");
            
        }
        return RedirectToAction("Register");
    }
}