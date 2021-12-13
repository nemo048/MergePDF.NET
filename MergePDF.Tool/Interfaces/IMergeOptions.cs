using System.Collections.Generic;

namespace MergePDF.Tool.Interfaces
{
    public interface IMergeOptions
    {
        public IEnumerable<string> Files { get; set; }
        public string Output { get; set; }
        public IEnumerable<string> Directories { get; set; }
    }
}