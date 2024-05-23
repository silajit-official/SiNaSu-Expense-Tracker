using ExpTracker.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using Dapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using ExpTracker.Models;

namespace ExpTracker.Repository
{
    public class ExpTrackerRepository : IExpTrackerRepository
    {
        private readonly EXP_TRACKERContext _context;
        public ExpTrackerRepository()
        {
            _context = new EXP_TRACKERContext();
        }
        public string AddNewCustomer(Models.Customer customer)
        {
            Data.Customer data = new Data.Customer
            {
                CustFname = customer.CustFname,
                CustLname = customer.CustLname,
                CustEmail = customer.CustEmail,
                CustPassword = customer.CustPassword,
                CustImageUrl = customer.CustImageUrl,
            };
            IDbConnection db = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=EXP_TRACKER;Trusted_Connection=True;");
            int retVal = db.ExecuteScalar<int>("CHECK_EMAIL", new { EMAIL = data.CustEmail }, commandType: CommandType.StoredProcedure);
            if(retVal == 0)
            {
                return "-1";
            }
            _context.Customer.Add(data);
            _context.SaveChanges();
            return data.CustFname;
        }

        public Data.Customer Login(Models.Customer customer)
        {
            var retVal = _context.Customer.Where(val => val.CustEmail.Equals(customer.CustEmail) && val.CustPassword.Equals(customer.CustPassword)).ToList();
            if (retVal.Count == 0)
                return null;
            else
            {
                
                return retVal[0];
            }
        }

        public int AddExpenseCategory(Models.ExpenseCategory expenseCategory)
        {
            SqlConnection db = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=EXP_TRACKER;Trusted_Connection=True;");
            int retVal = db.ExecuteScalar<int>("ADD_CATEGORY", new { CATEGORY_NAME =expenseCategory.EcExpenseName},commandType:CommandType.StoredProcedure);
            return retVal;
        }

        public List<Models.ExpenseCategory> ViewAllExpenseCategoryName()
        {
            SqlConnection db = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=EXP_TRACKER;Trusted_Connection=True;");
            List<Models.ExpenseCategory> expenseCategories= db.Query<Models.ExpenseCategory>("VIEW_ALL_EXPENSE_CATEGORY_NAME",commandType:CommandType.StoredProcedure).ToList();
            return expenseCategories;
        }

        public int DeleteCatgoryByID(int id)
        {
            SqlConnection db = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=EXP_TRACKER;Trusted_Connection=True;");
            int retVal = db.ExecuteScalar<int>("DELETE_CATEGORY_BY_ID", new {id=id},commandType:CommandType.StoredProcedure);
            return retVal;
        }

        public int AddCustomerExpense(Models.CustomerExpense customerExpense)
        {
            SqlConnection db = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=EXP_TRACKER;Trusted_Connection=True;");
            int retVal = db.ExecuteScalar<int>("ADD_CUSTOMER_EXPENSE", new { CE_CUST_ID=customerExpense.CE_CUST_ID, CE_EC_ID=customerExpense.CE_EC_ID, CE_ADDED_ON=customerExpense.CE_ADDED_ON,AMOUNT=customerExpense.AMOUNT }, commandType: CommandType.StoredProcedure);
            return retVal;
        }

        public int ViewCustomerExpense(ViewCustomerExpense customerExpense)
        {
            SqlConnection db = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=EXP_TRACKER;Trusted_Connection=True;");
            int retVal = db.ExecuteScalar<int>("VIEW_CUSTOMER_EXPENSE", new { START_DATE = customerExpense.START_DATE, END_DATE = customerExpense.END_DATE,CUST_ID=customerExpense.CUST_ID, EC_ID = customerExpense.EC_ID,}, commandType: CommandType.StoredProcedure);
            return retVal;
        }
    }
}
