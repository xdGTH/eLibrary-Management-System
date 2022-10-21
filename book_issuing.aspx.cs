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
    public partial class book_issuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getByID();
        }

        //issue button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkifBookExist() && checkifMemberExist())
            {
                if (checkifIssueExist())
                {
                    Response.Write("<script>alert ('Member has this Book issued already'); </script>");
                }
                else
                {
                    issueBook();
                }
            }
            else
            {
                Response.Write("<script>alert ('Wrong Book ID or Member ID'); </script>");
            }
        }

        //return button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if(checkifBookExist() && checkifMemberExist())
            {
                if (checkifIssueExist())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script>alert ('Book Isnot Issued to be removed'); </script>");
                }
            }
            else
            {
                Response.Write("<script>alert ('wrong Book ID or Member ID'); </script>");
            }
        }

        //user defined functions

        //returning
        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tbl WHERE book_id = '" + TextBox3.Text.Trim() + "' AND member_id = '" + TextBox4.Text.Trim() + "'",con);
                int result = cmd.ExecuteNonQuery(); //execute non query returns the number of rows affected

                if(result > 0)
                {
                    //here the textboxes arenot cleared so the text is taken and is used to filter the book_id
                    cmd = new SqlCommand("UPDATE book_master_tbl SET [current_stock] = current_stock + 1 WHERE [book_id] = '" + TextBox3.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert ('Book Returned Successfully'); </script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert ('Invalid Details'); </script>");
                }

                con.Close();
                GridView1.DataBind();
                
                clearform();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");
            }
        }

        //issuing
        void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl([member_id],[member_name],[book_id],[book_name],[issue_date],[due_date])" +
                    "VALUES(@member_id, @member_name, @book_id, @book_name, @issue_date, @due_date)",con);
                cmd.Parameters.AddWithValue("@member_id", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox8.Text.Trim());

                cmd.ExecuteNonQuery();
                //after issuing any book the current_stock from book_master_tbl will decrease
                cmd = new SqlCommand("UPDATE book_master_tbl SET [current_stock] = current_stock-1 WHERE [book_id] = '" + TextBox3.Text.Trim() + "'",con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert ('Book Issued Successfully'); </script>");
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");
            }
        }

        //check exists

        bool checkifBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = '" + TextBox3.Text.Trim() + "' AND current_stock > 0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");
                return false;
            }
        }

        bool checkifIssueExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE book_id = '" + TextBox3.Text.Trim() + "' AND member_id = '" + TextBox4.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");
                return false;
            }
        }

        bool checkifMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id = '" + TextBox4.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");
                return false;
            }
        }

        //getByID
        void getByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT full_name FROM member_master_tbl WHERE member_id = '" + TextBox4.Text.Trim() + "'",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count >= 1)
                {
                    TextBox5.Text = dt.Rows[0]["full_name"].ToString() ;
                }
                else
                {
                    Response.Write("<script>alert ('Wrong Member ID'); </script>");
                }


                cmd = new SqlCommand("SELECT book_name FROM book_master_tbl WHERE book_id = '" + TextBox3.Text.Trim() + "'", con);
                da = new SqlDataAdapter (cmd);
                dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count >= 1)
                {
                    TextBox6.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert ('Wrong Book ID'); </script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "'); </script>");
            }
        }

        void clearform()
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
        }

        //this fires on every rows
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) //checks if the row is proper with some values
                {
                    DateTime due = Convert.ToDateTime(e.Row.Cells[5].Text); //database has a string stored in it as date and we are converting it to proper data and time
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
    }
}