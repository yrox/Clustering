using System.Linq;
using System.Text;
using Clustering.Interfaces;

namespace Clustering.Algorythms
{
    class NGram : IClusteringAlg
    {
        public NGram(int threshold)
        {
            _nGramSize = threshold;
        }
        private int _nGramSize; 
        private string getNGrams(string str)
        {
            StringBuilder result = new StringBuilder();
            
            for (int i = 0; i <= str.Length - _nGramSize; i++)
            {
                //result.Append(string.Concat(str.Substring(i, nGramSize).OrderBy(x => x)));
                result.Append((str.Substring(i, _nGramSize)));
            }
            return result.ToString();
        }

        private string GetKey(string str)
        {
            str = str.ToLower();
            StringModifier sm = new StringModifier();
            str = sm.RemovePunctuation(str);
            str = getNGrams(str);
            str = sm.AlphabetizeWords(str, "");
            return str;
        }

        public bool AreEqual(string str1, string str2)
        {
            return GetKey(str1) == GetKey(str2);
        }
    }
}
