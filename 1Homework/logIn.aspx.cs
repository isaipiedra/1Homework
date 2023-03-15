using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _1Homework.Modules;
using DocumentFormat.OpenXml.ExtendedProperties;
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
            //Instance of the login module
            LoginService newLogIn = new LoginService();
            //Response of the validation
            string response = newLogIn.submitLogin(username.Text.Trim(), password.Text.Trim());

            //If the response was the url of the index then redirect
            if (response.Contains("aspx"))
            {
                //Manages that the first event is the alert an then the redirect
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                $"alert('Provided credentials were correct. Redirecting...'); window.location = '{response}';",
                true);
            }
            //Else let the user now credentials were not valid
            else
            {
                credentialAlert.Attributes["class"] = "alert alert-danger show";
                errorMsg.Text = response;
            }
        }

        
    }
}       