using CommandLine;

namespace Clustering
{
    public class CmdOptions
    {
        [Option('f', "input file")]
        public string InputFile { get; set; }

        [Option('c', "column name")]
        public string ColumnName { get; set; }

        [Option('a', "algorythm name", DefaultValue = "NGram")]
        public string Algorythm { get; set; }

        [Option('i', "integer argument", DefaultValue = 3)]
        public int IntArg { get; set; }

        [Option('d', "double argument", DefaultValue = 1.3)]
        public double DoubleArg { get; set; }
    }
}
