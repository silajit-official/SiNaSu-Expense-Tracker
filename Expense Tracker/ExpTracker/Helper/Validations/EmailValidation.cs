using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ExpTracker.Helper.Validations
{
    public class EmailValidation:ValidationAttribute
    {
        IConfiguration _configuration;
        public EmailValidation()
        {
                   
        }
        public override bool IsValid(object value)
        {
            if(value != null)
            {
                string data = value.ToString();
                int errorID=0;
                if (!data.Contains("@"))
                {
                    errorID = 1;
                }
                else if (!data.EndsWith("stark.com"))
                {
                    errorID = 2;
                }

                if (errorID==0)
                {
                    return true;
                    //IDbConnection db = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=EXP_TRACKER;Trusted_Connection=True;");
                    //int retVal = db.ExecuteScalar<int>("CHECK_EMAIL", new { EMAIL = data }, commandType: CommandType.StoredProcedure);
                    //if(retVal==1)
                    //    return true;
                    //else
                    //{
                    //    ErrorMessage = "Customer with same Email already exist";
                    //    return false;
                    //}
                }
                else
                {
                    if(errorID==1)
                    {
                        ErrorMessage = "The Email must contains @ symbol";
                        return false;
                    }
                    else
                    {
                        ErrorMessage = "The Email must contains @stark.com";
                        return false;
                    }
                }


            }
            return false;
            
        }
    }
}
