using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clustering.Interfaces;

namespace Clustering.Algorythms
{
    public class NGram : IClusteringAlg
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

        public IEnumerable<string> NormalizeStrings(IEnumerable<string> stringCol)
        {
            var result = new List<string>();
            foreach (var str in stringCol)
            {
                var temp = str.ToLower();
                StringModifier sm = new StringModifier();
                temp = sm.RemovePunctuation(temp);
                temp = getNGrams(temp);
                temp = sm.AlphabetizeWords(temp, "");
                result.Add(temp);
            }

            return result;
        }

        public bool AreEqual(string str1, string str2)
        {
            return str1 == str2;
        }
    }
}
