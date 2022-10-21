using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWeb
{
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Response.Write("<script> alert ('Clicked'); </script>");
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE [member_id]='"+TextBox1.Text.Trim()+"' AND [password]='"+TextBox2.Text.Trim()+"'",con);
                SqlDataReader dr = cmd.ExecuteReader(); // this is a connected architechture where once database is connected it keeps on connecting until closed manually.

                if (dr.HasRows) //only send true or false whether the query gives atleast one row or zero row
                {
                    while (dr.Read())
                    {
                        Response.Write("<script> alert ('Login Successful'); </script>");
                        //creating session variables. These are global variables.
                        Session["username"] = dr.GetValue(8).ToString();
                        Session["fullname"] = dr.GetValue(0).ToString();
                        Session["status"] = dr.GetValue(10).ToString();
                        Session["role"] = "user";
                    }
                    Response.Redirect("homepage.aspx");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "'); </script>");
            }

        }
    }
}