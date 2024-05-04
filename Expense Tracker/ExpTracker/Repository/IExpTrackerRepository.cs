using ExpTracker.Models;
using System.Collections.Generic;

namespace ExpTracker.Repository
{
    public interface IExpTrackerRepository
    {
        string AddNewCustomer(Customer customer);
        string Login(Customer customer);
        int AddExpenseCategory(ExpenseCategory expenseCategory);
        List<ExpenseCategory> ViewAllExpenseCategoryName();
        int DeleteCatgoryByID(int id);
    }
}