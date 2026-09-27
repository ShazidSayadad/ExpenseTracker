namespace Expense.Models;

public class Transaction
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string Type { get; set; }
    public string? Note { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}