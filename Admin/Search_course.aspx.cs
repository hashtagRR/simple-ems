using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam.Admin
{
    public partial class Search_course : System.Web.UI.Page
    {
        private String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ViewAll();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (cid.Text == String.Empty)
            {
                Label1.Text = "Please insert the Course ID";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                string id = cid.Text;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Select * FROM course WHERE course_id='" + id + "' ORDER BY name ASC", DBCon);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dgv2.DataSource = reader;
                        dgv2.DataBind();
                        dgv2.Visible = true;
                        Label1.Text = " ";
                    }
                    else
                    {
                        Label1.Text = "No records are avaliable for this Course ID";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        public void ViewAll()
        {
            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select * FROM course ORDER BY name ASC", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            dgv2.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (cid2.Text == String.Empty)
            {
                Label2.Text = "Please insert the Course ID";
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                string id = cid2.Text;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Select subject_id,name,description FROM subject WHERE course_id='" + id + "' ORDER BY name ASC", DBCon);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dgv3.DataSource = reader;
                        dgv3.DataBind();
                        dgv3.Visible = true;
                        Label2.Text = " ";
                    }
                    else
                    {
                        Label2.Text = "No records are avaliable for this Course ID";
                        Label2.ForeColor = System.Drawing.Color.Red;
                    }
                }
                
            }
        }
    }
}