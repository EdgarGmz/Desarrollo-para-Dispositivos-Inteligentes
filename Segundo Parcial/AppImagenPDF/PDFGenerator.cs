using System;
using System.Collections.Generic;
using System.Text;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace AppImagenPDF
{
    public class PDFGenerator
    {
        public static byte[] GeneratePDFWithImage (string imagePath)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var imageBytes = File.ReadAllBytes (imagePath);

            var document = Document.Create(container =>
            {
                container.Page(page => 
                {
                    page.Margin(30);
                    page.Size(PageSizes.A4);

                    page.Content().Column(col =>
                    {
                        col.Item()
                        .Text("Imagen Insertada en PDF")
                        .FontSize(18).Bold()
                        .AlignCenter();

                        col.Item().Image(imageBytes, ImageScaling.FitWidth);
                    });
                });
            });

            using var stream = new MemoryStream ();
            document.GeneratePdf(stream);
            return stream.ToArray();
        }
    }
}
