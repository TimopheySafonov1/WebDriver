using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask
{
    public class LetterContentGenerator
    {
        public static string GeneratorRandomEmailContent(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&*()0123456789 ";
            StringBuilder contenBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                char randomChar = chars[random.Next(chars.Length)];
                contenBuilder.Append(randomChar);
            }
            return contenBuilder.ToString();
        }

    }
}
