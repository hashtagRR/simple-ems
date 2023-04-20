using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace Exam.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            un.Text = String.Empty;
            pw.Text = String.Empty;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (un.Text == String.Empty && pw.Text == String.Empty)
            {
                Label1.Text = "Username and password cannot be empty";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            if (un.Text == String.Empty)
            {
                Label1.Text = "Username cannot be empty";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
                if (pw.Text == String.Empty)
            {
                Label1.Text = "Password cannot be empty";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("LoginAdmin", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    String EncPw = FormsAuthentication.HashPasswordForStoringInConfigFile(pw.Text, "SHA1");

                    SqlParameter sqpusername = new SqlParameter("@UserName", un.Text);
                    SqlParameter sqppassword = new SqlParameter("@Password", EncPw);

                    cmd.Parameters.Add(sqpusername);
                    cmd.Parameters.Add(sqppassword);

                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Session["isloggedin"] = true;
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        Label1.Text = "Wrong Username or Passsword";
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Button1_Click(sender, e);
                    }
                }
            }
        }
    }
}