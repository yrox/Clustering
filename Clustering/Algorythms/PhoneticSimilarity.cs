using System.Collections.Generic;
using Clustering.Interfaces;
using Phonix;

namespace Clustering.Algorythms
{
    public class PhoneticSimilarity : IClusteringAlg
    {
        public IEnumerable<string> NormalizeStrings(IEnumerable<string> stringCol)
        {
            var result = new List<string>();
            foreach (var str in stringCol)
            {
                var temp = str.ToLower();
                StringModifier sm = new StringModifier();
                temp = sm.RemovePunctuation(temp);
                temp = sm.AlphabetizeWords(temp, "");
                DoubleMetaphone dm = new DoubleMetaphone();
                temp = dm.BuildKey(temp);
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
