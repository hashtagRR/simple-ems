using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam.Admin
{
    public partial class Manage_subject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["isloggedin"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select subject_id as 'Subject ID',name as 'Name',course_id as 'Course ID',description as 'Description' FROM subject ORDER BY name ASC", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand cmd = new SqlCommand("spUpdSub", DBCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqplid = new SqlParameter("@Subject_id", sid.Text);
                SqlParameter sqpnic = new SqlParameter("@Name", na.Text);
                SqlParameter sqpfn = new SqlParameter("@Course_id", cid.Text);
                SqlParameter sqpsub = new SqlParameter("@Description", des.Text);

                cmd.Parameters.Add(sqplid);
                cmd.Parameters.Add(sqpnic);
                cmd.Parameters.Add(sqpfn);
                cmd.Parameters.Add(sqpsub);

                int ReturnCode = (int)cmd.ExecuteScalar();

                if (ReturnCode == 1)
                {
                    Label3.Text = "Subject details updated successfully";
                    Label3.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label3.Text = "Failed to update the details.Subject ID is incorrect";
                    Label3.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            sid.Text = String.Empty;
            na.Text = String.Empty;
            cid.Text = String.Empty;
            des.Text = String.Empty;
            Label3.Text = " ";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand cmd = new SqlCommand("spRemoveSubject", DBCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqpsid = new SqlParameter("@Subject_id", sid.Text);

                cmd.Parameters.Add(sqpsid);

                int ReturnCode = (int)cmd.ExecuteScalar();

                if (ReturnCode == 1)
                {
                    Label3.Text = "Subject removed successfully";
                    Label3.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label3.Text = "Failed to remove the subject.Subject ID is incorrect";
                    Label3.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string id = sid.Text;

            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                String sql = "SELECT name,course_id,description FROM subject WHERE subject_id='" + id + "'";
                SqlCommand comm = new SqlCommand(sql, DBCon);
                DBCon.Open();
                SqlDataReader nwReader = comm.ExecuteReader();
                while (nwReader.Read())
                {
                    na.Text = (string)nwReader["name"];
                    cid.Text = (string)nwReader["course_id"];
                    des.Text = (string)nwReader["description"];
                }

                DBCon.Close();

                nwReader.Close();
            }
        }
    }
}