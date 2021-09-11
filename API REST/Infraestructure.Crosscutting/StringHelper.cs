using System;

namespace Infraestructure.Crosscutting
{
    public static class StringHelper
    {
        public static string ToPascalCase(string text)
        {
            if (text == null) return text;
            if (text.Length < 2) return text.ToUpper();

            // Split the string into words.
            string[] words = text.Split(
                new char[] { },
                StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            string result = "";
            foreach (string word in words)
            {
                result +=
                    word.Substring(0, 1).ToUpper() +
                    word.Substring(1);
            }

            return result;
        }
    }
}