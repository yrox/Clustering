namespace Clustering
{
    public class KeyCollision : IClusteringAlg
    {
        public string GetKey(string str)
        {
            str = str.ToLower();
            StringModifier sm = new StringModifier();
            str = sm.RemoveSeparators(str);
            str = sm.AlphabetizeLetters(str);
            return str;
        }

    }
}
