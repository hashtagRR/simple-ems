using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace Exam_lecturer.Lecturer
{
    public partial class Change_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lecturerisloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
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
                    SqlCommand cmd = new SqlCommand("spChangePassword_lecturer", DBCon);
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
    }
}