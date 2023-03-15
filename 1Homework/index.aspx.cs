using _1Homework.Modules;
using SpreadsheetLight;
using System;

namespace _1Homework
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loadVideo_Click(object sender, EventArgs e)
        {
            //Instance of the video service 
            VideoService newVideo = new VideoService();
            //Gets the video url
            string url = newVideo.loadVideo(videoUrl.Text.Trim());

            //If the url is the default, alerts the user that the provided URL was not correct
            if (url == "https://www.youtube.com/embed/D7kz1LvX8vA")
            {
                videoTag.Attributes.Add("src", url);
            } 
            //Otherwise, it loads the users video
            else
            {
                videoTag.Attributes.Add("src", url);
            }

            //Collapse everything but the current section
            videoCollapse.Attributes.Add("class", "mt-3 collapse show");
            drawingCollapse.Attributes.Add("class", "mt-3 p-1 collapse hidden");
            gameCollapse.Attributes.Add("class", "mt- 3 collapse hidden");
        }

        protected void generateGame_Click(object sender, EventArgs e)
        {
            //Hide the game generator and show the game
            generateGame.Visible = false;
            gameDisplay.Visible = true;

            //Start the players opportunities (6)
            opportunities.Text = "6";

            //Generate a random number between 2 and 26 to choose a word randomly
            Random random = new Random();
            int randomPosition = random.Next(2, 26);

            //Opens the excel document with the word database
            SLDocument words = new SLDocument("G:\\Desarrollo Web Duodécimo\\Programación para web\\PRIMER SEMESTRE\\1 TAREA\\1Homework\\DataBase\\hangmanWords.xlsx");
            
            //Set the value of the label showing the word to a randomly picked one
            string value = words.GetCellValueAsString(randomPosition, 1).ToUpper();
            //Create a string for storing the spaces
            string spaces = string.Empty;

            //Set the spaces for the user to complete the word
            for (int i = 0; i < value.Length; i++)
            {
                spaces += "_";
            }

            //Add the spaces to the corresponding label
            word.Text = spaces;
            //Add the randomly picked word to the value of the label (evaluation purposes)
            word.Attributes.Add("value", value);

            //Hide the results of the last game
            results.Visible = false;
            //Show the user the amount of letters that the word has
            letterNum.Text = $"({value.Length})";

            //Collapse everything but the current section
            gameCollapse.Attributes.Add("class", "collapse show");
            drawingCollapse.Attributes.Add("class", "mt-3 p-1 collapse");
            videoCollapse.Attributes.Add("class", "mt-3 collapse hidden");
        }

        protected void guessLetter_Click(object sender, EventArgs e)
        {
            //Read the amount of opportunities as an integer (evaluation purposes)
            int oppNum = Convert.ToInt32(opportunities.Text);

            GameService newLetterGuess = new GameService();
            string [] cases = newLetterGuess.guessLetter(oppNum, (letterGuessed.Text.Trim()).ToUpper(), word.Attributes["value"], word.Text);

            if (cases[0] == "false" && cases[1] == "false")
            {
                //Hide the game, show the results and show the game generator
                generateGame.Visible = true;
                gameDisplay.Visible = false;
                results.Visible = true;

                //Add the results to the page
                results.Attributes.Add("class", "d-inline-block me-3 mt-3 text-danger fw-bold fs-3 bg-light bg-opacity-50 p-2 rounded");
                results.Text = $"Try again! You didn't guessed it correctly, the word was: \"{word.Attributes["value"]}\"";
            } 
            else if (cases[0] == "false" && cases[1] == "true")
            {
                chance.Attributes["class"] += "text-danger fw-bold";
                chance.Text = "That's not correct";
                //Less the opportunities
                opportunities.Text = Convert.ToString(oppNum - 1);
            } 
            else if (cases[0] == "true" && cases[1] == "true") {
                //Hide the game, show the results and show the game generator
                generateGame.Visible = true;
                gameDisplay.Visible = false;
                results.Visible = true;

                //Add the results to the page
                results.Attributes.Add("class", "d-inline-block me-3 mt-3 text-success fw-bold fs-3 bg-light bg-opacity-50 p-2 rounded");
                results.Text = $"Congratulations! You won this round, with the world \"{word.Attributes["value"]}\"";
            } 
            else if (cases[0] == "null")
            {
                chance.Attributes["class"] += "text-danger fw-bold";
                chance.Text = "That's not correct. Please enter a letter!";

                //Less the opportunities
                opportunities.Text = Convert.ToString(oppNum - 1);
            }
            else
            {
                //Change the last spaces to the new word made out of letters and spaces
                word.Text = cases[1];
                //Notifies the user that the letter was correct
                chance.Attributes["class"] += "text-success fw-bold";
                chance.Text = "You guessed a letter!";
                //Show the same opportunities
                opportunities.Text = Convert.ToString(oppNum);
            }

            //Delete the user last input
            letterGuessed.Text = string.Empty;

            //Collapse everything but the current section
            gameCollapse.Attributes.Add("class", "collapse show");
            drawingCollapse.Attributes.Add("class", "mt-3 p-1 collapse");
            videoCollapse.Attributes.Add("class", "mt-3 collapse hidden");
        }

        protected void shapeDraw_Click(object sender, EventArgs e)
        {
            //Instance of the drawing service 
            DrawingService drawingService = new DrawingService();
            //Draws the shape depending on the color picked
            drawingService.drawShape((shapeSelector.Value), (colorPicker.Value));

            //Collapse everything but the current section
            videoCollapse.Attributes.Add("class", "mt-3 collapse hidden");
            drawingCollapse.Attributes.Add("class", "mt-3 p-1 collapse show");
            gameCollapse.Attributes.Add("class", "mt- 3 collapse hidden");
        }
    }
}