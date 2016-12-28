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
        public MistakesCorrection(CmdOptions options)
        {
            _options = options;
        }

        private Table _initialTable;
        private Clustering _clustering;
        private CmdOptions _options;

        private string GetDefaultClusterElement(IEnumerable<int> linesIndexes)
        {
            var columnIndex = _initialTable.Colunms.IndexOf(_options.ColumnName);
            var values = linesIndexes.Select(index => _initialTable.table.ElementAt(index).ElementAt(columnIndex)).ToList();
            return values.GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key).First();
        }

        private void FixTable(IDictionary<string, IList<int>> clusters)
        {
            _initialTable.CorrectColumn(_options.ColumnName, clusters);
        }

        public Table CorrectMistakes(Table table, string algName)
        {
            _clustering = new Clustering();
            _initialTable = table;
            var columnName = _options.ColumnName;

            var kernel = new StandardKernel(new ClusteringAlgBindings(_options));
            var alg = kernel.Get<IClusteringAlg>(algName);

            FixTable(_clustering.GetClustersDictionary(alg, columnName, _initialTable));
            
            return _initialTable;
        }
    }
}
