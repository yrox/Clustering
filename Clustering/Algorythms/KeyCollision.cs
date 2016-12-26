using System.Collections.Generic;
using Clustering.Interfaces;

namespace Clustering.Algorythms
{
    public class KeyCollision : IClusteringAlg
    {
        public IEnumerable<string> NormalizeStrings(IEnumerable<string> stringCol)
        {
            var result = new List<string>();
            foreach (var str in stringCol)
            {
                var temp = str.ToLower();
                StringModifier sm = new StringModifier();
                temp = sm.RemoveSeparators(temp);
                temp = sm.AlphabetizeLetters(temp);
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
