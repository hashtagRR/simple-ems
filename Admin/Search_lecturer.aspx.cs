﻿using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exam.Admin
{
    public partial class Search_lecturer : System.Web.UI.Page
    {
        private String ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isloggedin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ViewAll();
            }
        }

        public void ViewAll()
        {
            using (SqlConnection DBCon = new SqlConnection(ConStr))
            {
                DBCon.Open();
                SqlCommand sqlcmd = new SqlCommand("Select lecturer_id as 'Lecturer ID',full_name as 'Full name',nic_no as 'NIC No',contact_no as 'Contact',subject_id as 'Subject ID' FROM lecturer ORDER BY full_name ASC", DBCon);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                dgv1.DataSource = reader;
                dgv1.DataBind();
                dgv1.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (sid.Text == String.Empty)
            {
                Label1.Text = "Please insert the Lecturer ID";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                nic.Text = " ";
                string id = sid.Text;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Select lecturer_id as 'Lecturer ID',full_name as 'Full name',nic_no as 'NIC No',contact_no as 'Contact',subject_id as 'Subject ID' FROM lecturer WHERE lecturer_id='" + id + "'", DBCon);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dgv2.DataSource = reader;
                        dgv2.DataBind();
                        dgv2.Visible = true;
                        Label1.Text = " ";
                        Label2.Text = " ";
                    }
                    else
                    {
                        Label1.Text = "No records are avaliable for this Lecturer ID";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (sid.Text == String.Empty)
            {
                Label2.Text = "Please insert the Lecturer NIC No";
                Label2.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                sid.Text = " ";
                string id = nic.Text;

                using (SqlConnection DBCon = new SqlConnection(ConStr))
                {
                    DBCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Select lecturer_id as 'Lecturer ID',full_name as 'Full name',nic_no as 'NIC No',contact_no as 'Contact',subject_id as 'Subject ID' FROM lecturer WHERE nic_no='" + id + "'", DBCon);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dgv2.DataSource = reader;
                        dgv2.DataBind();
                        dgv2.Visible = true;
                        Label1.Text = " ";
                        Label2.Text = " ";
                    }
                    else
                    {
                        Label2.Text = "No records are avaliable for this Lecturer NIC No";
                        Label2.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
}