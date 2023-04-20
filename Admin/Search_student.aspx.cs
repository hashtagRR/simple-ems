using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam.Admin
{
    public partial class Search_student : System.Web.UI.Page
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
                SqlCommand sqlcmd = new SqlCommand("Select student_id as 'Student ID',full_name as 'Full name',nic_no as 'NIC No',tp as 'Contact',course as 'Course ID' FROM student ORDER BY course ASC", DBCon);
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
                Label1.Text = "Please insert the Student ID";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                string id = sid.Text;
                nic.Text = " ";

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Select student_id as 'Student ID',full_name as 'Full name',nic_no as 'NIC No',tp as 'Contact',course as 'Course ID' FROM student WHERE student_id='" + id + "'", DBCon);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dgv2.DataSource = reader;
                        dgv2.DataBind();
                        dgv2.Visible = true;
                        Label1.Text = " ";
                        Label2.Text = " ";
                    }
                    else
                    {
                        Label1.Text = "No records are avaliable for this Student ID";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (nic.Text == String.Empty)
            {
                Label2.Text = "Please insert the Student ID";
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                sid.Text = " ";
                string id = nic.Text;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Select student_id as 'Student ID',full_name as 'Full name',nic_no as 'NIC No',tp as 'Contact',course as 'Course ID' FROM student WHERE nic_no='" + id + "'", DBCon);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dgv2.DataSource = reader;
                        dgv2.DataBind();
                        dgv2.Visible = true;
                        Label1.Text = " ";
                        Label2.Text = " ";
                    }
                    else
                    {
                        Label2.Text = "Please insert the Student NIC No";
                        Label2.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
}