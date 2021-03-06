﻿using System.Collections.Generic;
using System.Linq;
using Clustering.Interfaces;

namespace Clustering
{
    public class Clustering
    {
        private Table _initialTable;
        private IDictionary<string, IList<int>> _clustersDictionary;

        private bool TryAdd(IClusteringAlg alg, string line, int index)
        {
            foreach (var pair in _clustersDictionary)
            {
                if (alg.AreEqual(pair.Key, line))
                {
                    pair.Value.Add(index);
                    return true;
                }
            }
            return false;
        }

        private IList<Table> DictToTableList(IDictionary<string, IList<int>> dict)
        {
            IList<Table> result = new List<Table>();
            foreach (var item in dict)
            {
                var temp = new List<IList<string>>();
                temp.Add(_initialTable.Colunms);
                temp.AddRange(item.Value.Select(rowNumber => _initialTable.GetRowByIndex(rowNumber)).ToList());
                result.Add(new Table(temp));
            }
            return result;
        }

        private IDictionary<int, string> NormalizeDict(IDictionary<int, string> dict, IClusteringAlg alg)
        {
            var values = alg.NormalizeStrings(dict.Values).ToList();
            var normalizedDict = new Dictionary<int, string>();
            for (var i = 0; i < dict.Count; i++)
            {
                normalizedDict.Add(dict.Keys.ElementAt(i), values.ElementAt(i));
            }
            return normalizedDict;
        }

        private void Cluster(IClusteringAlg alg, string columnName, Table table)
        {
            _initialTable = table;
            _clustersDictionary = new Dictionary<string, IList<int>>();

            var column = _initialTable.GetColumnByName(columnName).ToDictionary(x => x.Key, x => x.Value);
            var noralizedColumn = NormalizeDict(column, alg);

            _clustersDictionary.Add(new KeyValuePair<string, IList<int>>(noralizedColumn.Values.First(), new List<int> { noralizedColumn.Keys.First() }));

            for (var i = 1; i < column.Count; i++)
            {
                var line = column.ElementAt(i).Value;

                if (!TryAdd(alg, line, column.ElementAt(i).Key))
                {
                    _clustersDictionary.Add(line, new List<int> { column.ElementAt(i).Key });
                }
            }
        }

      
        public IList<Table> GetClusters(IClusteringAlg alg, string columnName, Table table)
        {
            Cluster(alg, columnName, table);
            return DictToTableList(_clustersDictionary.Where(l => l.Value.Count() > 1).ToDictionary(x => x.Key, x => x.Value));
        }

        public IDictionary<string, IList<int>> GetClustersDictionary(IClusteringAlg alg, string columnName, Table table)
        {
            Cluster(alg, columnName, table);
            return _clustersDictionary;
        }
    }
}
