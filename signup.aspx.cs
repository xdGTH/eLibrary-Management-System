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
    public partial class WebForm3 : System.Web.UI.Page
    {
        //strcon will hold the connection string value from Web.Config
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //signup button click event
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (memberexists())
            {
                Response.Write("<script> alert ('Member ID already exists. Try a New One'); </script>");
            }
            else
            {
                usersignup();
            }
        }

        //user defined functions

        bool memberexists() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon); //con object is passed with the strcon connection string.
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id = '"+TextBox8.Text.Trim()+"'", con); // two parameters one is query and another is connection object (con).
                
                SqlDataAdapter da = new SqlDataAdapter(cmd); // connecting to the database in a disconnected way .
                DataTable dt = new DataTable();
                da.Fill(dt); //values coming from da is stored in a table dt.

                if(dt.Rows.Count >= 1) { return true; }
                else { return false; }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "'); </script>");
                return false;
            }


             
        }
        void usersignup()
        {
            // Response.Write("<script> alert ('Testing'); </script>"); for popping some alert message
            //connecting to a database and workig with it might run into some exceptions so try catch blocks are used
            try
            {
                SqlConnection con = new SqlConnection(strcon); //con object is passed with the strcon connection string.
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(" +
                    "[full_name], [dob], [contact_no], [email], [state], [city], [pincode], [full_address], [member_id], [password], [account_status]) values" +
                    "(@fname,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", con); // two parameters one is query and another is connection object (con).
                //here @fname, @dob, ... are placeholders and can be written according to you but it should later match with cmd.Parameters.
                cmd.Parameters.AddWithValue("@fname", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();  //this statement is going to take the query and assign the placeholders and finally execute it.

                con.Close();
                Response.Write("<script> alert ('Sign Up successful please go to User Login Page'); </script>");
                Response.Redirect("homepage.aspx");
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "'); </script>");
            }
        }
    }
}