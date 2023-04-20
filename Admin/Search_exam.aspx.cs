using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;


namespace Exam.Admin
{
    public partial class Search_exam : System.Web.UI.Page
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
        public void ViewAll()
        {
            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select exam_id as 'Exam ID',name as 'Exam name',subject_id as 'Subject ID',course_id as 'Course ID' FROM exam ORDER BY subject_id", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (sid.Text == String.Empty)
            {
                Label1.Text = "Please insert the Subject ID";
                Label1.ForeColor = System.Drawing.Color.Red;
                dgv2.Visible = false;
            }
            else
            {
                string id = sid.Text;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Select exam_id as 'Exam ID',course_id as 'Course ID',subject_id as 'Subject ID',name as 'Name' FROM exam WHERE subject_id='" + id + "' ", DBCon);
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
                        Label1.Text = "No exams avalible for this  subject";
                        Label1.ForeColor = System.Drawing.Color.Red;
                        dgv2.Visible = false;
                    }
                }
            }
        }
    }
}