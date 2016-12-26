using System.Collections.Generic;

namespace Clustering.Interfaces
{
    public interface IClusteringAlg
    {
        IEnumerable<string> NormalizeStrings(IEnumerable<string> stringCol);
        bool AreEqual(string str1, string str2);

    }
}
