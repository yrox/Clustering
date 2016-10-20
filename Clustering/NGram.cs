using System.Linq;
using System.Text;

namespace Clustering
{
    class NGram : IClusteringAlg
    {
        private string getNGrams(string str, byte nGramSize)
        {
            StringBuilder result = new StringBuilder();
            int currentIndex = 0;
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

        public string GetKey(string str)
        {
            str = str.ToLower();
            StringModifier sm = new StringModifier();
            str = sm.RemoveSeparators(str);
            str = getNGrams(str, 4);
            str = sm.AlphabetizeWords(str, "");
            return str;
        }

    }
}
