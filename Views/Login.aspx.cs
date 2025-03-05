using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceDesk.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Models.DBQueries Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.DBQueries();
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string login = Login.Value;
            string pass = Password.Value;
            Session.Add("loginID", Con.LoginID(login, pass));
            try
            {
                string dos = Con.Login(login, pass);
                if (dos == "Диспетчер")
                {
                    Response.Redirect("/Views/MainDispetcher.aspx");
                }
                else if (dos == "Менеджер по продажам")
                {
                    Response.Redirect("/Views/MainManager.aspx");
                }
                else if (dos == "Специалист-замерщик")
                {
                    Response.Redirect("/Views/MainSpecialist.aspx");
                }
            }
            catch
            {
                Label1.Text = "Неправильный логин или пароль!";
            }
        }
    }
}