using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1Homework.Modules
{
    public class GameService
    {
        public string[] guessLetter(int oppNum, string letterGuessed, string hangman, string word)
        {

            //Try catch sentence to evaluate if the text entered by the user is a letter
            try
            {
                //Convert the input written by the user to char
                char letter = Convert.ToChar(letterGuessed);

                //Create a string for the letters + spaces
                string newWord = string.Empty;

                //For loop to generate the new string with letters guessed + spaces
                for (int i = 0; i < hangman.Length; i++)
                {
                    //If there is an existing letter add it to the string
                    if (word[i] != Convert.ToChar("_"))
                    {
                        newWord += word[i];
                    }
                    //Else, if the letter is part of the word add it to the string
                    else if (letter == hangman[i])
                    {
                        newWord += letter;
                    }
                    //Otherwise, add a space
                    else
                    {
                        newWord += "_";
                    }
                }

                //If the user did not provide a correct letter they are notified...
                if (newWord == word)
                {
                    //If there is no more opportunities the user loses
                    if (oppNum - 1 <= 0)
                    {
                        string[] array = new string[2];
                        array[0] = "false";
                        array[1] = "false";
                        return array;
                    }
                    //Otherwise, the user is notified to choose another letter
                    else
                    {
                        string[] array = new string[2];
                        array[0] = "false";
                        array[1] = "true";
                        return array;
                    }
                }
                //Else, if the user provided a correct letter they are notified...
                else
                {
                    string[] array = new string[2];
                    array[0] = "true";
                    
                    //If the word is completed
                    if (newWord == hangman)
                    {
                        array[1] = "true";
                    } 
                    //Otherwise
                    else
                    {
                        array[1] = newWord;
                    }

                    return array;
                }
            }
            //If the user entered more than a letter
            catch
            {
                //If there is no more opportunities the user loses
                if (oppNum - 1 <= 0)
                {
                    string[] array = new string[2];
                    array[0] = "false";
                    array[1] = "false";
                    return array;
                }
                //Else, if the user guessed the full word correctly
                else if (letterGuessed == hangman)
                {
                    string[] array = new string[2];
                    array[0] = "true"; 
                    array[1] = "true";
                    return array;
                }
                //Otherwise, the user is notified to choose another letter
                else
                {
                    string[] array = new string[1];
                    array[0] = "null";
                    return array;
                }
            }
        }
    }
}