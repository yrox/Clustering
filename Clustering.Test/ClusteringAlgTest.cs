using Clustering.Algorythms;
using Clustering.Interfaces;
using Clustering.NinjectBindings;
using Clustering.IO;
using Ninject;
using NUnit.Framework;

namespace Clustering.Test
{
    [TestFixture]
    public class ClusteringAlgTest
    {
        private IClusteringAlg _alg;

        [SetUp]
        public void Initialize()
        {
            //var kernel = new StandardKernel(new ClusteringAlgBindings(new CmdOptions));
            //_alg = kernel.Get<IClusteringAlg>(options.Algorythm);
            _alg = new Compression(1);
        } 

        [Test, Sequential]
        public void ShouldCompareStrings(
            [Values ("lalala", "ddfsdf")] string s1,
            [Values ("lalala", "wewrqwqwewq")] string s2,
            [Values (true, false)] bool expected)
        {
            Assert.That(_alg.AreEqual(s1, s2).Equals(expected));
        }

    }
}
