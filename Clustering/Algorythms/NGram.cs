using System.Linq;
using System.Text;
using Clustering.Interfaces;

namespace Clustering.Algorythms
{
    class NGram : IClusteringAlg
    {
        private string getNGrams(string str, byte nGramSize)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i <= str.Length - nGramSize; i++)
            {
                for (int j = 0; j < nGramSize; j++)
                {
                    result.Append(str.ElementAt(i + j));
                }
                result.Append(" ");
            }
            return result.ToString();
        }

        private string GetKey(string str)
        {
            str = str.ToLower();
            StringModifier sm = new StringModifier();
            str = sm.RemoveSeparators(str);
            str = getNGrams(str, 4);
            str = sm.AlphabetizeWords(str, "");
            return str;
        }

        public bool AreEqual(string str1, string str2)
        {
            return GetKey(str1) == GetKey(str2);
        }
    }
}
