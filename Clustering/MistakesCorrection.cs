using System.Collections.Generic;
using Clustering.Algorythms;
using Clustering.IO;

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

        private void FixTable(IDictionary<string, IList<int>> clusters)
        {
            _initialTable.CorrectColumn(_options.ColumnName, clusters);
        }

        public Table CorrectMistakes(Table table)
        {
            _clustering = new Clustering();
            _initialTable = table;
            var columnName = _options.ColumnName;

            FixTable(_clustering.GetClustersDictionary(new KeyCollision(), columnName, _initialTable));
            FixTable(_clustering.GetClustersDictionary(new NGram(_options.IntArg), columnName, _initialTable));
            FixTable(_clustering.GetClustersDictionary(new Compression(_options.DoubleArg), columnName, _initialTable));
            FixTable(_clustering.GetClustersDictionary(new Levenshtein(_options.IntArg), columnName, _initialTable));
            FixTable(_clustering.GetClustersDictionary(new PhoneticSimilarity(), columnName, _initialTable));

            return _initialTable;
        }
    }
}
