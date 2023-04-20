using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace Exam.GUI
{
    public partial class Admin_manage : System.Web.UI.Page
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
            if (nic.Text.Length == 0)
            {
                Label2.Text = "NIC No field cannot be empty";
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            else
            if (pw1.Text == pw2.Text)
            {
                String nicno = nic.Text;
                String pw = pw1.Text;

                String EncPw = FormsAuthentication.HashPasswordForStoringInConfigFile(pw1.Text, "SHA1");
                // String EncPw = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpw1.Text,System.Web.Configuration.FormsAuthPasswordFormat.SHA1.ToString());

                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("spRegisterAdmin", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqpnicno = new SqlParameter("@NicNo", nicno);
                    SqlParameter sqppassword = new SqlParameter("@Password", EncPw);

                    cmd.Parameters.Add(sqpnicno);
                    cmd.Parameters.Add(sqppassword);

                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Label3.Text = "Admin account created successfully";
                        Label3.ForeColor = System.Drawing.Color.Green;
                        Label1.Text = " ";
                        Label2.Text = " ";
                    }
                    else
                    {
                        Label3.Text = "Admin registration failed. Already a admin has registerd to this NIC No";
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
            nic.Text = String.Empty;
            pw1.Text = String.Empty;
            pw2.Text = String.Empty;
            Label1.Text = " ";
            Label2.Text = " ";
            Label3.Text = " ";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (nic2.Text.Length == 0)
            {
                Label4.Text = "NIC No field cannot be empty";
                Label4.ForeColor = System.Drawing.Color.Red;
            }
            else
            if (npw1.Text == npw2.Text)
            {
                String EncPw1 = FormsAuthentication.HashPasswordForStoringInConfigFile(opw.Text, "SHA1");
                String EncPw2 = FormsAuthentication.HashPasswordForStoringInConfigFile(npw1.Text, "SHA1");
                // String EncPw = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpw1.Text,System.Web.Configuration.FormsAuthPasswordFormat.SHA1.ToString());

                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("spChangePassword_admin", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqpnicno = new SqlParameter("@NicNo", nic2.Text);
                    SqlParameter sqppopw = new SqlParameter("@Old_password", EncPw1);
                    SqlParameter sqpnpw = new SqlParameter("@NEw_password", EncPw2);

                    cmd.Parameters.Add(sqpnicno);
                    cmd.Parameters.Add(sqppopw);
                    cmd.Parameters.Add(sqpnpw);

                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Label6.Text = "Password Changed successfully";
                        Label6.ForeColor = System.Drawing.Color.Green;
                        Label4.Text = " ";
                        Label5.Text = " ";
                    }
                    else
                    {
                        Label6.Text = "Failed to change the password. Username or Old Password is incorrect";
                        Label6.ForeColor = System.Drawing.Color.Red;
                        Label4.Text = " ";
                        Label5.Text = " ";
                    }
                }
            }
            else
            {
                Label5.Text = "Password Do Not Match";
                Label5.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            npw1.Text = String.Empty;
            npw2.Text = String.Empty;
            nic2.Text = String.Empty;
            opw.Text = String.Empty;
            Label4.Text = " ";
            Label5.Text = " ";
            Label6.Text = " ";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand cmd = new SqlCommand("spRemoveAdmin", DBCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqpnic = new SqlParameter("@NIC_No", nicr.Text);
                SqlParameter sqppw = new SqlParameter("@Password", pwr.Text);

                cmd.Parameters.Add(sqpnic);
                cmd.Parameters.Add(sqppw);

                int ReturnCode = (int)cmd.ExecuteScalar();

                if (ReturnCode == 1)
                {
                    Label7.Text = "Admin removed successfully";
                    Label7.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label7.Text = "Failed to remove the Admin.Username or Password is incorrect";
                    Label7.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}