using System.Collections.Generic;
using System.IO;
using System.Linq;
using Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Services.Interfaces;

namespace Services
{
    public class DocumentService : IDocumentService
    {
        public Document[] PrepareDocuments(IList<Person> persons)
        {
            return persons.Select(GetDocument).ToArray();
        }

        private Document GetDocument(Person person)
        {
            var doc = new PdfDocument();
            doc.Info.Title = "National Criminal search results";

            var page = doc.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            var lineNumber = 1;
            const int lineHeight = 25;

            DrawStringInNextLine("Name: " + person.Name, gfx, page, font, lineNumber++ * lineHeight);
            DrawStringInNextLine("Surname: " + person.Surname, gfx, page, font, lineNumber++ * lineHeight);
            DrawStringInNextLine(string.Format("Age: {0}yrs", person.Age), gfx, page, font, lineNumber++ * lineHeight);
            DrawStringInNextLine("Sex: " + person.Sex, gfx, page, font, lineNumber++ * lineHeight);
            DrawStringInNextLine(string.Format("Height: {0}cm", person.Height), gfx, page, font, lineNumber++ * lineHeight);
            DrawStringInNextLine(string.Format("Weight: {0}kg", person.Weight), gfx, page, font, lineNumber++ * lineHeight);
            DrawStringInNextLine("Nationality: " + person.Nationality.Title, gfx, page, font, lineNumber++ * lineHeight);

            var stream = new MemoryStream();
            doc.Save(stream, false);
            return new Document { FileName = string.Format("{0} {1}.pdf", person.Name, person.Surname), Content = stream };
        }

        void DrawStringInNextLine(string text, XGraphics gfx, PdfPage page, XFont font, int line)
        {
            gfx.DrawString(text, font, XBrushes.Black, new XRect(30, line, page.Width, page.Height), XStringFormats.TopLeft);
        }
    }
}
