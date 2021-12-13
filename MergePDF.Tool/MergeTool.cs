using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MergePDF.Tool.Extensions;
using MergePDF.Tool.Interfaces;

namespace MergePDF.Tool
{
    public sealed class MergeTool
    {
        public void Merge(IMergeOptions mergeOptions)
        {
            using (Stream fileStream = new FileStream(mergeOptions.Output, FileMode.Create))
            using (Document outputDocument = new())
            using (PdfCopy pdfCopyProvider = new(outputDocument, fileStream))
            {
                outputDocument.Open();

                if (ShouldMergeFromSingleFiles(mergeOptions))
                {
                    foreach (string file in mergeOptions.Files)
                    {
                        pdfCopyProvider.AddFile(file);
                    }
                }

                if (ShouldMergeFromDirectories(mergeOptions))
                {
                    foreach (string directory in mergeOptions.Directories)
                    {
                        foreach (string file in Directory.EnumerateFiles(directory))
                        {
                            pdfCopyProvider.AddFile(file);
                        }
                    }
                }

                outputDocument.Close();  
            }
        }

        private static bool ShouldMergeFromDirectories(IMergeOptions mergeOptions)
        {
            return mergeOptions.Directories is not null && mergeOptions.Directories.Any();
        }

        private static bool ShouldMergeFromSingleFiles(IMergeOptions mergeOptions)
        {
            return mergeOptions.Files is not null && mergeOptions.Files.Any();
        }
    }
}