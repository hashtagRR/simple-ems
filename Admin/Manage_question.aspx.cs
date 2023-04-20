using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam.GUI
{
    public partial class Edit_question : System.Web.UI.Page
    {
        private int n;

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
                Label1.Text = "Please insert the Subject ID";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Select question_id,question FROM qna WHERE subject='" + sid + "';", DBCon);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dgv1.DataSource = reader;
                        dgv1.DataBind();
                        dgv1.Visible = true;
                        Label1.Text = " ";
                    }
                    else
                    {
                        Label1.Text = "No questions are avaliable for this Subject Id";
                        Label1.ForeColor = System.Drawing.Color.Red;
                        dgv1.Visible = false;
                    }
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (qid.Text == String.Empty)
            {
                Labelqid.Text = "Question ID cannot be empty";
                Labelqid.ForeColor = System.Drawing.Color.Red;
            }
            else
                if (que.Text == String.Empty)
            {
                Labelq.Text = "Question cannot be empty";
                Labelq.ForeColor = System.Drawing.Color.Red;
            }
            else
                if (sub.Text == String.Empty)
            {
                Labelsid.Text = "Subject ID cannot be empty";
                Labelsid.ForeColor = System.Drawing.Color.Red;
            }
            else
                if (a1.Text == String.Empty)
            {
                Labela1.Text = "Answer 1 cannot be empty";
                Labela1.ForeColor = System.Drawing.Color.Red;
            }
            else
                if (a2.Text == String.Empty)
            {
                Labela2.Text = "Answer 2 cannot be empty";
                Labela2.ForeColor = System.Drawing.Color.Red;
            }
            else
                if (a3.Text == String.Empty)
            {
                Labela3.Text = "Answer 3 cannot be empty";
                Labela3.ForeColor = System.Drawing.Color.Red;
            }
            else
                if (a4.Text == String.Empty)
            {
                Labela4.Text = "Answer 4 cannot be empty";
                Labela4.ForeColor = System.Drawing.Color.Red;
            }
            else
                if (ca.Text == String.Empty)
            {
                Labelca.Text = "Correct answer cannot be empty";
                Labelca.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("spUpdQ", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqpid = new SqlParameter("@Question_id", qid.Text);
                    SqlParameter sqpque = new SqlParameter("@Question", que.Text);
                    SqlParameter sqpsub = new SqlParameter("@Subject", sub.Text);

                    SqlParameter sqpa1 = new SqlParameter("@Ans1", a1.Text);
                    SqlParameter sqpa2 = new SqlParameter("@Ans2", a2.Text);
                    SqlParameter sqpa3 = new SqlParameter("@Ans3", a3.Text);
                    SqlParameter sqpa4 = new SqlParameter("@Ans4", a4.Text);

                    SqlParameter sqpca = new SqlParameter("@Cor_ans", ca.Text);

                    cmd.Parameters.Add(sqpid);
                    cmd.Parameters.Add(sqpque);
                    cmd.Parameters.Add(sqpsub);
                    cmd.Parameters.Add(sqpa1);
                    cmd.Parameters.Add(sqpa2);
                    cmd.Parameters.Add(sqpa3);
                    cmd.Parameters.Add(sqpa4);
                    cmd.Parameters.Add(sqpca);

                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Label2.Text = "Question updated successfully";
                        Label2.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Label2.Text = "Failed to update the question. Question ID is incorrect";
                        Label2.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            qid.Text = String.Empty;
            que.Text = String.Empty;
            sub.Text = String.Empty;
            a1.Text = String.Empty;
            a2.Text = String.Empty;
            a3.Text = String.Empty;
            a4.Text = String.Empty;
            ca.Text = String.Empty;
            Label3.Text = " ";
            Label2.Text = " ";
            Labela1.Text = " ";
            Labela2.Text = " ";
            Labela3.Text = " ";
            Labela4.Text = " ";
            Labelca.Text = " ";
            Labelq.Text = " ";
            Labelsid.Text = " ";
            Labelqid.Text = " ";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (qid.Text == String.Empty)
            {
                Labelqid.Text = "Question ID cannot be empty";
                Labelqid.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("spRemoveQuestion", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqpeid = new SqlParameter("@Question_id", qid.Text);

                    cmd.Parameters.Add(sqpeid);

                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Label2.Text = "Question removed successfully";
                        Label2.ForeColor = System.Drawing.Color.Green;

                        Labela1.Text = " ";
                        Labela2.Text = " ";
                        Labela3.Text = " ";
                        Labela4.Text = " ";
                        Labelca.Text = " ";
                        Labelq.Text = " ";
                        Labelsid.Text = " ";
                        Labelqid.Text = " ";
                    }
                    else
                    {
                        Label2.Text = "Failed to remove the question.Question ID is incorrect";
                        Label2.ForeColor = System.Drawing.Color.Red;
                        Label3.Text = " ";
                        Labela1.Text = " ";
                        Labela2.Text = " ";
                        Labela3.Text = " ";
                        Labela4.Text = " ";
                        Labelca.Text = " ";
                        Labelq.Text = " ";
                        Labelsid.Text = " ";
                        Labelqid.Text = " ";
                    }
                }
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (qid.Text == String.Empty)
            {
                Label3.Text = "Please insert the Question ID";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
            else
            if (int.TryParse(qid.Text, out n) == false)
            {
                Label3.Text = "Question ID is not in the correct format";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                string id = qid.Text;

                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    String sql = "SELECT subject,question,answer_1,answer_2,answer_3,answer_4,correct_answer FROM qna WHERE question_id='" + id + "'";
                    SqlCommand comm = new SqlCommand(sql, DBCon);
                    DBCon.Open();
                    SqlDataReader nwReader = comm.ExecuteReader();
                    if (nwReader.HasRows)
                    {
                        while (nwReader.Read())
                        {
                            que.Text = (string)nwReader["question"];
                            sub.Text = (string)nwReader["subject"];
                            a1.Text = (string)nwReader["answer_1"];
                            a2.Text = (string)nwReader["answer_2"];
                            a3.Text = (string)nwReader["answer_3"];
                            a4.Text = (string)nwReader["answer_4"];
                            int cor = (int)nwReader["correct_answer"];
                            ca.Text = cor.ToString();
                            Label2.Text = " ";
                            Label3.Text = " ";
                            Labela1.Text = " ";
                            Labela2.Text = " ";
                            Labela3.Text = " ";
                            Labela4.Text = " ";
                            Labelca.Text = " ";
                            Labelq.Text = " ";
                            Labelsid.Text = " ";
                            Labelqid.Text = " ";
                        }
                    }
                    else
                    {
                        Label3.Text = "Question ID is incorrect";
                        Label3.ForeColor = System.Drawing.Color.Red;
                        Labela1.Text = " ";
                        Labela2.Text = " ";
                        Labela3.Text = " ";
                        Labela4.Text = " ";
                        Labelca.Text = " ";
                        Labelq.Text = " ";
                        Labelsid.Text = " ";
                        Labelqid.Text = " ";
                    }

                    DBCon.Close();

                    nwReader.Close();
                }
            }
        }
    }
}