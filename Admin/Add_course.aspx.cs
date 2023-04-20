using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;


namespace Exam.GUI
{
    public partial class Add_cou_sub_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            cid.Text = String.Empty;
            name.Text = String.Empty;
            amount.Text = String.Empty;
            duration.Text = String.Empty;
            nos.Text = String.Empty;
            Label2.Text = " ";
            Label3.Text = " ";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (cid.Text.Length == 0)
            {
                Label2.Text = "Course ID field cannot be empty";
                Label2.ForeColor = System.Drawing.Color.Red;
                Label3.Text = " ";
            }
            else
            {
                String id = cid.Text;
                String na = name.Text;
                String am = amount.Text;
                String du = duration.Text;
                String s = nos.Text;

                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("spAddCourse", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqpid = new SqlParameter("@Course_id", id);
                    SqlParameter sqpname = new SqlParameter("@Name", na);
                    SqlParameter sqpamount = new SqlParameter("@Amount", am);
                    SqlParameter sqpduration = new SqlParameter("@Duration", du);
                    SqlParameter sqpnos = new SqlParameter("@NOS", s);
               

                    cmd.Parameters.Add(sqpid);
                    cmd.Parameters.Add(sqpname);
                    cmd.Parameters.Add(sqpamount);
                    cmd.Parameters.Add(sqpduration);
                    cmd.Parameters.Add(sqpnos);
                   

                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Label3.Text = "Course added successfully";
                        Label3.ForeColor = System.Drawing.Color.Green;
                        Label2.Text = " ";
                    }
                    else
                    {
                        Label3.Text = "Failed.Already a course has added for this Course ID";
                        Label3.ForeColor = System.Drawing.Color.Red;
                        Label2.Text = " ";
                    }
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select course_id,name,amount,duration,nos FROM course  ORDER BY name ASC", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
                
            }


        }
    }
}