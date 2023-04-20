using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Exam_student.Student
{
    public partial class Select_exam : System.Web.UI.Page
    {
        private string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
          /*  if (Session["studentisloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ExamNameSelect();
                GetDetails();
            }*/
        }

        public void ExamNameSelect()
        {
            string nic = Session["NIC_No"].ToString();

            if (!Page.IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT name FROM exam WHERE course_id IN (SELECT course FROM student WHERE nic_no='" + nic + "')"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        dl1.DataSource = cmd.ExecuteReader();
                        dl1.DataTextField = "Name";
                        dl1.DataBind();
                        con.Close();
                    }
                }
            }
        }

        public void GetDetails()
        {
            string nic = Session["NIC_No"].ToString();

            using (SqlConnection DBCon = new SqlConnection(constr))
            {
                String sql = "SELECT student_id,full_name,course FROM student WHERE nic_no='" + nic + "'";
                SqlCommand comm = new SqlCommand(sql, DBCon);
                DBCon.Open();
                SqlDataReader nwReader = comm.ExecuteReader();
                while (nwReader.Read())
                {
                    fn.Text = (string)nwReader["full_name"];
                    int id = (int)nwReader["student_id"];
                    sid.Text = id.ToString();
                    cid.Text = (string)nwReader["course"];
                }
                nwReader.Close();
                DBCon.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sid = dl1.SelectedValue;
            Session["exam_name"] = sid;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT exam_id,subject_id FROM exam WHERE name='" + sid + "'"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader nwReader = cmd.ExecuteReader();
                    while (nwReader.Read())
                    {
                        int exam_id = (int)nwReader["exam_id"];
                        string sub_id = (string)nwReader["subject_id"];

                        Session["exam_id"] = exam_id;
                        Session["sub_id"] = sub_id;
                    }
                    nwReader.Close();
                    con.Close();

                    CheckEligible();
                }
            }
        }

        public void CheckEligible()
        {
            string nic = Session["NIC_No"].ToString();
            string sid = Session["sub_id"].ToString();

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT attempt FROM results WHERE subject_id='" + sid + "' AND nic_no='" + nic + "'"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    object scalarVal = cmd.ExecuteScalar();

                    if (scalarVal == null)
                        Response.Redirect("Exam.aspx");
                    else
                    {
                        int a = Convert.ToInt32(scalarVal);
                        if (a < 3)
                            Response.Redirect("Exam.aspx");
                        else if (a == 3)
                        {
                            Label1.Text = "You cannot take one exam more than three times";
                            Label1.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
        }
    }
}