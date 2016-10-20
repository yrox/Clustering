namespace Clustering
{
    class Program
    {
        static void Main(string[] args)
        {
            TableReader tr = new TableReader();
            TableWriter tw = new TableWriter();
            Table t = new Table(tr.Read("input.csv"));
            var clust = new Clustering(t);
            tw.Write(clust.ClusterWith(new PhoneticSimilarity(), "Value"));
            
        }


    }
}
