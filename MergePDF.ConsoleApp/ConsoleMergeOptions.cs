using System;
using System.Collections.Generic;
using CommandLine;
using MergePDF.Tool.Interfaces;

namespace MergePDF.ConsoleApp
{
    public sealed class ConsoleMergeOptions : IMergeOptions
    {
        /// <inheritdoc />
        [Option('f', "files", Required = true, HelpText = "Set files to merge")]
        public IEnumerable<string> Files { get; set; }

        /// <inheritdoc />
        [Option('o', "output", Required = false, Default = null, HelpText = "Set output file path")]
        public string Output { get; set; }
    }
}