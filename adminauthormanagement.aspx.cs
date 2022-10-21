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
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //add button 
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkExist())
            {
                Response.Write("<script> alert ('Author ID already exists. Try something else!'); </script>");
            }
            else
            {
               addAuthor();
            }
        }
        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkExist())
            {
                updateAuthor();
            }
            else
            {
                Response.Write("<script> alert ('Author ID doesnot exist. Try something else!'); </script>");
            }
        }
        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkExist())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<script> alert ('Author ID doesnot exist. Try something else!'); </script>");
            }
        }
        //go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getAuthor();
        }

        void getAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl WHERE author_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl WHERE author_id = '" + TextBox1.Text.Trim() + "'", con);
                //cmd.Parameters.AddWithValue("@authorname", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert ('Author Deleted Successfully'); </script>");
                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "'); </script>");
            }
        }

        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name = @authorname WHERE author_id = '"+ TextBox1.Text.Trim() +"'", con);
                cmd.Parameters.AddWithValue("@authorname", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert ('Author Updated Successfully'); </script>");
                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "'); </script>");
            }
        }


        void addAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl([author_id],[author_name]) VALUES(@id, @authorname)", con);
                cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@authorname", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert ('Author Added Successfully'); </script>");
                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "'); </script>");
            }
        }

        //user defined function
        bool checkExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE [author_id] = '" + TextBox1.Text.Trim() + "'; ", con);
                SqlDataAdapter da =   new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "'); </script>");
                return false;
            }
        }
        void clear()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}