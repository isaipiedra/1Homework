using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1Homework.Modules
{
    public class LoginService
    {
        public string submitLogin(string username, string password)
        {
            //Validate the given credentials
            bool validate = Validate(username, password);

            //if validation was successful redirect to index / else show an error message
            if (validate)
            {
                return "/index.aspx";
            }
            else
            {
                return $"<h1 class=\"position-absolute text-danger\">ERROR</h1>";
            }
        }

        //Function ment to validate the credentials
        protected bool Validate(string username, string password)
        {
            //Variable declarations for checking the credentials
            int rowI = 2;
            bool userNameCheck = false, passwordCheck = false;

            //Data base path
            string path = "G:\\Desarrollo Web Duodécimo\\Programación para web\\PRIMER SEMESTRE\\1 TAREA\\1Homework\\DataBase\\users.xlsx";

            //Open the data base
            SLDocument dataBase = new SLDocument(path);

            //Check if username is registered
            while (!string.IsNullOrEmpty(dataBase.GetCellValueAsString(rowI, 1)))
            {
                //Check that the username provided is inside of the database
                if (dataBase.GetCellValueAsString(rowI, 1) == username)
                {
                    userNameCheck = true;
                    break;
                }
                rowI++;
            }

            //Check if the password is registered and match with the user
            if (dataBase.GetCellValueAsString(rowI, 2) == password)
            {
                passwordCheck = true;
            }

            //Return the final validation
            return (userNameCheck && passwordCheck);
        }
    }
}