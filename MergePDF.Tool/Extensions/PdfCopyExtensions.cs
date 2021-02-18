using iTextSharp.text.pdf;

namespace MergePDF.Tool.Extensions
{
    public static class PdfCopyExtensions
    {
        public static void AddFile(this PdfCopy pdfCopyProvider, string filePath)
        {
            using (PdfReader reader = new(filePath))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    PdfImportedPage importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }  
  
                reader.Close();
            }
        }
    }
}