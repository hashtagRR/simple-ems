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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lecturerisloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Qcount();
                ExamRs();
            }
        }
        protected void Qcount()
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            SqlConnection DBCon = new SqlConnection(ConStr);

            DBCon.Open();
            SqlCommand sqlcmd = new SqlCommand("select subject, questions=COUNT(question)  from qna group by subject", DBCon);
            SqlDataReader reader = sqlcmd.ExecuteReader();

            dgv1.DataSource = reader;

            dgv1.DataBind();

            dgv1.Visible = true;
        }
        protected void ExamRs()
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            SqlConnection DBCon = new SqlConnection(ConStr);

            DBCon.Open();
            SqlCommand sqlcmd = new SqlCommand("select TOP 10 subject_id as 'Subject ID',nic_no as 'NIC No',marks as 'Marks',exam_date as 'Exam Date',attempt as 'Attempt' from results", DBCon);
            SqlDataReader reader = sqlcmd.ExecuteReader();

            dgv2.DataSource = reader;

            dgv2.DataBind();

            dgv2.Visible = true;
        }
    }
}