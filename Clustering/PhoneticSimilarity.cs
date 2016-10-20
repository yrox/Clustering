using Phonix;

namespace Clustering
{
    public class PhoneticSimilarity : IClusteringAlg
    {
        public string GetKey(string str)
        {
            str = str.ToLower();
            StringModifier sm = new StringModifier();
            str = sm.RemovePunctuation(str);
            str = sm.AlphabetizeWords(str, " ");
            DoubleMetaphone dm = new DoubleMetaphone();
            str = dm.BuildKey(str);
            return str;
        }

    }
}
