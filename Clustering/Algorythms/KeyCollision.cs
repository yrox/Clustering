using System.Collections.Generic;
using System.Linq;
using Clustering.Interfaces;

namespace Clustering.Algorythms
{
    public class KeyCollision : IClusteringAlg
    {
        public IEnumerable<string> NormalizeStrings(IEnumerable<string> stringCol)
        {
            stringCol = stringCol.ToList();
            var sm = new StringModifier();
            return stringCol.Select(x => x.ToLower()).Select(x => sm.RemoveSeparators(x)).Select(x => sm.AlphabetizeLetters(x)).ToList();
        }

        public bool AreEqual(string str1, string str2)
        {
            return str1 == str2;
        }
    }
}
