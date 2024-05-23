using ExpTracker.Models;
using System.Collections.Generic;

namespace ExpTracker.Repository
{
    public interface IExpTrackerRepository
    {
        string AddNewCustomer(Customer customer);
        Data.Customer Login(Customer customer);
        int AddExpenseCategory(ExpenseCategory expenseCategory);
        List<ExpenseCategory> ViewAllExpenseCategoryName();
        int DeleteCatgoryByID(int id);
        int AddCustomerExpense(CustomerExpense expense);
        int ViewCustomerExpense(ViewCustomerExpense expense);
    }
}