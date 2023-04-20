using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam_student.Student
{
    public partial class View_grades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["studentisloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                GetMarks();
                GetAvg();
            }
        }

        public void GetMarks()
        {
            string id = Session["NIC_No"].ToString();

            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select subject_id as 'Subject ID',marks as 'Marks',exam_date as 'Exam date',attempt as 'Attempt' FROM results WHERE nic_no='" + id + "' ORDER BY exam_date", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
            }
        }

        public void GetAvg()
        {
            string nic = Session["NIC_No"].ToString();

            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                String sql = "SELECT AVG(marks) as 'Avarage' FROM results WHERE nic_no='" + nic + "'";
                SqlCommand comm = new SqlCommand(sql, DBCon);
                DBCon.Open();
                SqlDataReader nwReader = comm.ExecuteReader();
                while (nwReader.Read())
                {
                    double id = (double)nwReader["Avarage"];
                    int i = Convert.ToInt32(id);
                    avg.Text = System.Convert.ToString(id) + '%';
                    ValidateAvg(i);
                }
                nwReader.Close();
                DBCon.Close();
            }
        }

        public void ValidateAvg(Int32 i)
        {
            if (i >= 0 && i <= 35)
            {
                avg.ForeColor = System.Drawing.Color.Red;
                feed.Text = "It seems you are having some difficulties with curtain subjects. Our lectures are always looking forword for give students some extra help.";
            }
            else
             if (i >= 35 && i <= 55)
            {
                avg.ForeColor = System.Drawing.Color.Orange;
                feed.Text = "Good. Try to increase the avarage. Our lecturer panel is always here for your help. May be you could make short notes about difficult subject with your firends ";
            }
            else
             if (i >= 55 && i <= 75)
            {
                avg.ForeColor = System.Drawing.Color.Blue;
                feed.Text = "Very good. You've done well so far. May be refereing recomonded learning web sites will help you to increase the avarage.";
            }
            else
                if (i >= 75 && i <= 100)
            {
                avg.ForeColor = System.Drawing.Color.Green;
                feed.Text = "Perfect. You've done very well. Keep it up and try to increase the avarage. Our recomonded learning partners have the knowledge which you are looking for.";
            }
        }
    }
}