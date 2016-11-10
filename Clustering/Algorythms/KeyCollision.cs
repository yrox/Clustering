using Clustering.Interfaces;

namespace Clustering.Algorythms
{
    public class KeyCollision : IClusteringAlg
    {
        private string GetKey(string str)
        {
            str = str.ToLower();
            StringModifier sm = new StringModifier();
            str = sm.RemoveSeparators(str);
            str = sm.AlphabetizeLetters(str);
            return str;
        }

        public bool AreEqual(string str1, string str2)
        {
            return GetKey(str1) == GetKey(str2);
        }
    }
}
