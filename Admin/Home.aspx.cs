using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam.Admin
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Qcount();
                Scount();
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

        protected void Scount()
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            SqlConnection DBCon = new SqlConnection(ConStr);

            DBCon.Open();
            SqlCommand sqlcmd = new SqlCommand("select course, students=COUNT(student_id)  from student group by course", DBCon);
            SqlDataReader reader = sqlcmd.ExecuteReader();

            dgv2.DataSource = reader;

            dgv2.DataBind();

            dgv2.Visible = true;
        }
    }
}