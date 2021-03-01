using System.ComponentModel.DataAnnotations;

namespace DotNetCoreFive_MVC_Project.Utilities
{
    public class ValidateEmailAddress : ValidationAttribute
    {
        private readonly string _checkEmailAddress;

        public ValidateEmailAddress(string checkEmailAddress)
        {
            _checkEmailAddress = checkEmailAddress;
        }
        public override bool IsValid(object value)
        {
            string[] emailStrings = value.ToString().Split("@");
            return emailStrings[1].ToUpper() == _checkEmailAddress.ToUpper();
        }

    }
}
