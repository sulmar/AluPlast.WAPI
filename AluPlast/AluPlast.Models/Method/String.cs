using System;
using System.Text;

namespace AluPlast.Models.Method
{
    public static class String
    {
        public static string ReplaceAt(this string input, int index, char newChar)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            var builder = new StringBuilder(input);
            builder[index] = newChar;
            return builder.ToString();
        }
        public static string RemoveLastChar(this string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return input.Substring(0, input.Length - 1);
        }
    }
}
