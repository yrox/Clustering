using System;
using Clustering.Interfaces;

namespace Clustering.Algorythms
{
    public class Levenshtein : IClusteringAlg
    {
        public Levenshtein(int threshold)
        {
            _magicInt = threshold;
        }

        private int _magicInt;
        private int GetLevenshteinDistance(string s1, string s2)
        {
            if (s1.Length == 0)
                return s2.Length;
            if (s2.Length == 0)
                return s1.Length;
            if (Math.Abs(s1.Length - s2.Length) > _magicInt)
                return Math.Abs(s1.Length - s2.Length);

            var distTable = new int[s1.Length + 1, s2.Length + 1];

            for (var i = 0; i <= s1.Length; i++)
            {
                distTable[i, 0] = i;
            }
            for (var j = 0; j <= s2.Length; j++)
            {
                distTable[0, j] = j;
            }

            for (var i = 1; i <= s1.Length; i++)
            {
                for (var j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        distTable[i, j] = distTable[i - 1, j - 1];
                        continue;
                    }

                    distTable[i, j] = Math.Min(Math.Min(distTable[i - 1, j], distTable[i, j - 1]), distTable[i - 1, j - 1]) + 1;
                }
            }
            return distTable[s1.Length, s2.Length]; 
        }

        private int GetKey(string s1, string s2)
        {
            StringModifier sm = new StringModifier();
            s1 = s1.ToLower();            
            s1 = sm.RemovePunctuation(s1);
            s1 = sm.AlphabetizeWords(s1, " ");
            s2 = s2.ToLower();
            s2 = sm.RemovePunctuation(s2);
            s2 = sm.AlphabetizeWords(s2, " ");
            return GetLevenshteinDistance(s1, s2);
        }

        public bool AreEqual(string str1, string str2)
        {
            return GetKey(str1,str2) <= _magicInt;
        }
    }
}
