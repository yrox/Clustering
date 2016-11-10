using System.IO;
using System.IO.Compression;
using System.Text;
using Clustering.Interfaces;

namespace Clustering.Algorythms
{
    public class Compression : IClusteringAlg
    {
        private double _magicDouble = 1.5;
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
        public bool AreEqual(string str1, string str2)
        {
            var distance = (GetKey(str1 + str2) + GetKey(str2 + str1))/(GetKey(str1 + str1) + GetKey(str2 + str2));
            return distance <= _magicDouble;
        }
    }
}
