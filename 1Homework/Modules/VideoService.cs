using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1Homework.Modules
{
    public class VideoService
    {
        public string loadVideo(string videoUrl)
        {
            //Try catch sentence to validate that the youtube link is correct
            try
            {
                //Create the new embed url
                string newUrl = "https://www.youtube.com/embed/";

                //Variable for the portion of the specific YT URL
                string portion = "";

                //Capture the users entered URL
                string url = videoUrl;

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
                if (newUrl.Contains("start") || newUrl.Contains("index") || (string.IsNullOrEmpty(url)))
                {
                    //If the URL is a Mix return the default URL
                    return "https://www.youtube.com/embed/D7kz1LvX8vA";
                }
                else
                {
                    //Change the default URL for the users provided video
                    return newUrl;
                }
            }
            //If the URL was not allowed returns the default URL
            catch
            {
                return "https://www.youtube.com/embed/D7kz1LvX8vA";
            }
        }
    }
}