using System.Collections.Generic;
using CommandLine;
using MergePDF.Tool.Interfaces;

namespace MergePDF.ConsoleApp
{
    public sealed class ConsoleMergeOptions : IMergeOptions
    {
        /// <inheritdoc />
        [Option('f', "files", Required = false, Default = null, HelpText = "Set files to merge")]
        public IEnumerable<string> Files { get; set; }

        /// <inheritdoc />
        [Option('o', "output", Required = false, Default = null, HelpText = "Set output file path")]
        public string Output { get; set; }
        
        [Option('d', "directories", Required = false, Default = null, HelpText = "Set directories from where merge files")]
        public IEnumerable<string> Directories { get; set; }
    }
}