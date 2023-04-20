using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam_student.Student
{
    public partial class End_exam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["studentisloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                mk.Text = Session["marks"].ToString() + "%";
                gd.Text = Session["grade"].ToString();
                sid.Text = Session["sub_id"].ToString();
                ena.Text = Session["exam_name"].ToString();
                GetDetails();
            }
        }

        public void GetDetails()
        {
            string nic = Session["NIC_No"].ToString();

            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
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
                DestroySessions();
            }
        }

        private void DestroySessions()
        {
            Session["sub_id"] = null;
            Session["marks"] = null;
            Session["grade"] = null;
            Session["exam_name"] = null;
        }
    }
}