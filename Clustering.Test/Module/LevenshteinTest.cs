using System.Collections;
using Clustering.Algorythms;
using Clustering.Interfaces;
using NUnit.Framework;

namespace Clustering.Test
{
    [TestFixture]
    public class LevenshteinTest
    {
        private IClusteringAlg _clustAlg = new Levenshtein(2);

        [Test, TestCaseSource(nameof(TestCases))]
        public bool ShouldCompareStrings(string s1, string s2)
        {
            return _clustAlg.AreEqual(s1, s2);
        }


        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("lalala", "lalal").Returns(true);
                yield return new TestCaseData("aaa", "a").Returns(true);
                yield return new TestCaseData("z", "qqq").Returns(false);
            }
        }

    }
}
