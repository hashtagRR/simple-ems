using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam.Admin
{
    public partial class Manage_course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand cmd = new SqlCommand("spUpdCou", DBCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqplid = new SqlParameter("@Course_id", cid.Text);
                SqlParameter sqpnic = new SqlParameter("@Name", na.Text);
                SqlParameter sqpfn = new SqlParameter("@Duration", dur.Text);
                SqlParameter sqpsub = new SqlParameter("@Cost", cost.Text);
                SqlParameter sqptp = new SqlParameter("@NOS", nos.Text);

                cmd.Parameters.Add(sqplid);
                cmd.Parameters.Add(sqpnic);
                cmd.Parameters.Add(sqpfn);
                cmd.Parameters.Add(sqpsub);
                cmd.Parameters.Add(sqptp);

                int ReturnCode = (int)cmd.ExecuteScalar();

                if (ReturnCode == 1)
                {
                    Label3.Text = "Course details updated successfully";
                    Label3.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label3.Text = "Failed to update the details.Course ID is incorrect";
                    Label3.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select course_id as 'Course ID',name as 'Name',duration as 'Duration',amount as 'Amount',nos as 'No of subjects' FROM course ORDER BY name", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            cid.Text = String.Empty;
            na.Text = String.Empty;
            dur.Text = String.Empty;
            cost.Text = String.Empty;
            nos.Text = String.Empty;
            Label3.Text = " ";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand cmd = new SqlCommand("spRemoveCourse", DBCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqpcid = new SqlParameter("@Course_id", cid.Text);

                cmd.Parameters.Add(sqpcid);

                int ReturnCode = (int)cmd.ExecuteScalar();

                if (ReturnCode == 1)
                {
                    Label3.Text = "Course details removed successfully";
                    Label3.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label3.Text = "Failed to remove the details.Course ID is incorrect";
                    Label3.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string id = cid.Text;

            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                String sql = "SELECT name,amount,duration,nos FROM course WHERE course_id='" + id + "'";
                SqlCommand comm = new SqlCommand(sql, DBCon);
                DBCon.Open();
                SqlDataReader nwReader = comm.ExecuteReader();
                while (nwReader.Read())
                {
                    na.Text = (string)nwReader["name"];
                    cost.Text = (string)nwReader["amount"];
                    dur.Text = (string)nwReader["duration"];
                    int num = (int)nwReader["nos"];
                    nos.Text = num.ToString();
                }
                nwReader.Close();
                DBCon.Close();
            }
        }
    }
}