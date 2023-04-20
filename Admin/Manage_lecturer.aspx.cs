using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam.Admin
{
    public partial class Manage_lecturer1 : System.Web.UI.Page
    {
        private String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select lecturer_id as 'Lecturer ID',full_name as 'Full Name',nic_no as 'NIC No',subject_id as 'Subject ID',contact_no as 'Contact No' FROM lecturer ORDER BY full_name ASC", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (lid.Text == String.Empty)
            {
                Label3.Text = "Please insert the Lecturer ID";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("spUpdLec", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqplid = new SqlParameter("@Lecturer_id", lid.Text);
                    SqlParameter sqpnic = new SqlParameter("@NIC_No", nic.Text);
                    SqlParameter sqpfn = new SqlParameter("@Full_name", na.Text);
                    SqlParameter sqpsub = new SqlParameter("@Subjet_id", sid.Text);
                    SqlParameter sqptp = new SqlParameter("@Contact", tp.Text);

                    cmd.Parameters.Add(sqplid);
                    cmd.Parameters.Add(sqpnic);
                    cmd.Parameters.Add(sqpfn);
                    cmd.Parameters.Add(sqpsub);
                    cmd.Parameters.Add(sqptp);

                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Label1.Text = "Lecturer details updated successfully";
                        Label1.ForeColor = System.Drawing.Color.Green;
                        Label3.Text = " ";
                        Label2.Text = " ";
                    }
                    else
                    {
                        Label1.Text = "Failed to update the details.Lecturer ID is incorrect";
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label3.Text = " ";
                        Label2.Text = " ";
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lid.Text = String.Empty;
            na.Text = String.Empty;
            nic.Text = String.Empty;
            sid.Text = String.Empty;
            tp.Text = String.Empty;
            Label3.Text = " ";
            Label1.Text = " ";
            Label2.Text = " ";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (lid.Text == String.Empty)
            {
                Label3.Text = "Please insert the lecturer ID";
                Label3.ForeColor = System.Drawing.Color.Red;
                Label1.Text = " ";
            }
            else
            {
                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand cmd = new SqlCommand("spRemoveLecturer", DBCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqplid = new SqlParameter("@Lecturer_id", lid.Text);

                    cmd.Parameters.Add(sqplid);

                    int ReturnCode = (int)cmd.ExecuteScalar();

                    if (ReturnCode == 1)
                    {
                        Label1.Text = "Lecturer removed successfully";
                        Label1.ForeColor = System.Drawing.Color.Green;
                        Label3.Text = " ";
                        Label2.Text = " ";
                    }
                    else
                    {
                        Label1.Text = "Failed to remoe the lecturer.Lecturer ID is incorrect";
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label3.Text = " ";
                        Label2.Text = " ";
                    }
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string id = lid.Text;
            if (lid.Text == String.Empty)
            {
                Label3.Text = "Please insert the lecturer ID";
                Label3.ForeColor = System.Drawing.Color.Red;
                Label1.Text = " ";
            }
            else
            {
                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    String sql = "SELECT nic_no,full_name,subject_id,contact_no FROM lecturer WHERE lecturer_id='" + id + "'";
                    SqlCommand comm = new SqlCommand(sql, DBCon);
                    DBCon.Open();
                    SqlDataReader nwReader = comm.ExecuteReader();
                    if (nwReader.HasRows)
                    {
                        while (nwReader.Read())
                        {
                            nic.Text = (string)nwReader["nic_no"];
                            na.Text = (string)nwReader["full_name"];
                            sid.Text = (string)nwReader["subject_id"];
                            int cont = (int)nwReader["contact_no"];
                            tp.Text = cont.ToString();
                        }
                        Label3.Text = " ";
                        Label1.Text = " ";
                        Label2.Text = " ";
                    }
                    else
                    {
                        Label3.Text = "Lecturer Id is incorrecct";
                        Label3.ForeColor = System.Drawing.Color.Red;
                        Label1.Text = " ";
                        Label2.Text = " ";
                    }
                    DBCon.Close();

                    nwReader.Close();
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string id = nic.Text;

            if (nic.Text == String.Empty)
            {
                Label2.Text = "Please insert the NIC No";
                Label2.ForeColor = System.Drawing.Color.Red;
                Label1.Text = " ";
            }
            else
            {
                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    String sql = "SELECT lecturer_id,full_name,subject_id,contact_no FROM lecturer WHERE nic_no='" + id + "'";
                    SqlCommand comm = new SqlCommand(sql, DBCon);
                    DBCon.Open();
                    SqlDataReader nwReader = comm.ExecuteReader();
                    if (nwReader.HasRows)
                    {
                        while (nwReader.Read())
                        {
                            int lecid = (int)nwReader["lecturer_id"];
                            lid.Text = lecid.ToString();
                            na.Text = (string)nwReader["full_name"];
                            sid.Text = (string)nwReader["subject_id"];
                            int cont = (int)nwReader["contact_no"];
                            tp.Text = cont.ToString();
                        }
                        Label3.Text = " ";
                        Label1.Text = " ";
                        Label2.Text = " ";
                    }
                    else
                    {
                        Label2.Text = "Lecturer NIc No is incorrect";
                        Label2.ForeColor = System.Drawing.Color.Red;
                        Label3.Text = " ";
                        Label1.Text = " ";
                    }

                    DBCon.Close();

                    nwReader.Close();
                }
            }
        }
    }
}