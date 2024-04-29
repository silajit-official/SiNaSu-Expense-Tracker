using System.ComponentModel.DataAnnotations;

namespace ExpTracker.Helper.Validations
{
    public class EmailValidation:ValidationAttribute
    {
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
