using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWeb
{
    public partial class book_inventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        //same copy of variables throughout the program
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
            if (!IsPostBack) //ispostback means refreshed a page. here not ispostback means loaded the page for the first time
            {
                fillAuthorPublisherValue();
            }
        }

        //go button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkBookExist())
            {
                getbyID();
            }
            else
            {
                Response.Write("<script>alert ('Enter valid Book ID');</script>");
            }
        }

        //add button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkBookExist())
            {
                Response.Write("<script>alert ('Book ID is not availabe.');</script>");
            }
            else
            {
                addBooks();
            }
        }

        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkBookExist())
            {
                update();
            }
            else
            {
                Response.Write("<script>alert ('Invalid Book ID.');</script>");
            }
        }

        //delete button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkBookExist())
            {
                delete();
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID.');</script>");
            }
        }


        //user defined functions

        //check
        bool checkBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = '" + TextBox1.Text.Trim() + "' OR book_name = '" + TextBox2.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    //Response.Write("<script>alert ('Member ID is INVALID');</script>");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "');</script>");
                return false;
            }
        }


        //add 
        void addBooks()
        {
            try
            {
                string genre = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genre += ListBox1.Items[i] + ",";
                }// genre = a,b,c, here last element will be comma so we are removing it
                genre = genre.Remove(genre.Length -1);

                string filepath = "~/book_inventory/book-icon-transparent-20.jpg";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/book_inventory/") + filename);
                filepath = "~/book_inventory/" + filename;

                SqlConnection con = new SqlConnection(strcon);
                if(con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl([book_id],[book_name],[genre],[author_name],[publisher_name],[publish_date],[language],[edition],[book_cost],[no_of_pages],[book_description],[actual_stock],[current_stock],[book_img_link]) " +
                    "VALUES(@id,@name,@genre,@author,@publisher,@date,@language,@edition,@cost,@pages,@description,@actualStock,@currentStock,@image)", con);
                cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@author", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@pages", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@actualStock", TextBox4.Text.Trim()); //when adding a book actual stock and current stock will be the same.
                cmd.Parameters.AddWithValue("@currentStock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@image", filepath);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully.');</script>");
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "');</script>");
            }
        }

        //delete method
        void delete()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tbl WHERE book_id = '" + TextBox1.Text.Trim() + "'",con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert ('Book Removed.')");

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "');</script>");
            }
        }

        //go button
        void getbyID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString();
                    TextBox3.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox9.Text = dt.Rows[0]["edition"].ToString();
                    TextBox10.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox11.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["book_description"].ToString();
                    TextBox7.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(','); //we used ',' to seperate the genres so we define , as a spillter and removing it
                    for (int i= 0; i< genre.Length; i++) 
                    {
                        for(int j= 0; j< ListBox1.Items.Count ; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i]) 
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                            
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock ;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert ('Invalid Book ID')");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "');</script>");
            }
        }

        //update button

        void update()
        {
            try
            {
                int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
                int current_stock = Convert.ToInt32(TextBox5.Text.Trim());

                if (actual_stock == global_actual_stock)
                {

                }
                else
                {
                    if (actual_stock < global_issued_books)
                    {
                        Response.Write("<script>alert ('Actual Stock cannot be less than issued books'); </script>");
                        return;
                    }
                    else
                    {
                        current_stock = actual_stock - global_issued_books;
                        TextBox5.Text = "" + current_stock;
                    }
                }


                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres += ListBox1.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/book-icon-transparent-20.jpg";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

                if (filename == "" || filename == null)
                {
                    filepath = global_filepath;
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;
                }

                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET " +
                    "book_name=@book_name, genre=@genre, author_name=@author_name, " +
                    "publisher_name=@publisher_name, publish_date=@publish_date, language=@language," +
                    " edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, " +
                    "book_description=@book_description, actual_stock=@actual_stock, " +
                    "current_stock=@current_stock, book_img_link=@book_img_link " +
                    "WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@book_name",TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);
                
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert ('Book Updated Successfully');</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "');</script>");
            }
        }

        void fillAuthorPublisherValue()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name FROM author_master_tbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tbl", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert ('" + ex.Message + "');</script>");
            }
        }
    }
}