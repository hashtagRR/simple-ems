using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Exam_lecturer.Lecturer
{
    public partial class Asnwer_sheet : System.Web.UI.Page
    {
        private String constr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        protected string[] Question_id = new string[15];
        protected string[] Correct_ans = new string[15];
        protected string[] Given_ans = new string[15];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lecturerisloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void ExamNameSelect()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                if (nic.Text == String.Empty)
                {
                    Label2.Text = "Please insert Student NIC No";
                    Label2.ForeColor = System.Drawing.Color.Red;
                    dgv1.Visible = false;
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT name FROM exam WHERE exam_id IN (SELECT exam_id FROM answer_sheet WHERE nic_no='" + nic.Text + "')"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        dl1.DataSource = reader;
                        if (reader.HasRows)
                        {
                            dl1.DataTextField = "Name";
                            dl1.DataBind();
                            Label2.Text = " ";
                        }
                        else
                        {
                            Label2.Text = "No records are avaliable for this Student NIC No";
                            Label2.ForeColor = System.Drawing.Color.Red;
                            dgv1.Visible = false;
                        }
                    }
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ExamNameSelect();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection DBCon = new SqlConnection(constr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("SELECT answer_sheet.question_id as 'Question ID', answer_sheet.given_answer as 'Given Answer', qna.correct_answer as 'Correct Answer' FROM answer_sheet LEFT JOIN qna ON answer_sheet.question_id = qna.question_id WHERE exam_id IN (SELECT exam_id FROM exam WHERE name='" + dl1.SelectedValue + "') ", DBCon);

                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
               
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (qid.Text == String.Empty)
            {
                Label1.Text = "Please insert Question ID";
                Label1.ForeColor = System.Drawing.Color.Red;
                dgv2.Visible = false;
            }
            else
            {
                using (SqlConnection DBCon = new SqlConnection(constr))
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