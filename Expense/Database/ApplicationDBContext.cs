using System.Data;
using Expense.Models;
using Microsoft.EntityFrameworkCore;

namespace Expense.Database;

public class ApplicationDBContext:DbContext
{
    public ApplicationDBContext(DbContextOptions options):base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }
}