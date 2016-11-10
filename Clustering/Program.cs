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
            //Console.WriteLine("filename:");
            string fileName = "Contracts.csv";//Console.ReadLine();
            //Console.WriteLine("attribute:");
            string columnName = "Contract Description (USAspending)";//Console.ReadLine();
            Table t = new Table(tr.Read(fileName));
            var clust = new Clustering(t);
            tw.Write(clust.ClusterWith(new KeyCollision(), columnName));
        }
    }
}
