using Aspose.Words;
using System;
using System.Collections.Generic;

namespace Test_Automation
{
    class docx_save
    {
       public static string save_160(List<Data160> data160,string savefile,string max,string min,string bp)
        {
            int colomn_width = 50;
            Aspose.Words.Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            builder.PageSetup.PaperSize = PaperSize.A4;
            builder.PageSetup.Orientation = Aspose.Words.Orientation.Landscape;  //Landscape;水平
            builder.PageSetup.LeftMargin = 50;
            builder.PageSetup.TopMargin = 60;
            builder.PageSetup.BottomMargin = 30;
            builder.StartTable();
            // builder.RowFormat.LeftIndent = 15;
            //标题

            builder.InsertCell();//序号列
            builder.Write("坐标");
            builder.InsertCell();
            // builder.CellFormat.
            builder.CellFormat.Borders.LineStyle = LineStyle.Single;
            builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
            builder.CellFormat.Width = colomn_width;
            builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;//垂直居中对齐
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
            builder.Write("类别");
            //标题
            for (int i = 1; i < 17; i++)
            {
                builder.InsertCell();
                builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                builder.CellFormat.Width = colomn_width;
                builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;//垂直居中对齐
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
                builder.Write(i.ToString());
            }
            builder.EndRow();

            for (int j = 0; j < 10; j++)
            {
                builder.InsertCell();
                builder.Write((j + 1).ToString());  //序号
                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.First;
                builder.InsertCell();
                builder.Write("l");

                for (int i = 0; i < 16; i++)
                {
                    builder.InsertCell();
                    builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                    builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                    builder.CellFormat.Width = colomn_width;
                    builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;//垂直居中对齐
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
                    try { builder.Write(data160[i + j * 16].l); } catch { }
                }
                builder.EndRow();

                builder.InsertCell();

                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.Previous;

                builder.InsertCell();

                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                builder.Write("u");
                for (int i = 0; i < 16; i++)
                {
                    builder.InsertCell();

                    builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                    builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                    builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                    builder.CellFormat.Width = colomn_width;
                    builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;//垂直居中对齐
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
                    try { builder.Write(data160[i + j * 16].u); } catch { }
                }
                builder.EndRow();
                builder.InsertCell();

                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.Previous;
                builder.InsertCell();

                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                builder.Write("v");
                for (int i = 0; i < 16; i++)
                {
                    builder.InsertCell();

                    builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                    builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                    builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                    builder.CellFormat.Width = colomn_width;
                    builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;//垂直居中对齐
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
                    try { builder.Write(data160[i + j * 16].v.Trim()); } catch { }
                }
                builder.EndRow();
            }

            builder.EndTable();

            builder.Write("最大值：" + max + "\t");
            builder.Write("最小值：" + min + "\t");
            builder.Write("BP值：" + bp + "\t");
            builder.Write("测试时间：" + DateTime.Now.ToString() + "\r\n");


            try
            {
                doc.Save(savefile);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
