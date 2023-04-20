using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam.Admin
{
    public partial class Manage_exam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            eid.Text = " ";
            sid.Text = " ";
            cid.Text = " ";
            na.Text = " ";
            Label2.Text = " ";
            Label3.Text = " ";
            Labelcid.Text = " ";
            Labelname.Text = " ";
            Labelsid.Text = " ";
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            if (eid.Text == String.Empty)
            {
                Label2.Text = "Exam ID field cannot be empty";
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            else
           if (sid.Text == String.Empty)
            {
                Labelsid.Text = "Subject ID field cannot be empty";
                Labelsid.ForeColor = System.Drawing.Color.Red;
            }
            else
            if (cid.Text == String.Empty)
            {
                Labelcid.Text = "Course ID field cannot be empty";
                Labelcid.ForeColor = System.Drawing.Color.Red;
            }
            else
            if (na.Text == String.Empty)
            {
                Labelname.Text = "Exam name field cannot be empty";
                Labelname.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("spUpdExam", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqpeid = new SqlParameter("@Exam_id", eid.Text);
                    SqlParameter sqpcid = new SqlParameter("@Course_id", cid.Text);
                    SqlParameter sqpsid = new SqlParameter("@Subject_id", sid.Text);
                    SqlParameter sqpname = new SqlParameter("@Name", na.Text);

                    cmd.Parameters.Add(sqpcid);
                    cmd.Parameters.Add(sqpname);
                    cmd.Parameters.Add(sqpsid);

                    cmd.Parameters.Add(sqpeid);

                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Label3.Text = "Exam updated successfully";
                        Label3.ForeColor = System.Drawing.Color.Green;
                        Label2.Text = " ";

                        Labelcid.Text = " ";
                        Labelname.Text = " ";
                        Labelsid.Text = " ";
                    }
                    else
                    if (ReturnCode == -1)
                    {
                        Label3.Text = "Failed to update the exam. Exam ID is incorrect";
                        Label3.ForeColor = System.Drawing.Color.Red;
                        Label2.Text = " ";

                        Labelcid.Text = " ";
                        Labelname.Text = " ";
                        Labelsid.Text = " ";
                    }
                }
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            if (eid.Text == String.Empty)
            {
                Label2.Text = "Exam ID field cannot be empty";
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("spRemoveExam", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqpeid = new SqlParameter("@Exam_id", eid.Text);

                    cmd.Parameters.Add(sqpeid);

                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Label3.Text = "Exam cancelled successfully";
                        Label3.ForeColor = System.Drawing.Color.Green;
                        Label2.Text = " ";

                        Labelcid.Text = " ";
                        Labelname.Text = " ";
                        Labelsid.Text = " ";
                    }
                    else
                    if (ReturnCode == -1)
                    {
                        Label3.Text = "Failed to cancel the exam.Exam ID is incorrect";
                        Label3.ForeColor = System.Drawing.Color.Red;
                        Label2.Text = " ";

                        Labelcid.Text = " ";
                        Labelname.Text = " ";
                        Labelsid.Text = " ";
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select exam_id as 'Exam ID',name as 'Exam name',subject_id as 'Subject ID',course_id as 'Course ID' FROM exam ORDER BY name ASC", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string id = eid.Text;
            int n;
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                if (int.TryParse(eid.Text, out n) == false)
                {
                    Label2.Text = "Exam ID is not in the correct format";
                    Label2.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    String sql = "SELECT name,subject_id,course_id FROM exam WHERE exam_id='" + id + "'";
                    SqlCommand comm = new SqlCommand(sql, DBCon);
                    DBCon.Open();
                    SqlDataReader nwReader = comm.ExecuteReader();
                    if (nwReader.HasRows)
                    {
                        while (nwReader.Read())
                        {
                            na.Text = (string)nwReader["name"];
                            sid.Text = (string)nwReader["subject_id"];
                            cid.Text = (string)nwReader["course_id"];
                        }
                        Label2.Text = " ";
                        Label3.Text = " ";

                        Labelcid.Text = " ";
                        Labelname.Text = " ";
                        Labelsid.Text = " ";
                    }
                    else
                    {
                        Label2.Text = "Exam ID is incorrect";
                        Label2.ForeColor = System.Drawing.Color.Red;
                    }
                    nwReader.Close();
                    DBCon.Close();
                }
            }
        }
    }
}