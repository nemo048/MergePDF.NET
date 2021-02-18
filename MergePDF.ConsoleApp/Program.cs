using System;
using System.Collections.Generic;
using CommandLine;
using MergePDF.Tool;

namespace MergePDF.ConsoleApp
{
    class Program
    {
        private static ConsoleMergeOptions HandleErrors(IEnumerable<Error> errors)
        {
            throw new NotImplementedException();
        }

        private static ConsoleMergeOptions ParseOptions(string[] args)
        {
            return Parser.Default
                .ParseArguments<ConsoleMergeOptions>(args)
                .MapResult(options => options, HandleErrors);
        }

        public static void Main(string[] args)
        {
            ConsoleMergeOptions mergeOptions = ParseOptions(args);
            MergeTool mergeTool = new();
            mergeTool.Merge(mergeOptions);
        }
    }
}