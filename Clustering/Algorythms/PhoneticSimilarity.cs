using System.Collections.Generic;
using System.Linq;
using Clustering.Interfaces;
using Phonix;

namespace Clustering.Algorythms
{
    public class PhoneticSimilarity : IClusteringAlg
    {
        public IEnumerable<string> NormalizeStrings(IEnumerable<string> stringCol)
        {
            stringCol = stringCol.ToList();
            var sm = new StringModifier();
            var dm = new DoubleMetaphone();
            return stringCol.Select(x => x.ToLower())
                .Select(x => sm.RemovePunctuation(x))
                .Select(x => sm.AlphabetizeWords(x, ""))
                .Select(x => dm.BuildKey(x)).ToList();
        }

        public bool AreEqual(string str1, string str2)
        {
           return str1 == str2;
        }
    }
}
