using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab5.MasterPages
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    txtbox_ID.Text = Session["id"].ToString();
                }

                if (Session["name"] != null)
                {
                    txtbox_name.Text = Session["name"].ToString();
                }

                if (Session["course"] != null)
                {
                    string courseText = Session["course"].ToString();
                    ListItem item = ddl_Course.Items.FindByText(courseText);

                    if (item != null)
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        // Handle the case where the course is not found in the dropdown list
                    }
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Update_DB("update");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            txtbox_ID.Text = Session["id"].ToString();
            txtbox_name.Text = Session["name"].ToString();
            ddl_Course.SelectedItem.Selected = false;
            ddl_Course.Items.FindByText(Session["course"].ToString()).Selected = true;
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            Update_DB("delete");
        }

        protected void Update_DB(String strAction)
        {
            string ID = txtbox_ID.Text.Trim();
            string name = txtbox_name.Text;
            //DateTime now = DateTime.Now;
            string course = ddl_Course.SelectedItem.Text;

            SqlConnection con = new SqlConnection
            ("Data Source = LAPTOP-BM8BRT21\\SQLEXPRESS; Initial Catalog = TestDatabase;   Integrated Security = True; Pooling = False");

            //SqlCommand com = new SqlCommand();
            try
            {
                con.Open();

                SqlCommand cmd;

                if (strAction == "update")
                {
                    cmd = new SqlCommand("UPDATE Lab6 SET name='" + name + "', course='" + course + "' WHERE id='" + ID + "'", con);

                    int result = cmd.ExecuteNonQuery();  //to execute the SQL command

                    if (result > 0)
                        lblStatus.Text = "Student info updated successfully";
                }
                else if (strAction == "delete")
                {
                    cmd = new SqlCommand("DELETE FROM Lab6 WHERE id='" + ID + "'", con);

                    int result = cmd.ExecuteNonQuery();  //to execute the SQL command

                    if (result > 0)
                        lblStatus.Text = "Student info deleted successfully";
                    txtbox_ID.Text = "";
                    txtbox_name.Text = "";
                    txtbox_ID.Enabled = false;
                    txtbox_name.Enabled = false;
                    ddl_Course.Enabled = false;
                    ButtonSave.Enabled = false;
                    ButtonDelete.Enabled = false;
                    ButtonCancel.Enabled = false;

                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }
            finally
            {
                con.Close();

            }
        }

        protected void txtbox_name_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }
    }
}