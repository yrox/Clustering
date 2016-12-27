using System;
using System.Collections;
using System.Collections.Generic;
using Clustering.Interfaces;
using Clustering.IO;
using Moq;
using NUnit.Framework;

namespace Clustering.Test
{
    [TestFixture]
    public class ClusteringTest
    {
        private Mock<IClusteringAlg> _trueMock;
        private Mock<IClusteringAlg> _falseMock;
        private TableReader _tr;
        private Table _table;
        private Clustering _clustering;

        [SetUp]
        public void Initialize()
        {
            _trueMock = new Mock<IClusteringAlg>();
            _trueMock.Setup(x => x.AreEqual(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            _falseMock = new Mock<IClusteringAlg>();
            _falseMock.Setup(x => x.AreEqual(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            _tr = new TableReader();
            _table = new Table(_tr.Read("Contracts.csv"));
            _clustering = new Clustering(_table);

        }

        [Test]
        public void ShouldCreateTables()
        {
            Assert.Throws<ArgumentException>(() => _clustering.GetClusters(_falseMock.Object, "Investment Title"));
        }

        [Test]
        public void ShouldCreateTable()
        {
            var result = _clustering.GetClusters(_trueMock.Object, "Investment Title");
            Assert.AreEqual(result.Count, 1);
        }
    }
}
