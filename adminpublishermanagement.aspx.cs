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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //add button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkExists())
            {
                Response.Write("<script>alert ('Publisher Already Exists. Try another ID'); </script>");
            }
            else
            {
                addPublisher();
            }
        }

        //update button
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (checkExists())
            {
                updatePublisher();
            }
            else
            {
                Response.Write("<script>alert ('Invalid ID. ID doesnot Exist'); </script>");
            }
        }

        //delete button
        protected void Button10_Click(object sender, EventArgs e)
        {
            if (checkExists())
            {
                deletePublisher();
            }
            else
            {
                Response.Write("<script>alert ('Invalid ID. ID doesnot Exist'); </script>");
            }
        }

        //go button
        protected void Button2_Click(object sender, EventArgs e)
        {
             goButton();
        }

        //user defined methods


        //delete button
        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl WHERE publisher_id = '" + TextBox1.Text.Trim() + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert ('Publisher Deleted successfully'); </script>");
                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");

            }
        }

        //go
        void goButton()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE publisher_id = '" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count>=1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert ('ID doesnot exist.'); </script>");
                }
                //clear();
                //GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");

            }
        }

        void addPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl([publisher_id],[publisher_name]) VALUES(@id,@name) ", con);
                cmd.Parameters.AddWithValue("@id",TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@name",TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert ('Publisher Added Successfully'); </script>");
                con.Close();
                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");
               
            }
        }

        //updates data
        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name = @name WHERE publisher_id = '" + TextBox1.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert ('Publisher Updated Successfully'); </script>");
                con.Close();
                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");

            }
        }

        //clears textbox
        void clear()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        //checks data exists or not
        bool checkExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE publisher_id = '" + TextBox1.Text.Trim() + "'",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >=1)
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
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");
                return false;
            }
        }
    }
}