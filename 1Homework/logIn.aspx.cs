using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpreadsheetLight;

namespace _1Homework
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void submitLogIn_Click(object sender, EventArgs e)
        {
            //Validate the given credentials
            bool validate = Validate(username.Text.Trim(), password.Text.Trim());

            //if validation was successful redirect to index / else show an error message
            if (validate)
            {
                Response.Redirect("/index.aspx");
            } else
            {
                Response.Write($"<h1 class=\"position-absolute text-danger\">ERROR</h1>");
            }
        }

        //Function ment to validate the credentials
        protected bool Validate(string username, string password)
        {
            //Variable declarations for checking the credentials
            int rowI = 2;
            bool userNameCheck = false, passwordCheck = false;

            //Data base path
            string path = "D:\\Desarrollo Web Duodécimo\\Programación para web\\PRIMER SEMESTRE\\1 TAREA\\1Homework\\1Homework\\DataBase\\users.xlsx";

            //Open the data base
            SLDocument dataBase = new SLDocument(path);

            //Check if username is registered
            while (!string.IsNullOrEmpty(dataBase.GetCellValueAsString(rowI, 1)))
            {
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