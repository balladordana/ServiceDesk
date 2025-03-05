using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceDesk.Views
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        Models.DBQueries Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.DBQueries();
            List.DataSource = Con.GetClients();
            List.DataBind();
        }
        protected void List_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fam.Value = List.SelectedRow.Cells[2].Text;
            Name.Value = List.SelectedRow.Cells[3].Text;
            Otch.Value = List.SelectedRow.Cells[4].Text;
            Address.Value = List.SelectedRow.Cells[5].Text;
        }
        protected void delete_Click(object sender, EventArgs e)
        {
            Con = new Models.DBQueries();
            int id = Convert.ToInt32(List.SelectedRow.Cells[1].Text);
            Con.DeleteClients(id);
            label.Text = "Клиент удален!";
            List.DataSource = Con.GetClients();
            List.DataBind();
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            string fam = Fam.Value;
            string name = Name.Value;
            string otch = Otch.Value;
            string add = Address.Value;
            Con = new Models.DBQueries();
            Con.EditClients(fam, name,  otch, add, Convert.ToInt32(List.SelectedRow.Cells[1].Text));
            List.DataSource = Con.GetClients();
            List.DataBind();
        }
        protected void add_Click(object sender, EventArgs e)
        {
            try
            {
                string name = Name.Value;
                string fam = Fam.Value;
                string otch = Otch.Value;
                string add = Address.Value;
                Con = new Models.DBQueries();
                Con.AddClients(name, fam, otch, add);
                List.DataSource = Con.GetClients();
                List.DataBind();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}