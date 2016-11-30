using Clustering.Algorythms;
using Clustering.Interfaces;
using Clustering.IO;
using Ninject.Modules;

namespace Clustering.NinjectBindings
{
    public class ClusteringAlgBindings : NinjectModule
    {
        public ClusteringAlgBindings(CmdOptions options)
        {
            _options = options;
        }

        private CmdOptions _options;

        public override void Load()
        {
            Bind<IClusteringAlg>().To<Compression>().Named("Compression").WithConstructorArgument("threshold", _options.DoubleArg);
            Bind<IClusteringAlg>().To<KeyCollision>().Named("KeyCollision");
            Bind<IClusteringAlg>().To<Levenshtein>().Named("Levenshtein").WithConstructorArgument("threshold", _options.IntArg);
            Bind<IClusteringAlg>().To<NGram>().Named("NGram").WithConstructorArgument("threshold", _options.IntArg); ;
            Bind<IClusteringAlg>().To<PhoneticSimilarity>().Named("PhoneticSimilarity");
        }
    }
    
}
