using Nohitatu_task.DTO.Input;
using System.Text.RegularExpressions;

namespace Nohitatu_task.Validator
{
    public class ApiValidation
    {
        public static string UserValidator(ApiUserReqDTO reqdto)
        {
            if (string.IsNullOrEmpty(reqdto.Name)) { return "Name Field Required"; }

            if (reqdto.PhoneNumber.Length != 10 || !reqdto.PhoneNumber.All(char.IsDigit))
            {
                return "Phone Number must be exactly 10 digits";
            }

            if (!IsValidEmail(reqdto.EmailID))
            {
                return "Enter Valid Email Address";
            }

            if (reqdto.Gender != "Male" && reqdto.Gender != "Female") { return "Enter Valid Gender (Male or Female)"; }

            return null;
        }

        public static bool IsValidEmail(string email)
        {

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

    }
}
