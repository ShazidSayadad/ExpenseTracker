namespace Expense.ViewModels;

public class TransactionViewModel
{
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public string CategoryName { get; set; }
    public string Note { get; set; }
}