using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceDesk.Models;

namespace ServiceDesk.Views
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        Models.DBQueries Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.DBQueries();
            List.DataSource = Con.GetBrigads();
            List.DataBind();
        }
        protected void List_SelectedIndexChanged(object sender, EventArgs e)
        {
            Name.Value = List.SelectedRow.Cells[2].Text;
            Fio.Value = List.SelectedRow.Cells[3].Text;
            Kol.Value = List.SelectedRow.Cells[4].Text;
            Tel.Value = List.SelectedRow.Cells[5].Text;
        }
        protected void delete_Click(object sender, EventArgs e)
        {
            Con = new Models.DBQueries();
            int id = Convert.ToInt32(List.SelectedRow.Cells[1].Text);
            Con.DeleteBrigads(id);
            label.Text = "Бригада удалена!";
            List.DataSource = Con.GetBrigads();
            List.DataBind();
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            string name = Name.Value;
            string fio = Fio.Value;
            int kol = Convert.ToInt32(Kol.Value);
            string tel = Tel.Value;
            Con = new Models.DBQueries();
            Con.EditBrigads(name, fio, kol, tel, Convert.ToInt32(List.SelectedRow.Cells[1].Text));
            List.DataSource = Con.GetBrigads();
            List.DataBind();
        }
        protected void add_Click(object sender, EventArgs e)
        {
            try
            {
                string name = Name.Value;
                string fio = Fio.Value;
                int kol = Convert.ToInt32(Kol.Value);
                string tel = Tel.Value;
                Con = new Models.DBQueries();
                Con.AddBrigads(name, fio, kol, tel);
                List.DataSource = Con.GetBrigads();
                List.DataBind();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }



    }
}