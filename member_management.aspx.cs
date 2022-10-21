using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWeb
{
    public partial class member_management : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //go button
        protected void Button4_Click(object sender, EventArgs e)
        {
            goButon();
        }

        //delete member button
        protected void Button3_Click1(object sender, EventArgs e)
        {
            if (checkExist())
            {
                delete();
            }
            else if (TextBox1.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert ('Member ID is not entered.');</script>");
            }
            else
            {
                Response.Write("<script>alert ('Member Doesnot Exist.');</script>");
            }
        }
        //active button
        protected void Button5_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text == "")
            {
                Response.Write("<script>alert ('Enter Member ID');</script>");
            }
            else if (checkExist())
            {
                setMemberbyID("Active");
                goButon();
            }
            else
            {
                Response.Write("<script>alert ('Member Doesnot Exist.');</script>");
            }

        }

        //pending button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                Response.Write("<script>alert ('Enter Member ID');</script>");
            }
            else if (checkExist())
            {
                setMemberbyID("Pending");
                goButon();
            }
            else
            {
                Response.Write("<script>alert ('Member Doesnot Exist.');</script>");
            }
        }

        //deactive status button
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                Response.Write("<script>alert ('Enter Member ID');</script>");
            }
            else if (checkExist())
            {
                setMemberbyID("Deactive");
                goButon();
            }
            else
            {
                Response.Write("<script>alert ('Member Doesnot Exist.');</script>");
            }
        }


        //user defined methods

        //active button
        void setMemberbyID(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET [account_status] = '" + status + "' WHERE [member_id] = '" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert ('Status changed.');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "');</script>");
            }
        }


        //delete permanently
        void delete()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl WHERE member_id = '" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert ('Member Deleted Permanently');</script>");
                clear();
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "');</script>");
            }
        }

        //getting member data
        void goButon()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(0).ToString();
                        TextBox3.Text = dr.GetValue(10).ToString();
                        TextBox4.Text = dr.GetValue(1).ToString();
                        TextBox5.Text = dr.GetValue(2).ToString();
                        TextBox6.Text = dr.GetValue(3).ToString();
                        TextBox7.Text = dr.GetValue(4).ToString();
                        TextBox8.Text = dr.GetValue(5).ToString();
                        TextBox9.Text = dr.GetValue(6).ToString();
                        TextBox10.Text = dr.GetValue(7).ToString();
                    }
                }
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "');</script>");
            }
        }

        //checking the data
        bool checkExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >=1)
                {
                    return true;
                }
                else
                {
                    Response.Write("<script>alert ('Member ID is INVALID');</script>");
                    return false;
                }

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert ('"+ex.Message+"');</script>");
                return false;
            }
        }

        void clear()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
        }

       
    }
}