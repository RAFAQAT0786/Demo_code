using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

public class ATPDFReport
{
    private static Font HeadingFont = new Font(Font.HELVETICA, 14f, Font.BOLD);
    private static Font SubHeadingFont = new Font(Font.HELVETICA, 12f, Font.BOLD);
    private static Font TableHeadingFont = new Font(Font.HELVETICA, 10f, Font.NORMAL);

    private static Font NormalFont = new Font(Font.HELVETICA, 7f, Font.NORMAL);
    private static Font BoldFont = new Font(Font.HELVETICA, 7f, Font.BOLD);
    private static Font UnderlineFont = new Font(Font.HELVETICA, 7f, Font.UNDERLINE);

    public static Document CreatePDFDocument(Orientation orientation, String filePath)
    {
        Document document;
        if (orientation == Orientation.Portrait)
            document = new Document(PageSize.A4, 15, 15, 15, 15);
        else
            document = new Document(PageSize.A4.Rotate(), 0, 0, 10, 10);
        try
        {
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();
        }
        catch (DocumentException de)
        {
            //Response.Write(de.Message);
        }
        catch (IOException ioe)
        {
            //Response.Write(ioe.Message);
        }
        //document.Close();
        return document;
    }

    public static Document CreatePDFDocument(Orientation orientation, String filePath, string title)
    {
        Document document = CreatePDFDocument(orientation, filePath);
        try
        {
            Paragraph documentHeading = new Paragraph(ConfigurationManager.AppSettings["CompanyName"].ToString(), HeadingFont);
            documentHeading.SetAlignment("Center");
            document.Add(documentHeading);

            documentHeading = new Paragraph(title + "\n\n", SubHeadingFont);
            documentHeading.SetAlignment("Center");
            document.Add(documentHeading);
        }
        catch (DocumentException de)
        {
            //Response.Write(de.Message);
        }
        catch (IOException ioe)
        {
            //Response.Write(ioe.Message);
        }
        //document.Close();
        return document;
    }

    public static void CreatePDFReport(Orientation orientation, List<ColumnInfo> columnList, string filePath, string title, System.Data.DataTable dt)
    {
        Document document = CreatePDFDocument(orientation, filePath, title);
        try
        {
            PdfPTable pdfPTable = CreatePDFTable(columnList, dt);
            document.Add(pdfPTable);
        }
        catch (Exception ioe)
        {
            //Response.Write(ioe.Message);
        }
        document.Close();
    }

    public static PdfPTable CreatePDFTable(List<ColumnInfo> columnList)
    {
        PdfPTable pdfPTable = new PdfPTable(columnList.Count);
        try
        {
            float[] widths = columnList.Select(col => col.Width).ToArray();
            pdfPTable.SetWidths(widths);
        }
        catch (Exception ioe)
        {
        }
        return pdfPTable;
    }

    public static PdfPTable CreatePDFHeaderTable(int noCols, List<object> dataList)
    {
        PdfPTable pdfPTable = new PdfPTable(noCols);
        try
        {
            foreach (object data in dataList)
            {
                AddCell(data.ToString(), pdfPTable);
            }
            int remaining = dataList.Count % noCols;
            if (dataList.Count % noCols > 0)
            {
                AddCell("", pdfPTable, remaining);
            }
        }
        catch (Exception ioe)
        {
            //Response.Write(ioe.Message);
        }
        return pdfPTable;
    }

    public static PdfPTable CreatePDFTable(List<ColumnInfo> columnList, System.Data.DataTable dt)
    {
        PdfPTable pdfPTable = CreatePDFTable(columnList);
        try
        {
            foreach (ColumnInfo columnInfo in columnList)
            {
                AddHeading(columnInfo.Heading, pdfPTable);
            }
            foreach (System.Data.DataRow dataRow in dt.Rows)
            {
                foreach (ColumnInfo columnInfo in columnList)
                {
                    AddCell(dataRow[columnInfo.DataColumn], pdfPTable);
                }
            }
        }
        catch (Exception ioe)
        {
            //Response.Write(ioe.Message);
        }
        return pdfPTable;
    }

    public static void AddCell(object data, Font font, PdfPTable pdfTable, int alignment, Color bgColor)
    {
        AddCell(data, font, pdfTable, alignment, bgColor, 1);
    }

    public static void AddHeading(object data, PdfPTable pdfTable)
    {
        AddCell(data, BoldFont, pdfTable, PdfPCell.ALIGN_LEFT, Color.LIGHT_GRAY, 1);
    }

    public static void AddHeading(object data, PdfPTable pdfTable, int alignment, Color bgColor, int colspan)
    {
        AddCell(data, BoldFont, pdfTable, PdfPCell.ALIGN_LEFT, Color.LIGHT_GRAY, 1);
    }

    public static void AddCell(object data, Font font, PdfPTable pdfTable, int alignment, Color bgColor, int colspan)
    {
        PdfPCell pdfPCell = new PdfPCell(new Phrase(data.ToString(), font));
        pdfPCell.HorizontalAlignment = alignment;
        pdfPCell.BackgroundColor = bgColor;
        pdfPCell.Colspan = colspan;
        pdfTable.AddCell(pdfPCell);
    }

    public static void AddCell(object data, PdfPTable pdfTable, int alignment, Color bgColor, int colspan)
    {
        PdfPCell pdfPCell = new PdfPCell(new Phrase(data.ToString(), NormalFont));
        pdfPCell.HorizontalAlignment = alignment;
        pdfPCell.BackgroundColor = bgColor;
        pdfPCell.Colspan = colspan;
        pdfTable.AddCell(pdfPCell);
    }

    public static void AddCell(object data, PdfPTable pdfTable, int alignment, int colspan)
    {
        PdfPCell pdfPCell = new PdfPCell(new Phrase(data.ToString(), NormalFont));
        pdfPCell.HorizontalAlignment = alignment;
        pdfPCell.Colspan = colspan;
        pdfTable.AddCell(pdfPCell);
    }

    public static void AddCell(object data, PdfPTable pdfTable, int colspan)
    {
        PdfPCell pdfPCell = new PdfPCell(new Phrase(data.ToString(), NormalFont));
        pdfPCell.Colspan = colspan;
        pdfTable.AddCell(pdfPCell);
    }

    public static void AddCell(object data, PdfPTable pdfTable)
    {
        AddCell(data, NormalFont, pdfTable, PdfPCell.ALIGN_LEFT, Color.WHITE, 1);
    }
}

public class ColumnInfo
{
    public string Heading { get; set; }
    public string DataColumn { get; set; }
    public float Width { get; set; }

    public ColumnInfo(string heading, string dataColumn, float width)
    {
        Heading = heading;
        DataColumn = dataColumn;
        Width = width;
    }
}