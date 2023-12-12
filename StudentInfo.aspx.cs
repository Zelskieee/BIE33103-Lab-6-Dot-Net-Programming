using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Lab5.MasterPages
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        private string connectionString = "Data Source=LAPTOP-BM8BRT21\\SQLEXPRESS; Initial Catalog=TestDatabase; Integrated Security=True; Pooling=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT id, name, course FROM Lab6", con);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    DataTable dt = new DataTable();

                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Any row data binding logic if needed
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int rowIndex;
                if (int.TryParse(e.CommandArgument.ToString(), out rowIndex))
                {
                    string id = GridView1.DataKeys[rowIndex]["id"].ToString();
                    lnkDelete("delete", id);
                    BindGrid();
                }
                else
                {
                    // Handle the case where the CommandArgument is not a valid integer
                    // You may log an error, display a message, or take appropriate action.
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex]["id"].ToString();
            lnkDelete("delete", id);
            BindGrid();
        }

        private void lnkDelete(string strAction, string id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd;

                    if (strAction == "delete")
                    {
                        cmd = new SqlCommand("DELETE FROM Lab6 WHERE id=@id", con);
                        cmd.Parameters.AddWithValue("@id", id);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                            lblStatus.Text = "Student info deleted successfully";
                        else
                            lblStatus.Text = "Error deleting student info";
                    }

                    // You can add more actions for other scenarios (update, insert, etc.) if needed

                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = GridView1.SelectedRow.Cells[0].Text;
            string ID = GridView1.SelectedRow.Cells[1].Text;
            string course = GridView1.SelectedRow.Cells[2].Text;

            Session["id"] = ID;
            Session["name"] = name;
            Session["course"] = course;

            Response.Redirect("Update.aspx");
        }

        protected void ButtonAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNew.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}
