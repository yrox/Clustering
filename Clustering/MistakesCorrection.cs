using System.Collections.Generic;
using System.Linq;
using Clustering.Interfaces;
using Clustering.IO;
using Clustering.NinjectBindings;
using Ninject;

namespace Clustering
{
    public class MistakesCorrection
    {
        public MistakesCorrection(CmdOptions options, Table table, Clustering clustering)
        {
            _options = options;
            _initialTable = table;
            _clustering = clustering;
            _columnIndex = _initialTable.Colunms.IndexOf(_options.ColumnName);
        }

        private Table _initialTable;
        private Clustering _clustering;
        private CmdOptions _options;
        private int _columnIndex;

        private string GetDefaultClusterElement(IEnumerable<int> linesIndexes)
        {
            var values = linesIndexes.Select(index => _initialTable.Rows.ElementAt(index).ElementAt(_columnIndex)).ToList();
            return values.GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key).First();
        }

        private IClusteringAlg InitializeAlg(string algName)
        {
            var kernel = new StandardKernel(new ClusteringAlgBindings(_options));
            return kernel.Get<IClusteringAlg>(algName);
        }

       private void FixTable(IDictionary<string, IList<int>> clusters, IDictionary<string, string> userValues = null)
        {
            
            foreach (var cluster in clusters)
            {
                var correctValue = GetDefaultClusterElement(cluster.Value);

                if (userValues != null)
                {
                    if (userValues.Keys.Contains(cluster.Key))
                    {
                        correctValue = userValues[cluster.Key];
                    }
                }

                FixCluster(cluster.Value, correctValue);
            }
        }

        private void FixCluster(IEnumerable<int> linesIndxes, string correctValue)
        {
            foreach (var line in linesIndxes)
            {
                _initialTable.Rows[line][_columnIndex] = correctValue;
            }
        }

        public Table CorrectMistakes(string algName, IDictionary<string, string> userValues = null)
        {
            if (userValues == null)
            {
                FixTable(_clustering.GetClustersDictionary(InitializeAlg(algName), _options.ColumnName, _initialTable));
            }
            else
            {
                FixTable(_clustering.GetClustersDictionary(InitializeAlg(algName), _options.ColumnName, _initialTable), userValues);
            }
            
            return _initialTable;
        }
    }
}
