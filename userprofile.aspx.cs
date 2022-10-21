using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWeb
{
    public partial class userprofile : System.Web.UI.Page 
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert ('Session Expired. Login again'); </script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                getBookData();
                if (!Page.IsPostBack)
                {
                    fill();
                }
            }
        }

        //update button
        protected void Button2_Click(object sender, EventArgs e)
        {
           if(Session["username"].ToString() == "" || Session["username"] == null)
           {
                Response.Write("<script>alert ('Session Expired. Login again'); </script>");
                Response.Redirect("userlogin.aspx");
            }
           else
           {
                update();
           }
        }

        //called for each row
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime due = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > due)
                    {
                        e.Row.BackColor = Color.IndianRed;
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");
            }
        }

        //user defined functions

        //update data
        void update()
        {
            string password = "";
            if(TextBox10.Text.Trim() == "")
            {
                password = TextBox2.Text;
            }
            else
            {
                password = TextBox10.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET [full_name]= @full_name, [dob]= @dob, [contact_no]= @contact_no, " +
                    "[email]= @email, [state]= @state, [city]= @city, [pincode]= @pincode," +
                    "[full_address]= @full_address, [password]= @password, [account_status]= @account_status WHERE [member_id]= '" + Session["username"].ToString() + "'",con);
                cmd.Parameters.AddWithValue("@full_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@city", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "Pending"); //once user edits the profile account status is changed to pending for the admin to verify it later and chance it to Active or Deactive.

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if(result > 0)
                {
                    Response.Write("<script>alert ('Updated Successfully'); </script>");
                    GridView1.DataBind();
                    fill();
                }
                else
                {
                    Response.Write("<script>alert ('Invalid Entry'); </script>");
                }
                
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");
            }
        }


        //fill credentials
        void fill()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE [member_id] = '" + Session["username"].ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox1.Text = dt.Rows[0]["member_id"].ToString();
                    TextBox2.Text = dt.Rows[0]["password"].ToString();
                    TextBox4.Text = dt.Rows[0]["full_name"].ToString();
                    TextBox3.Text = dt.Rows[0]["dob"].ToString();
                    TextBox5.Text = dt.Rows[0]["contact_no"].ToString();
                    TextBox6.Text = dt.Rows[0]["email"].ToString();
                    TextBox7.Text = dt.Rows[0]["full_address"].ToString();
                    TextBox8.Text = dt.Rows[0]["pincode"].ToString();
                    TextBox9.Text = dt.Rows[0]["city"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();

                    Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();
                    if (dt.Rows[0]["account_status"].ToString() == "Pending")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                    }
                    else if(dt.Rows[0]["account_status"].ToString() == "Active")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-success");
                    }
                    else if(dt.Rows[0]["account_status"].ToString() == "Deactive")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                    }
                    else
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-info");
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");
            }
        }

        //user book data
        void getBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE [member_id] = '" + Session["username"].ToString() + "'",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                con.Close();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");
            }
        }

        
    }
}