using System;
using System.Linq;
using System.Text;

namespace Clustering
{
    public class StringModifier
    {
        public string RemovePunctuation(string str)
        {
            StringBuilder result = new StringBuilder();
            foreach (var ch in str)
            {
                if (char.IsLetterOrDigit(ch))
                {
                    result.Append(ch);
                }
            }
            return result.ToString();
        }

        public string RemoveSeparators(string str)
        {
            StringBuilder result = new StringBuilder();
            foreach (var ch in str)
            {
                if (char.IsLetterOrDigit(ch))
                {
                    result.Append(ch);
                }
            }
            return result.ToString();
        }

        public string AlphabetizeWords(string str, string separator)
        {
            var arr = str.Split(null);
            Array.Sort(arr);
            return String.Join(separator, arr);
        }

        public string AlphabetizeLetters(string str)
        {
            return String.Concat(str.OrderBy(c => c));
        }

    }

}
