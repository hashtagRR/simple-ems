using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam.GUI
{
    public partial class Edit_sub_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["isloggedin"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            sid.Text = String.Empty;
            name.Text = String.Empty;
            cid.Text = String.Empty;
            des.Text = String.Empty;
            Label3.Text = " ";
            Label2.Text = " ";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (sid.Text.Length == 0)
            {
                Label2.Text = "Subject ID field cannot be empty";
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                String id = sid.Text;
                String na = name.Text;
                String idc = cid.Text;
                String desc = des.Text;

                String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("spAddSubject", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqpsubjectid = new SqlParameter("@Subject_id", id);
                    SqlParameter sqpname = new SqlParameter("@Name", na);
                    SqlParameter sqpcourseid = new SqlParameter("@Coure_id", idc);
                    SqlParameter sqpdescription = new SqlParameter("@Description", desc);

                    cmd.Parameters.Add(sqpsubjectid);
                    cmd.Parameters.Add(sqpname);
                    cmd.Parameters.Add(sqpcourseid);
                    cmd.Parameters.Add(sqpdescription);

                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Label3.Text = "Subject added successfully";
                        Label3.ForeColor = System.Drawing.Color.Green;
                        Label2.Text = " ";
                    }
                    else
                    {
                        Label3.Text = "Already a subject has added to this Subject ID";
                        Label3.ForeColor = System.Drawing.Color.Red;
                        Label2.Text = " ";
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select course_id,name FROM course ORDER BY name ASC", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
            }
        }
    }
}