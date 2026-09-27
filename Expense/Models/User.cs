using System.ComponentModel.DataAnnotations;

namespace Expense.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Transaction> Transactions { get; set; }
    public LinkedList<Category> Categories { get; set; }
    
}