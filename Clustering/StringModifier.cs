using System;
using System.Linq;
using System.Text;

namespace Clustering
{
    public class StringModifier
    {
        public string RemovePunctuation(string str)
        {
            return str.Where(x => !char.IsPunctuation(x)).Aggregate(new StringBuilder(), (sb, s) => sb.Append(s)).ToString();
        }

        public string RemoveSeparators(string str)
        {
            return str.Where(char.IsLetterOrDigit).Aggregate(new StringBuilder(), (sb, s) => sb.Append(s)).ToString();
        }

        public string AlphabetizeWords(string str, string separator)
        {
            var arr = str.Split(null);
            Array.Sort(arr);
            return string.Join(separator, arr);
        }

        public string AlphabetizeLetters(string str)
        {
            return string.Concat(str.OrderBy(c => c));
        }

    }

}
