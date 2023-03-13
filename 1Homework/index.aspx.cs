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
            //Keep the last scroll position
            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void loadVideo_Click(object sender, EventArgs e)
        {
            //Try catch sentence to validate that the youtube link is correct
            try
            {
                //Create the new embed url
                string newUrl = "https://www.youtube.com/embed/";

                //Variable for the portion of the specific YT URL
                string portion = "";

                //Capture the users entered URL
                string url = videoUrl.Text.Trim();

                //Read users entered URL
                for (int i = 0; i < url.Length; i++)
                {
                    //Create the new portion of the embed URL
                    portion += url[i];

                    //Deletes the YT portion of the URL to store the series number
                    if (portion.Equals("https://youtu.be/") || portion.Equals("https://www.youtube.com/watch?v="))
                    {
                        portion = "";
                    }
                }

                //New embed URL
                newUrl += portion;

                //Validates that the provided URL is not a Mix
                if (newUrl.Contains("start") || newUrl.Contains("index"))
                {
                    //If the URL is a Mix alerts the user and copy the default URL
                    videoTag.Attributes.Add("src", "https://www.youtube.com/embed/D7kz1LvX8vA");
                }
                else
                {
                    //Change the default URL for the users provided video
                    videoTag.Attributes.Add("src", newUrl);
                }
            }
            //If the URL was not allowed alerts the user and copy the default URL
            catch
            {
                videoTag.Attributes.Add("src", "https://www.youtube.com/embed/D7kz1LvX8vA");
            }
        }

        protected void shapeDraw_Click(object sender, EventArgs e)
        {
            //Declare the variable for the shape name (file name)
            string shape = "";

            //Create new Excel document
            SLDocument newShape = new SLDocument();
            
            //Select the first worksheet
            newShape.AddWorksheet("Sheet1");

            //Set the column and row width and height for them being perfect squares
            newShape.SetColumnWidth(1, 12, 3.78);
            newShape.SetRowHeight(1, 12, 19.5);

            //Set the style of the border of the shapes
            SLStyle border = new SLStyle();
            border.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml("#000"), System.Drawing.ColorTranslator.FromHtml("#000"));

            //Set the style of the inside of the shapes with the users color
            SLStyle mainColor = new SLStyle();
            mainColor.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml(colorPicker.Value), System.Drawing.ColorTranslator.FromHtml(colorPicker.Value));

            //Set the length of the width and height of the workspace for the shapes
            int length = 9;

            //Validates the type of shape that the user selected
            switch (shapeSelector.Value)
            {
                //Creates a square
                case "0":
                    //Set the name of the document with the type of shape (square)
                    shape = "square";

                    //Ident over the rows
                    for (int i = 1; i <= length; i++)
                    {
                        //Ident over the columns
                        for (int j = 1; j <= length; j++)
                        {
                            //First and last rows are full borders
                            if (i == 1 || i == 9)
                            {
                                newShape.SetCellStyle(i, j, border);
                            }
                            //Other rows are border in the first and last columns
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
                    //Set the name of the document with the type of shape (circle)
                    shape = "circle";
                    //Ident over the rows
                    for (int i = 1; i <= length; i++)
                    {
                        //Ident over the columns
                        for (int j = 1; j <= length; j++)
                        {
                            //First and last rows are borders between 3 and 7
                            if (i == 1 || i == 9)
                            {
                                if (j >= 3 && j <= 7)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                            }
                            //Second and eight rows are borders in 2nd and 8th position and inside between 3 and 7
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
                            //Other rows are borders at the beginning and the end, and inside otherwise
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
                    //Set the name of the document with the type of shape (diamond)
                    shape = "diamond";
                    //Ident over the rows
                    for (int i = 1; i <= length; i++)
                    {
                        //Ident over the columns
                        for (int j = 1; j <= length; j++)
                        {
                            //First and last rows are border in the fifth column
                            if (i == 1 || i == 9)
                            {
                                if (j == 5)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                            }
                            //Second and eigth rows are border in the 4th and 6th columns, and inside otherwise
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
                            //Third and seventh rows are border in the 3th and 7th columns, and inside otherwise
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
                            //Sixth and fourth rows are border in the 2nd and 8th columns, and inside otherwise
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
                            //In the fifth row, first and ninth column are border and inside otherwise
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
                    //Set the name of the document with the type of shape (Heart)
                    shape = "Heart";
                    //Ident over the rows
                    for (int i = 1; i <= length; i++)
                    {
                        //Ident over the columns
                        for (int j = 1; j <= length; j++)
                        {
                            //First row has border in the 3rd, 4th, 6th and 7th columns
                            if (i == 1)
                            {
                                if (j == 3 || j == 4 || j == 6 || j == 7)
                                {
                                    newShape.SetCellStyle(i, j, border);
                                }
                            }
                            //Second row has border in the 2nd, 5th and 8th columns.And has inside in the 3rd, 4th, 6th and 7th columns
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
                            //Between rows 3 and 5 there is border in the 1st and 9th column and inside otherwise
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
                            //Sixth row has border in the 2nd and 8th columns, and inside otherwise
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
                            //Seventh row has border in the 3th and 7th columns, and inside otherwise
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
                            //Eigth row has border in the 4th and 6th columns, and inside otherwise
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
                            //Last rows has border in the fifth column
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
            
            //Create the path of the document with the shape name
            string path = $"H:\\Desarrollo Web Duodécimo\\Programación para web\\PRIMER SEMESTRE\\1 TAREA\\1Homework\\1Homework\\DataBase\\{shape}.xlsx";
           
            //Save the shape drawing
            newShape.SaveAs(path);
        }
    }
}