using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceDesk.Views
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        Models.DBQueries Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.DBQueries();
            if (!Page.IsPostBack)
            {
                
                List.DataSource = Con.GetApplicationsZamer();
                List.DataBind();
                DropDownList5.DataSource = Con.GetStatuses();
                DropDownList5.DataBind();
                GridView7.DataSource = Con.GetFired();
                GridView7.DataBind();
            }
        }
        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            string date = Calendar1.SelectedDate.ToShortDateString();
            Con = new Models.DBQueries();
            GridView2.DataSource= Con.GetTime(date);
            GridView2.DataBind();
            
        }

        protected void add_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            DropDownList1.DataSource = Con.GetConstructions();
            DropDownList1.DataBind();
            DropDownList2.DataSource = Con.GetTypes();
            DropDownList2.DataBind();
        }
        protected void Reklama(object sender, EventArgs e)
        {
            Con = new Models.DBQueries();
            int state = Convert.ToInt32(StateHiddenField.Value);
            if (state == 0)
            {
                List.DataSource = Con.GetReklamaApplications();
                List.DataBind();
                state = 1;
            }
            else
            {
                List.DataSource = Con.GetApplicationsZamer();
                List.DataBind();
                state = 0;
            }
            StateHiddenField.Value = state.ToString();
        }
        protected void Sort(object sender, EventArgs e)
        {
            Con = new Models.DBQueries();
            int state = Convert.ToInt32(HiddenField1.Value);
            if (state == 0)
            {
                List.DataSource = Con.GetSortApplications();
                List.DataBind();
                state = 1;
            }
            else
            {
                List.DataSource = Con.GetApplicationsZamer();
                List.DataBind();
                state = 0;
            }
            HiddenField1.Value = state.ToString();
        }
        protected void Filter(object sender, EventArgs e)
        {
            List.DataSource = Con.GetFilterApplications(DropDownList5.Items[DropDownList5.SelectedIndex].ToString());
            List.DataBind();
        }
        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModalPopupExtender4.Show();
        }
        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModalPopupExtender4.Show();
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModalPopupExtender2.Show();
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }
        protected void selectApplication(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            if (List.SelectedRow.Cells[7].Text.ToString() == "Обращение")
            {
                GridView1.DataSource = Con.GetApplication(List.SelectedRow.Cells[1].Text.ToString());
                GridView1.DataBind();
                DropDownList3.DataSource = Con.GetSotrudniki();
                DropDownList3.DataBind();
                ModalPopupExtender2.Show();
            }
            else if (List.SelectedRow.Cells[7].Text.ToString() == "Замер")
            {
                GridView3.DataSource = Con.GetApplication(List.SelectedRow.Cells[1].Text.ToString());
                GridView3.DataBind();
                ModalPopupExtender3.Show();
            }
            else if (List.SelectedRow.Cells[7].Text.ToString() == "В работе" || List.SelectedRow.Cells[7].Text.ToString() == "Просрочено")
            {
                GridView4.DataSource = Con.GetApplication(List.SelectedRow.Cells[1].Text.ToString());
                GridView4.DataBind();
                DropDownList4.DataSource = Con.GetWorks();
                DropDownList4.DataBind();
                DropDownList6.DataSource = Con.GetBrigadsName();
                DropDownList6.DataBind();
                GridView5.DataSource = Con.GetAllWorks(GridView4.Rows[0].Cells[0].Text,
                    DropDownList4.Items[DropDownList4.SelectedIndex].ToString());
                GridView5.DataBind();
                ModalPopupExtender4.Show();
            }
            else if (List.SelectedRow.Cells[7].Text.ToString() == "Запланировано")
            {
                GridView6.DataSource = Con.GetApplication(List.SelectedRow.Cells[1].Text.ToString());
                GridView6.DataBind();
                ModalPopupExtender5.Show();
            }
            else
            {
                GridView8.DataSource = Con.GetApplication(List.SelectedRow.Cells[1].Text.ToString());
                GridView8.DataBind();
                ModalPopupExtender6.Show();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Con.SetResponsible(DropDownList3.Items[DropDownList3.SelectedIndex].ToString(), GridView1.Rows[0].Cells[0].Text);
            List.DataSource = Con.GetApplicationsZamer();
            List.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Con.SetComment(GridView3.Rows[0].Cells[0].Text, TextBox1.Text);
            List.DataSource = Con.GetApplicationsZamer();
            List.DataBind();
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            int check = Con.GetAllWorksTime(GridView4.Rows[0].Cells[0].Text, DropDownList6.Items[DropDownList6.SelectedIndex].ToString(),
                TextBox7.Text, TextBox8.Text, Con.GetAllWorksTime(GridView4.Rows[0].Cells[0].Text));
            if (check == 1) { Label21.Visible = true; Label21.Text = "Это время уже занято!"; ModalPopupExtender4.Show(); }
            List.DataSource = Con.GetApplicationsZamer();
            List.DataBind();
        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            Con.SetAllWorks(GridView4.Rows[0].Cells[0].Text, 
                DropDownList4.Items[DropDownList4.SelectedIndex].ToString(), Convert.ToInt32(TextBox9.Text));
            GridView5.DataSource = Con.GetAllWorks(GridView4.Rows[0].Cells[0].Text,
                    DropDownList4.Items[DropDownList4.SelectedIndex].ToString());
            GridView5.DataBind();
            ModalPopupExtender4.Show();
        }
        protected void Button12_Click(object sender, EventArgs e)
        {
            Con.SetStatus(GridView6.Rows[0].Cells[0].Text, 5);
            List.DataSource = Con.GetApplicationsZamer();
            List.DataBind();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Con.CheckExpired(); 
            List.DataSource = Con.GetApplicationsZamer();
            List.DataBind();
        }

        protected void GridView2_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    string app = GridView2.Rows[i].Cells[j].Text;
                    if (app != "")
                    {
                        string status = Con.GetStatus(app);
                        switch (status)
                        {
                            case "Замер":
                                GridView2.Rows[i].Cells[j].BackColor = Color.Orange; break;
                            case "Выполнено":
                                GridView2.Rows[i].Cells[j].BackColor = Color.Green; break;
                            case "Просрочено":
                                GridView2.Rows[i].Cells[j].BackColor = Color.DarkRed; break;
                            case "Запланировано":
                                GridView2.Rows[i].Cells[j].BackColor = Color.LightBlue; break;
                        }
                    }
                }
            }
        }
    }

}
