using System.Collections.Generic;
using Clustering.NinjectBindings;
using Clustering.Interfaces;
using Clustering.IO;
using CommandLine;
using Ninject;

namespace Clustering
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new CmdOptions();
           
            Parser.Default.ParseArguments(args, options);
             
            var tr = new TableReader();
            var tw = new TableWriter();
            var t = new Table(tr.Read(options.InputFile));
            var clust = new Clustering();
            var corrector = new MistakesCorrection(options);

            //var kernel = new StandardKernel(new ClusteringAlgBindings(options));
            //var alg = kernel.Get<IClusteringAlg>(options.Algorythm);

            //var algType = Type.GetType("Clustering.Algorythms." + options.Algorythm + ", Clustering");
            //var alg = (IClusteringAlg)Activator.CreateInstance(algType, options.DoubleArg, options.IntArg);

            //var a = Activator.CreateInstance("Clustering", "Clustering.Options");
            //var alg = Activator.CreateInstance("Clustering", options.Algorythm) as IClusteringAlg;

            tw.Write(corrector.CorrectMistakes(t, options.Algorythm));
            //tw.Write(clust.GetClusters(alg, options.ColumnName, t), options.ColumnName);
        }
    }
}
