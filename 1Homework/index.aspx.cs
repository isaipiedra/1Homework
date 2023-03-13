using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO.Packaging;
using SpreadsheetLight;
using System.Drawing;

namespace _1Homework
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void loadVideo_Click(object sender, EventArgs e)
        {
            //Try catch sentence to validate that the youtube link is correct
            try
            {
                string newUrl = "https://www.youtube.com/embed/";
                string portion = "";
                string url = videoUrl.Text.Trim();

                for (int i = 0; i < url.Length; i++)
                {
                    portion += url[i];
                    if (portion.Equals("https://youtu.be/") || portion.Equals("https://www.youtube.com/watch?v="))
                    {
                        portion = "";
                    }
                }

                newUrl += portion;

                if (newUrl.Contains("start") || newUrl.Contains("index"))
                {

                }
                else
                {
                    videoTag.Attributes.Add("src", newUrl);
                }
            }
            catch
            {
                videoTag.Attributes.Add("src", "https://www.youtube.com/embed/D7kz1LvX8vA");
            }
        }

        protected void shapeDraw_Click(object sender, EventArgs e)
        {
            string shape = "";

            SLDocument newShape = new SLDocument();
            
            newShape.AddWorksheet("Sheet1");
            newShape.SetColumnWidth(1, 12, 3.78);
            newShape.SetRowHeight(1, 12, 19.5);

            SLStyle border = new SLStyle();
            border.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml("#000"), System.Drawing.ColorTranslator.FromHtml("#000"));

            SLStyle mainColor = new SLStyle();
            mainColor.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml(colorPicker.Value), System.Drawing.ColorTranslator.FromHtml(colorPicker.Value));

            int length = 9;

            switch (shapeSelector.Value)
            {
                case "0":
                    shape = "square";
                    for (int i = 1; i <= length; i++)
                    {
                        for (int j = 1; j <= length; j++)
                        {
                            if (i == 1 || i == 9)
                            {
                                newShape.SetCellStyle(i, j, border);
                            }
                            else
                            {
                                if (j == 1 || j == 9)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                } else
                                {
                                    newShape.SetCellStyle(i, j, mainColor);
                                }
                            }
                        }
                    }
                    break;
                case "1":
                    shape = "circle";
                    for (int i = 1; i <= length; i++)
                    {
                        for (int j = 1; j <= length; j++)
                        {
                            if (i == 1 || i == 9)
                            {
                                if (j >= 3 && j <= 7)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                            }
                            else if (i == 2 || i == 8)
                            {
                                if (j == 2 || j == 8)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                } else if (j >= 3 && j <= 7)
                                {
                                    newShape.SetCellStyle(i, j, mainColor);
                                }
                            }
                            else
                            {
                                if (j == 1 || j == 9)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                                else
                                {
                                    newShape.SetCellStyle(i, j, mainColor);
                                }
                            }
                        }
                    }
                    break; 
                case "2":
                    shape = "diamond";
                    for(int i = 1; i <= length; i++)
                    {
                        for (int j = 1; j <= length; j++)
                        {
                            if (i == 1 || i == 9)
                            {
                                if (j == 5)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                            }
                            else if (i == 2 || i == 8)
                            {
                                if (j == 4 || j == 6)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                } else if (j == 5)
                                {
                                    newShape.SetCellStyle(i, j, mainColor);
                                }
                            }
                            else if (i == 3 || i == 7)
                            {
                                if (j == 3 || j == 7)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                                else if (j > 3 && j < 7)
                                {
                                    newShape.SetCellStyle(i, j, mainColor);
                                }
                            }
                            else if (i == 6 || i == 4)
                            {
                                if (j == 2 || j == 8)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                                else if (j > 2 && j < 8)
                                {
                                    newShape.SetCellStyle(i, j, mainColor);
                                }
                            }
                            else
                            {
                                if (j == 1 || j == 9)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                                else if (j > 1 && j < 9)
                                {
                                    newShape.SetCellStyle(i, j, mainColor);
                                }
                            }
                        }
                    }
                    break;
                case "3":
                    shape = "Heart";
                    for (int i = 1; i <= length; i++)
                    {
                        for (int j = 1; j <= length; j++)
                        {
                            if (i == 1)
                            {
                                if (j == 3 || j == 4 || j == 6 || j == 7)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                            }
                            else if (i == 2)
                            {
                                if (j == 2 || j == 5 || j == 8)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                                else if (j == 3 || j == 4 || j == 6 || j == 7)
                                {
                                    newShape.SetCellStyle(i, j, mainColor);
                                }
                            } 
                            else if (i >= 3 && i <= 5)
                            {
                                if (j == 1 || j == 9)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                                else
                                {
                                    newShape.SetCellStyle(i, j, mainColor);
                                }
                            }
                            else if (i == 6)
                            {
                                if (j == 2 || j == 8)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                                else if (j > 2 && j < 8)
                                {
                                    newShape.SetCellStyle(i, j, mainColor);
                                }
                            }
                            else if (i == 7)
                            {
                                if (j == 3 || j == 7)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                                else if (j > 3 && j < 7)
                                {
                                    newShape.SetCellStyle(i, j, mainColor);
                                }
                            }
                            else if (i == 8)
                            {
                                if (j == 4 || j == 6)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                                else if (j == 5)
                                {
                                    newShape.SetCellStyle(i, j, mainColor);
                                }
                            }
                            else
                            {
                                if (j == 5)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                            }
                        }
                    }
                    break;  
            }
            
            string path = $"H:\\Desarrollo Web Duodécimo\\Programación para web\\PRIMER SEMESTRE\\1 TAREA\\1Homework\\1Homework\\DataBase\\{shape}.xlsx";
            newShape.SaveAs(path);
        }
    }
}