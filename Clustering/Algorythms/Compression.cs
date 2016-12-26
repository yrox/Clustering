using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using Clustering.Interfaces;

namespace Clustering.Algorythms
{
    public class Compression : IClusteringAlg
    {
        public Compression(double threshold)
        {
            _magicDouble = threshold;
        }
        private double _magicDouble;
        private int GetKey(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    msi.CopyTo(gs);
                }

                return mso.ToArray().Length;
            }
        }

        public IEnumerable<string> NormalizeStrings(IEnumerable<string> stringCol)
        {
            var result = new List<string>();
            foreach (var str in stringCol)
            {
                var temp = str.ToLower();
                StringModifier sm = new StringModifier();
                temp = sm.RemovePunctuation(temp);
                temp = sm.AlphabetizeWords(temp,"");

                result.Add(temp);
            }
            return result;
            
        }

        public bool AreEqual(string str1, string str2)
        {
            var s1 = str1 + str2;
            var s2 = str2 + str1;
            var s3 = str1 + str1;
            var s4 = str2 + str2;
            double c = (GetKey(s1) + GetKey(s2));
            double a = (GetKey(s3) + GetKey(s4));
            double distance = a / c;
            return distance >= _magicDouble;
        }
    }
}
