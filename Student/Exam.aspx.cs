using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exam_student.Student
{
    public partial class Exam : System.Web.UI.Page
    {
        private String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        protected string[,] Question = new string[15, 5];
        protected string[] Correct_ans = new string[15];
        protected string[] Given_ans = new string[15];

        private static int No_Of_Questions = 15;
        private static int Minutes_per_question = 1;

        protected string[] Question_id = new string[15];
        private int n;

        protected void Page_Load(object sender, EventArgs e)

        {
            if (Session["studentisloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
                if (Session["sub_id"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else

                ExamPage();
        }

        public void ExamPage()
        {
            string sid = Session["sub_id"].ToString();

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select TOP 15 * FROM qna WHERE subject='" + sid + "' ORDER BY newid()", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = false;

                for (int i = 0; i < 15; i++)
                {
                    Question_id[i] = dgv1.Rows[i].Cells[0].Text;
                    Question[i, 0] = dgv1.Rows[i].Cells[2].Text;
                    Question[i, 1] = dgv1.Rows[i].Cells[3].Text;
                    Question[i, 2] = dgv1.Rows[i].Cells[4].Text;
                    Question[i, 3] = dgv1.Rows[i].Cells[5].Text;
                    Question[i, 4] = dgv1.Rows[i].Cells[6].Text;
                }
                //Session["ans"] = Correct_ans;

                CarIn.Controls.Add(new LiteralControl("<div id=\"carousel-example-generic\" class=\"carousel slide\" data-ride=\"carousel\"  data-interval=\"false\" > "));
                CarIn.Controls.Add(new LiteralControl(" <div class=\"carousel-inner\" role=\"listbox\" >"));

                for (int i = 0; i < 15; i++)
                {
                    if (i == 0)
                    {
                        CarIn.Controls.Add(new LiteralControl("<div class=\"item active\">"));
                    }
                    else
                    {
                        CarIn.Controls.Add(new LiteralControl("<div class=\"item\">"));
                    }

                    n = n + 1;
                    CarIn.Controls.Add(new LiteralControl("<div class=\"row\">"));
                    CarIn.Controls.Add(new LiteralControl("<div class=\"col-md-2\"></div>"));
                    CarIn.Controls.Add(new LiteralControl("<div class=\"col-md-4\"><br><h3>" + n + "." + Question[i, 0] + " </h3></div>"));
                    CarIn.Controls.Add(new LiteralControl("<div class=\"col-md-4\">"));
                    CarIn.Controls.Add(new LiteralControl("<br><br>"));

                    for (int j = 1; j < 5; j++)
                    {
                        CarIn.Controls.Add(new LiteralControl("<label class=\"btn btn-default\">"));
                        CarIn.Controls.Add(new LiteralControl("<input  type=\"radio\" id=\"Q" + i.ToString() + "-" + j.ToString() + "\" name=\"Q" + i.ToString() + "\" value=\"" + j.ToString() + "\"/>"));
                        CarIn.Controls.Add(new LiteralControl("&nbsp &nbsp" + Question[i, j] + " </label>"));
                        CarIn.Controls.Add(new LiteralControl("<br> <br>"));
                    }

                    CarIn.Controls.Add(new LiteralControl("</div>"));
                    CarIn.Controls.Add(new LiteralControl("</div>"));
                    CarIn.Controls.Add(new LiteralControl("</div>"));
                }

                CarIn.Controls.Add(new LiteralControl("<div class=\"item\">"));
                CarIn.Controls.Add(new LiteralControl("<div class=\"row\">"));
                CarIn.Controls.Add(new LiteralControl("<div class=\"col-md-2\"></div>"));
                CarIn.Controls.Add(new LiteralControl("<div class=\"col-md-4\"><br><h3>Submit Exam</h3></div>"));
                CarIn.Controls.Add(new LiteralControl("<div class=\"col-md-4\">"));
                CarIn.Controls.Add(new LiteralControl("<br> <br>"));

                Button btnsubmit = new Button();
                btnsubmit.ID = "Submit Button";
                btnsubmit.Text = "Submit";
                btnsubmit.CssClass = "btn btn-large btn-warning";

                btnsubmit.Click += btnsubmit_Click;
                // btnsubmit.OnClientClick = "ExamSubmit()";

                CarIn.Controls.Add(btnsubmit);

                CarIn.Controls.Add(new LiteralControl("</div>"));
                CarIn.Controls.Add(new LiteralControl("</div>"));
                CarIn.Controls.Add(new LiteralControl("</div>"));

                CarIn.Controls.Add(new LiteralControl("</div>"));

                CarIn.Controls.Add(new LiteralControl(" <a class=\"left carousel-control\" href=\"#carousel-example-generic\" role=\"button\" data-slide=\"prev\"> "));
                CarIn.Controls.Add(new LiteralControl("<span class=\"glyphicon glyphicon-chevron-left\" aria-hidden=\"true\"></span>"));
                CarIn.Controls.Add(new LiteralControl("<span class=\"sr-only\">Previous</span>"));
                CarIn.Controls.Add(new LiteralControl("</a>"));

                CarIn.Controls.Add(new LiteralControl(" <a class=\"right carousel-control\" href=\"#carousel-example-generic\" role=\"button\" data-slide=\"next\"> "));
                CarIn.Controls.Add(new LiteralControl("<span class=\"glyphicon glyphicon-chevron-right\" aria-hidden=\"true\"></span>"));
                CarIn.Controls.Add(new LiteralControl("<span class=\"sr-only\">Next</span>"));
                CarIn.Controls.Add(new LiteralControl("</a>"));

                CarIn.Controls.Add(new LiteralControl("</div>"));

                ExamClock.Enabled = true;
                ExamClock.Interval = No_Of_Questions * Minutes_per_question * 60 * 1000;
                ExamClock.Tick += btnsubmit_Click;
            }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            // SaveAnswerSheet();

            for (int i = 0; i < 15; i++)
            {
                Given_ans[i] = Request.Form["Q" + i.ToString()];
            }

            int j = 0;
            float cor_ans = 0;
            int wro_ans = 0;
            string ca;
            string ga;

            for (int i = 0; i < 15; i++)
            {
                Correct_ans[i] = dgv1.Rows[i].Cells[7].Text;
            }

            for (int i = 0; i < 15; i++)
            {
                if (Given_ans[i] != null)
                {
                    ca = Correct_ans[i].ToString();
                    ga = Given_ans[i].ToString();

                    if (ca.Equals(ga))
                    {
                        cor_ans = cor_ans + 1;
                        j++;
                    }
                    else
                        wro_ans = wro_ans + 1;
                    j++;
                }
            }

            cor_ans = (cor_ans / 15) * 100;

            Session["marks"] = cor_ans.ToString();

            if (cor_ans < 35)
            {
                string result = cor_ans.ToString();
                SaveResults();
                SaveAnswerSheet();
                Session["marks"] = result.ToString();
                Session["grade"] = "F";
                Response.Redirect("End_exam.aspx");
            }
            else
            if (cor_ans < 55)
            {
                string result = cor_ans.ToString();
                SaveResults();
                SaveAnswerSheet();
                Session["marks"] = result.ToString();
                Session["grade"] = "C";
                Response.Redirect("End_exam.aspx");
            }
            else
                if (cor_ans < 75)
            {
                string result = cor_ans.ToString();
                SaveResults();
                SaveAnswerSheet();
                Session["marks"] = result.ToString();
                Session["grade"] = "B";
                Response.Redirect("End_exam.aspx");
            }
            else
                if (cor_ans > 75)
            {
                string result = cor_ans.ToString();
                SaveResults();
                SaveAnswerSheet();
                Session["marks"] = result.ToString();
                Session["grade"] = "A";
                Response.Redirect("End_exam.aspx");
            }
        }

        public void SaveResults()
        {
            string exam_date = DateTime.Now.ToString("yyyy-MM-dd");

            string nic = Session["NIC_No"].ToString();
            string sid = Session["sub_id"].ToString();
            string marks = Session["marks"].ToString();

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand cmd = new SqlCommand("spAddMarks", DBCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqpsid = new SqlParameter("@Subject_id", sid);
                SqlParameter sqpnic = new SqlParameter("@NIC_No", nic);
                SqlParameter sqpmarks = new SqlParameter("@Marks", marks);
                SqlParameter sqped = new SqlParameter("@Exam_date", exam_date);

                cmd.Parameters.Add(sqpsid);
                cmd.Parameters.Add(sqpnic);
                cmd.Parameters.Add(sqpmarks);
                cmd.Parameters.Add(sqped);

                int ReturnCode = (int)cmd.ExecuteScalar();

                if (ReturnCode == 1)
                {
                    //Session["return"] = "Inserted";
                }
                else
                {
                    //Session["return"] = "Updated";
                }
            }
        }

        public void SaveAnswerSheet()
        {
            string exam_date = DateTime.Now.ToString("yyyy-MM-dd");

            string nic = Session["NIC_No"].ToString();
            string eid = Session["exam_id"].ToString();

            for (int i = 0; i < No_Of_Questions; i++)
            {
                Question_id[i] = dgv1.Rows[i].Cells[0].Text;
                Given_ans[i] = Request.Form["Q" + i.ToString()];

                string insertSQLQry = "INSERT INTO answer_sheet (exam_id,nic_no,question_id,given_answer,date ) VALUES('" + eid + "','" + nic + "','" + Question_id[i] + "','" + Given_ans[i] + "','" + exam_date + "')";

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand SqlCmd = new SqlCommand(insertSQLQry, DBCon);
                    SqlCmd.ExecuteNonQuery();
                }
            }
            //Response.Redirect("http://wwww.bing.com");
        }
    }
}