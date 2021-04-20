using System.Text.RegularExpressions;

namespace LayoutCompression
{
    public class PasswordAdvisor
    {
        public static PasswordScore CheckStrength(string password)
        {
            int score = 0;

            if (password.Length > 4)
                score++;

            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"^(?=.*\d).+$", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"^(?=.*[a-z]).+$", RegexOptions.ECMAScript).Success &&
                                Regex.Match(password, @"^(?=.*[A-Z]).+$", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"^(?=.*[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]).+$", RegexOptions.ECMAScript).Success)
                score++;

            return (PasswordScore)score;
        }
    }
}
