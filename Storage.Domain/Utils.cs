using System;

namespace Storage.Domain
{
    public class Utils
    {
        public static string GenerateRamdomCode(int length)
        {
            string code = string.Empty;
            if (length < 3) return code;
            for (int i = 0; i < length; i++)
            {
                Random random = new Random();
                int charCode = random.Next(1, 11) > 5 ? random.Next(48, 58) : random.Next(65, 91);
                char c = (char) charCode;
                code += c;
            }

            return code;
        }
    }
}