using System.Collections;
using Clustering.Algorythms;
using Clustering.Interfaces;
using NUnit.Framework;

namespace Clustering.Test
{
    [TestFixture]
    public class CompressionTest
    {
        private IClusteringAlg _clustAlg = new Compression(1.2);

        [Test, TestCaseSource(nameof(PositiveTestCases))]
        public bool ShouldCompareStrings(string s1, string s2)
        {
            return _clustAlg.AreEqual(s1, s2);
        }


        public static IEnumerable PositiveTestCases
        {
            get
            {
                yield return new TestCaseData("lalala", "LALALA").Returns(false);
                yield return new TestCaseData("a- .aa", "aAa").Returns(false);
                yield return new TestCaseData("z", "qqq").Returns(false);
            }
        }

    }
}
