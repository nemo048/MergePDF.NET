using System.IO;
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

                foreach (string file in mergeOptions.Files)
                {
                    pdfCopyProvider.AddFile(file);
                }
                
                outputDocument.Close();  
            }
        }
    }
}