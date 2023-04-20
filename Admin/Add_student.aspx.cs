using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace Exam.GUI
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (nic.Text==String.Empty)
            {
                Label2.Text = "NIC No field cannot be empty";
                Label2.ForeColor = System.Drawing.Color.Red;
                Label3.Text = " ";
            }
            else
            if (pw1.Text == pw2.Text)
            {
                String name = fn.Text;
                String nicno = nic.Text;
                String pw = pw1.Text;
                String tel = tp.Text;
                String cou = course.Text;

                String EncPw = FormsAuthentication.HashPasswordForStoringInConfigFile(pw1.Text, "SHA1");
                // String EncPw = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpw1.Text,System.Web.Configuration.FormsAuthPasswordFormat.SHA1.ToString());

                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("spRegisterStudent", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqpusername = new SqlParameter("@FullName", name);
                    SqlParameter sqpnicno = new SqlParameter("@NicNo", nicno);
                    SqlParameter sqppassword = new SqlParameter("@Password", EncPw);
                    SqlParameter sqptelephone = new SqlParameter("@Telephone", tel);
                    SqlParameter sqpcourse = new SqlParameter("@Course", cou);

                    cmd.Parameters.Add(sqpusername);
                    cmd.Parameters.Add(sqpnicno);
                    cmd.Parameters.Add(sqppassword);
                    cmd.Parameters.Add(sqptelephone);
                    cmd.Parameters.Add(sqpcourse);

                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Label3.Text = "Student details saved successfully";
                        Label3.ForeColor = System.Drawing.Color.Green;
                        Label1.Text = " ";
                        Label2.Text = " ";
                    }
                    else
                    {
                        Label3.Text = "Student registration failed. Already a student has registerd with this NIC No";
                        Label3.ForeColor = System.Drawing.Color.Red;
                        Label1.Text = " ";
                        Label2.Text = " ";
                    }
                }
            }
            else
            {
                Label1.Text = "Password Do Not Match";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            fn.Text = String.Empty;
            nic.Text = String.Empty;
            pw1.Text = String.Empty;
            pw2.Text = String.Empty;
            tp.Text = String.Empty;
            course.Text = String.Empty;
            Label1.Text = " ";
            Label2.Text = " ";
            Label3.Text = " ";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select course_id,name FROM course  ORDER BY name ASC", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
            }
        }
    }
}