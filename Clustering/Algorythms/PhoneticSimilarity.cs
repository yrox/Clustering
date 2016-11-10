using Clustering.Interfaces;
using Phonix;

namespace Clustering.Algorythms
{
    public class PhoneticSimilarity : IClusteringAlg
    {
        private string GetKey(string str)
        {
            StringModifier sm = new StringModifier();
            str = sm.RemovePunctuation(str);
            str = sm.AlphabetizeWords(str, " ");
            DoubleMetaphone dm = new DoubleMetaphone();
            str = dm.BuildKey(str);
            return str;
        }

        public bool AreEqual(string str1, string str2)
        {
            return GetKey(str1) == GetKey(str2);
        }
    }
}
