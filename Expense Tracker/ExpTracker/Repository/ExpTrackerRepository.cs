using ExpTracker.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using Dapper;

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
            Customer data = new Customer
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

        public string Login(Models.Customer customer)
        {
            var retVal = _context.Customer.Where(val => val.CustEmail.Equals(customer.CustEmail) && val.CustPassword.Equals(customer.CustPassword)).ToList();
            if (retVal.Count == 0)
                return null;
            else
                return retVal[0].CustFname;
        }
    }
}
