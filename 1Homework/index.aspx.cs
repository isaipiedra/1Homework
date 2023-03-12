using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using static System.Net.WebRequestMethods;
using System.IO.Packaging;

namespace _1Homework
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
            } catch 
            {
                videoTag.Attributes.Add("src", "https://www.youtube.com/embed/D7kz1LvX8vA");
            }
        }
    }
}