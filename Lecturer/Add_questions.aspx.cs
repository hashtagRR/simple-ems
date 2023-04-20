using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam_lecturer.Lecturer
{
    public partial class Add_questions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lecturerisloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            if (sid.Text == String.Empty)
            {
                Label2.Text = "Subject ID field cannot be empty";
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            else
            if (q.Text == String.Empty)
            {
                Labelq.Text = "Question field cannot be empty";
                Labelq.ForeColor = System.Drawing.Color.Red;
            }
            else
            if (a1.Text == String.Empty)
            {
                Labela1.Text = "Answer 1 field cannot be empty";
                Labela1.ForeColor = System.Drawing.Color.Red;
            }
            else
            if (a2.Text == String.Empty)
            {
                Labela2.Text = "Answer 2 field cannot be empty";
                Labela2.ForeColor = System.Drawing.Color.Red;
            }
            else
            if (a3.Text == String.Empty)
            {
                Labela3.Text = "Answer 3 field cannot be empty";
                Labela3.ForeColor = System.Drawing.Color.Red;
            }
            else
            if (a4.Text == String.Empty)
            {
                Labela4.Text = "Answer 4 field cannot be empty";
                Labela4.ForeColor = System.Drawing.Color.Red;
            }
            else
            if (cor.Text == String.Empty)
            {
                Labelca.Text = "Correct answer no field cannot be empty";
                Labelca.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                String id = sid.Text;
                String qs = q.Text;
                String an1 = a1.Text;
                String an2 = a2.Text;
                String an3 = a3.Text;
                String an4 = a4.Text;
                String ca = cor.Text;

                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("spAddQs", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqpsid = new SqlParameter("@Subject_id", id);
                    SqlParameter sqpq = new SqlParameter("@Question", qs);
                    SqlParameter sqpa1 = new SqlParameter("@Answer_1", an1);
                    SqlParameter sqpa2 = new SqlParameter("@Answer_2", an2);
                    SqlParameter sqpa3 = new SqlParameter("@Answer_3", an3);
                    SqlParameter sqpa4 = new SqlParameter("@Answer_4", an4);
                    SqlParameter sqpca = new SqlParameter("@Correct_answer", ca);

                    cmd.Parameters.Add(sqpsid);
                    cmd.Parameters.Add(sqpq);
                    cmd.Parameters.Add(sqpa1);
                    cmd.Parameters.Add(sqpa2);
                    cmd.Parameters.Add(sqpa3);
                    cmd.Parameters.Add(sqpa4);
                    cmd.Parameters.Add(sqpca);

                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Label3.Text = "Question added successfully";
                        Label3.ForeColor = System.Drawing.Color.Green;
                        Label2.Text = " ";
                        Labelq.Text = " ";
                        Labela1.Text = " ";
                        Labela2.Text = " ";
                        Labela3.Text = " ";
                        Labela4.Text = " ";
                        Labelca.Text = " ";
                    }
                    else
                    if (ReturnCode == -1)
                    {
                        Label3.Text = "Failed. Question have alradey added to the database";
                        Label3.ForeColor = System.Drawing.Color.Red;
                        Label2.Text = " ";
                        Labelq.Text = " ";
                        Labela1.Text = " ";
                        Labela2.Text = " ";
                        Labela3.Text = " ";
                        Labela4.Text = " ";
                        Labelca.Text = " ";
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select subject_id,name FROM subject ORDER BY name ASC;", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            sid.Text = String.Empty;
            q.Text = String.Empty;
            a1.Text = String.Empty;
            a2.Text = String.Empty;
            a3.Text = String.Empty;
            a4.Text = String.Empty;
            cor.Text = String.Empty;

            Label2.Text = " ";
            Label3.Text = " ";
            Labelq.Text = " ";
            Labela1.Text = " ";
            Labela2.Text = " ";
            Labela3.Text = " ";
            Labela4.Text = " ";
            Labelca.Text = " ";
        }
    }
}