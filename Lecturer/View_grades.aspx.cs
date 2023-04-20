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
    public partial class View_grades : System.Web.UI.Page
    {
        String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lecturerisloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            if (subid.Text == String.Empty)
            {
                Label1.Text = "Please insert Subject ID";
                Label1.ForeColor = System.Drawing.Color.Red;
                cls_avg.Text = " ";
                dgv1.Visible = false;
            }
            else
            {
                String sid = subid.Text;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Select * FROM results WHERE subject_id='" + sid + "' ORDER BY exam_date", DBCon);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dgv1.DataSource = reader;
                        dgv1.DataBind();
                        dgv1.Visible = true;
                        GetClsAvg();
                        Label1.Text = " ";

                    }
                    else
                    {
                        Label1.Text = "No record are avaliable for this Subject ID";
                        Label1.ForeColor = System.Drawing.Color.Red;
                        cls_avg.Text = " ";
                    }
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (stuid.Text == String.Empty)
            {
                Label2.Text = "Please insert Student ID";
                Label2.ForeColor = System.Drawing.Color.Red;
                avg.Text = " ";
                dgv2.Visible = false;
            }
            else
            {
                String sid = stuid.Text;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Select * FROM results WHERE nic_no='" + sid + "'", DBCon);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dgv2.DataSource = reader;
                        dgv2.DataBind();
                        dgv2.Visible = true;
                        GetAvg();
                        Label2.Text = " ";
                    }
                    else
                    {
                        Label2.Text = "No record are avaliable for this student NIC No";
                        Label2.ForeColor = System.Drawing.Color.Red;
                        avg.Text = " ";
                    }
                }

            }
        }
        public void GetAvg()
        {
            String sid = stuid.Text;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                String sql = "SELECT AVG(marks) as 'Avarage' FROM results WHERE nic_no='"+sid+"'";
                SqlCommand comm = new SqlCommand(sql, DBCon);
                DBCon.Open();
                SqlDataReader nwReader = comm.ExecuteReader();
                while (nwReader.Read())
                {
                    double id = (double)nwReader["Avarage"];
                    int i = Convert.ToInt32(id);
                    avg.Text = "Avarage : "+System.Convert.ToString(id) + '%';
                    
                }
                nwReader.Close();
                DBCon.Close();
            }
        }
        public void GetClsAvg()
        {
            String sid = subid.Text;

            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                String sql = "SELECT AVG(marks) as 'Avarage' FROM results WHERE  subject_id='" + sid + "'";
                SqlCommand comm = new SqlCommand(sql, DBCon);
                DBCon.Open();

                object scalarVal = comm.ExecuteScalar();

                if (scalarVal == null)
                {
                    cls_avg.Text = "Class Avarage :O %";
                    cls_avg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {

                    cls_avg.Text = "Class Avarage : " + System.Convert.ToString(scalarVal) + '%';
                    cls_avg.ForeColor = System.Drawing.Color.Red;
                }

                DBCon.Close();
            }
        }
    }
}