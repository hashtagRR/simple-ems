using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;


namespace Exam.Admin
{
    public partial class Manage_student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select student_id as 'Student ID',full_name as 'Full name',nic_no as 'NIC No',course as 'Course',tp as 'Contact no' FROM student ORDER BY full_name ASC", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
                
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand cmd = new SqlCommand("spUpdStu", DBCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqplid = new SqlParameter("@Student_id", sid.Text);
                SqlParameter sqpnic = new SqlParameter("@NIC_No", nic.Text);
                SqlParameter sqpfn = new SqlParameter("@Full_name", fn.Text);
                SqlParameter sqpsub = new SqlParameter("@Course_id", cid.Text);
                SqlParameter sqptp = new SqlParameter("@Contact", tp.Text);


                cmd.Parameters.Add(sqplid);
                cmd.Parameters.Add(sqpnic);
                cmd.Parameters.Add(sqpfn);
                cmd.Parameters.Add(sqpsub);
                cmd.Parameters.Add(sqptp);


                int ReturnCode = (int)cmd.ExecuteScalar();

                if (ReturnCode == 1)
                {
                    Label3.Text = "Student details updated successfully";
                    Label3.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label3.Text = "Failed to update the details.Student ID is incorrect";
                    Label3.ForeColor = System.Drawing.Color.Red;
                }
            }





        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            sid.Text = String.Empty;
            nic.Text = String.Empty;
            fn.Text = String.Empty;
            cid.Text = String.Empty;
            tp.Text = String.Empty;
            Label3.Text = " ";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {

            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand cmd = new SqlCommand("spRemoveStudent", DBCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqpsid = new SqlParameter("@Student_id", sid.Text);



                cmd.Parameters.Add(sqpsid);



                int ReturnCode = (int)cmd.ExecuteScalar();

                if (ReturnCode == 1)
                {
                    Label3.Text = "Student removed successfully";
                    Label3.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label3.Text = "Failed to remove the student.Student ID is incorrect";
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
                String sql = "SELECT nic_no,full_name,course,tp FROM student WHERE student_id='" + id + "'";
                SqlCommand comm = new SqlCommand(sql, DBCon);
                DBCon.Open();
                SqlDataReader nwReader = comm.ExecuteReader();
                while (nwReader.Read())
                {
                    nic.Text = (string)nwReader["nic_no"];
                    fn.Text = (string)nwReader["full_name"];
                    cid.Text = (string)nwReader["course"];
                    int cont = (int)nwReader["tp"];
                    tp.Text = cont.ToString();
                }

                DBCon.Close();

                nwReader.Close();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string id = nic.Text;

            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                String sql = "SELECT student_id,full_name,course,tp FROM student WHERE nic_no='" + id + "'";
                SqlCommand comm = new SqlCommand(sql, DBCon);
                DBCon.Open();
                SqlDataReader nwReader = comm.ExecuteReader();
                while (nwReader.Read())
                {
                    int lecid = (int)nwReader["student_id"];
                    sid.Text = lecid.ToString();
                    fn.Text = (string)nwReader["full_name"];
                    cid.Text = (string)nwReader["course"];
                    int cont = (int)nwReader["tp"];
                    tp.Text = cont.ToString();
                }

                DBCon.Close();

                nwReader.Close();
            }
        }
    }
}