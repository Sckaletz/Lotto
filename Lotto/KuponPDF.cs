using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;

namespace Lotto
{
    public class KuponPDF
    {
        public string Sti;
        private PdfDocument PdfDoc;
        public KuponPDF(string sti)
        {
            this.Sti = sti;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            this.PdfDoc = new PdfDocument();
        }

        public void AddKupon()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Sti);
            FileInfo[] filer = directoryInfo.GetFiles("*.txt");
            foreach (FileInfo fil in filer)
            {
                PdfPage side = PdfDoc.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(side);
                XFont font = new XFont("Verdana", 14, XFontStyle.Bold);
                XFont fontb = new XFont("Verdana", 14, XFontStyle.Regular);
                string timestamp = File.ReadLines(fil.FullName).ElementAtOrDefault(1 - 1);
                string week = File.ReadLines(fil.FullName).ElementAtOrDefault(3 - 1);
                string title = File.ReadLines(fil.FullName).ElementAtOrDefault(4 - 1);
                List<string> rows = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    string row = File.ReadLines(fil.FullName).ElementAtOrDefault((i+6) - 1);
                    rows.Add(row);
                }

                gfx.DrawString(timestamp, font, XBrushes.Black, new XRect(-10, 20, side.Width, side.Height), XStringFormat.TopCenter);
                gfx.DrawString(week, fontb, XBrushes.Black, new XRect(-20, 60, side.Width, side.Height), XStringFormat.TopCenter);
                gfx.DrawString(title, font, XBrushes.Black, new XRect(-15, 80, side.Width, side.Height), XStringFormat.TopCenter);

                int space = 120;
                foreach (var row in rows)
                {
                    gfx.DrawString(row, fontb, XBrushes.Black, new XRect(0, space, side.Width, side.Height), XStringFormat.TopCenter);
                    space += 20;
                }
                if (fil.OpenText().ReadToEnd().Contains("*"))
                {
                    string jokerTitle = File.ReadLines(fil.FullName).ElementAtOrDefault(17 - 1);
                    string jokerRow1 = File.ReadLines(fil.FullName).ElementAtOrDefault(18 - 1);
                    string jokerRow2 = File.ReadLines(fil.FullName).ElementAtOrDefault(19 - 1);
                    gfx.DrawString(jokerTitle, fontb, XBrushes.Black, new XRect(0, 340, side.Width, side.Height), XStringFormat.TopCenter);
                    gfx.DrawString(jokerRow1, fontb, XBrushes.Black, new XRect(25, 360, side.Width, side.Height), XStringFormat.TopCenter);
                    gfx.DrawString(jokerRow2, fontb, XBrushes.Black, new XRect(25, 380, side.Width, side.Height), XStringFormat.TopCenter);
                }
            }
            FileInfo[] filerB = directoryInfo.GetFiles("*.pdf");
            if (filerB != null)
            {
                foreach (FileInfo fil in filerB)
                    fil.Delete();
            }
            string datetime = DateTime.Now.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("HH.mm.ss");
            PdfDoc.Save(Sti + "Kuponer_" + datetime + ".pdf");
        }

        public void OpenPDF()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Sti);
            FileInfo[] filer = directoryInfo.GetFiles("*.pdf");
            if (filer != null)
            {
                foreach (FileInfo fil in filer)
                {
                    Process.Start(fil.FullName);
                }
            }

        }
    }
}
