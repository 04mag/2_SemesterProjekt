namespace Anden_SemesterProjekt.Server.Validation
{
    public class SLValidator
    {
        public static bool StringLenght(string input, int min, int max)
        {
            if (input.Length >= min && input.Length <= max)
            {
                return true;
            }
            return false;
        }

        public static bool EmailIsValid(string input)
        {
            string pattern = @"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b";

            if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
            {
                return true;
            }
            return false;
        }

        public static bool PhoneNumberIsValid(string input)
        {
            string pattern = @"([2-9])\d{7}";

            if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
            {
                return true;
            }
            return false;
        }

    }
}
