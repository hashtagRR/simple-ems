using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace Exam.Admin
{
    public partial class Recover_account : System.Web.UI.Page
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
            Label_pws.Text = " ";
            Label_pws.Text = " ";
            nic.Text = " ";
            spw1.Text = " ";
            spw2.Text = " ";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label_l.Text = " ";
            Label_pwl.Text = " ";
            lnic.Text = " ";
            lpw1.Text = " ";
            lpw2.Text = " ";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
          
            if (spw1.Text == spw2.Text)
            {
                
                String nicno = nic.Text;
                String pw = spw1.Text;
              

                String EncPw = FormsAuthentication.HashPasswordForStoringInConfigFile(spw1.Text, "SHA1");
                // String EncPw = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpw1.Text,System.Web.Configuration.FormsAuthPasswordFormat.SHA1.ToString());

                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("spRecoverStudent", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                   
                    SqlParameter sqpnicno = new SqlParameter("@NicNo", nicno);
                    SqlParameter sqppassword = new SqlParameter("@Password", EncPw);
                    

                   
                    cmd.Parameters.Add(sqpnicno);
                    cmd.Parameters.Add(sqppassword);
                    

                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Label_s.Text = "Student account recoverde successfully";
                        Label_s.ForeColor = System.Drawing.Color.Green;
                        Label_pws.Text = " ";
                        Label_pws.Text = " ";
                    }
                    else
                    {
                        Label_s.Text = "Failed to recover the student account.NIC No is incorrect";
                        Label_s.ForeColor = System.Drawing.Color.Red;
                        Label_pws.Text = " ";
                        Label_pws.Text = " ";
                    }
                }
            }
            else
            {
                Label_pws.Text = "Password Do Not Match";
                Label_pws.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (lpw1.Text == lpw2.Text)
            {

                String nicno = lnic.Text;
                String pw = lpw1.Text;


                String EncPw = FormsAuthentication.HashPasswordForStoringInConfigFile(lpw1.Text, "SHA1");
                // String EncPw = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpw1.Text,System.Web.Configuration.FormsAuthPasswordFormat.SHA1.ToString());

                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("spRecoverLecturer", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    SqlParameter sqpnicno = new SqlParameter("@NicNo", nicno);
                    SqlParameter sqppassword = new SqlParameter("@Password", EncPw);



                    cmd.Parameters.Add(sqpnicno);
                    cmd.Parameters.Add(sqppassword);


                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Label_l.Text = "Lecturer account recoverde successfully";
                        Label_l.ForeColor = System.Drawing.Color.Green;
                        Label_pwl.Text = " ";
                        Label_pwl.Text = " ";
                    }
                    else
                    {
                        Label_l.Text = "Failed to recover the lecturer account.NIC No is incorrect";
                        Label_l.ForeColor = System.Drawing.Color.Red;
                        Label_pwl.Text = " ";
                        Label_pwl.Text = " ";
                    }
                }
            }
            else
            {
                Label_pws.Text = "Password Do Not Match";
                Label_pws.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}