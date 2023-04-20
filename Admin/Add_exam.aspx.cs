using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam.Admin
{
    public partial class add_exam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select course_id,name FROM course ORDER BY name ASC", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sid = subid.Text;
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select subject_id,name FROM subject WHERE course_id='" + sid + "' ORDER BY name ASC", DBCon);
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
                    Label1.Text = "Course ID is incorrect";
                    Label1.ForeColor = System.Drawing.Color.Red;
                    dgv2.Visible = false;
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            cid.Text = String.Empty;
            name.Text = String.Empty;
            sid.Text = String.Empty;
           
            Label3.Text = " ";
            Label5.Text = " ";
            Label4.Text = " ";
            Label2.Text = " ";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (sid.Text== String.Empty)
            {
                Label2.Text = "Subject ID field cannot be empty";
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            else
                if(cid.Text== String.Empty)
            {
                Label5.Text = "Course ID field cannot be empty";
                Label5.ForeColor = System.Drawing.Color.Red;
            }
            else
                if(name.Text== String.Empty)
            {
                Label4.Text = "Exam name field cannot be empty";
                Label4.ForeColor = System.Drawing.Color.Red;
            }
           
            else
            {
                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();

                    SqlCommand cmd = new SqlCommand("spCountQuestions", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqpsid1 = new SqlParameter("@Subject_id", sid.Text);

                    cmd.Parameters.Add(sqpsid1);

                    int ReturnCode1 = (int)cmd.ExecuteScalar();

                    if (ReturnCode1 == -1)
                    {
                        Label3.Text = "No of questions on this subject is not enough to add new exam. There should be more than 15 questions to add new exam";
                        Label3.ForeColor = System.Drawing.Color.Red;
                        Label2.Text = " ";
                       
                    }
                    else
                    {
                        AddExam();
                       
                    }
                }
            }
        }
        public void AddExam()
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand cmd = new SqlCommand("spAddExam", DBCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqpcid = new SqlParameter("@Course_id", cid.Text);
                SqlParameter sqpname = new SqlParameter("@Name", name.Text);
                SqlParameter sqpsid = new SqlParameter("@Subject_id", sid.Text);
               

                cmd.Parameters.Add(sqpcid);
                cmd.Parameters.Add(sqpname);
                cmd.Parameters.Add(sqpsid);
               

                int ReturnCode = (int)cmd.ExecuteScalar();

                if (ReturnCode == 1)
                {
                    Label3.Text = "Exam added successfully";
                    Label3.ForeColor = System.Drawing.Color.Green;
                    Label2.Text = " ";
                   
                }
                else
                {
                    Label3.Text = "Failed to add the exam. Please try agin later";
                    Label3.ForeColor = System.Drawing.Color.Red;
                    Label2.Text = " ";
                    
                }
              

            }


        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            dgv1.Visible = false;
        }
    }
}