using System.Collections.Generic;

namespace Clustering.DTO
{
    public class TableDTO
    {
        public IEnumerable<string> Columns { get; set; }
        public IEnumerable<IEnumerable<string>> Rows { get; set; }
    }
}
