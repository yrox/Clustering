using System;
using System.IO;
using Clustering.Algorythms;
using Clustering.IO;

namespace Clustering
{
    class Program
    {
        static void Main(string[] args)
        {
            TableReader tr = new TableReader();
            TableWriter tw = new TableWriter();
            string fileName = "Contracts.csv";
            string columnName = "Investment Title";
            Table t = new Table(tr.Read(fileName));
            var clust = new Clustering(t);
            tw.Write(clust.ClusterWith(new Levenshtein(3), columnName));
        }
    }
}
