using System.Collections;
using Clustering.Algorythms;
using Clustering.Interfaces;
using NUnit.Framework;

namespace Clustering.Test
{
    [TestFixture]
    public class KeyCollisionTest
    {
        private IClusteringAlg _clustAlg = new KeyCollision();

        [Test, TestCaseSource(nameof(TestCases))]
        public bool ShouldCompareStrings(string s1, string s2)
        {
            return _clustAlg.AreEqual(s1, s2);
        }


        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("lalala", "LALALA").Returns(true);
                yield return new TestCaseData("a- .aa", "aAa").Returns(true);
                yield return new TestCaseData("z", "qqq").Returns(false);
            }
        }

    }
}
