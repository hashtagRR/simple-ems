using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam.Admin
{
    public partial class Search_question : System.Web.UI.Page
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
            String sid = id.Text;
            if (id.Text == String.Empty)
            {
                Label2.Text = "Please insert the Subject ID";
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Select question_id as 'Question ID',question as 'Question' FROM qna WHERE subject='" + sid + "';", DBCon);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dgv1.DataSource = reader;
                        dgv1.DataBind();
                        dgv1.Visible = true;
                        Label2.Text=" ";
                    }
                    else
                    {
                        Label2.Text = "No questions are avaliable for this Subject ID";
                        Label2.ForeColor = System.Drawing.Color.Red;
                        dgv1.Visible = false;
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int n;

            if (qid.Text == String.Empty)
            {
                Label1.Text = "Please insert the Subject ID";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            if (int.TryParse(qid.Text, out n) == false)
            {
                Label1.Text = "Question ID is not in the correct format";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("SELECT question as 'Question',answer_1 as 'Answer 1',answer_2 as 'Answer 2',answer_3 as 'Answer 3',answer_4 as 'Answer 4',correct_answer as 'Correct Answer' FROM qna WHERE question_id='" + qid.Text + "' ", DBCon);
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
                        Label1.Text = "Question ID is incorrect";
                        Label1.ForeColor = System.Drawing.Color.Red;
                        dgv2.Visible = false;
                    }
                }
            }
        }
    }
}