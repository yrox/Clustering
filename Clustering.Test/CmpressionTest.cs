using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clustering.Algorythms;
using NUnit.Framework;

namespace Clustering.Test
{
    [TestFixture]
    public class CmpressionTest
    {
        private Compression _compression;

        [OneTimeSetUp]
        public void Initialize()
        {
            _compression = new Compression();
        } 
        [Test]
        public void ShouldCompareStrings()
        {
            
        }

    }
}
