using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWeb
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null) //Session["role"]==null
                {
                    LinkButton1.Visible=true; //user Login Button
                    LinkButton2.Visible=true;  //User Sign Up Button
                    LinkButton3.Visible = false; //logout button
                    LinkButton7.Visible = false; //hello user button
                    LinkButton6.Visible = true; //admin login button
                    LinkButton11.Visible = false; //Author Management button
                    LinkButton12.Visible = false; //publisher management button
                    LinkButton8.Visible = false; //book inventory button
                    LinkButton9.Visible = false; //book issuing button
                    LinkButton10.Visible = false; //member management button
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; //user Login Button
                    LinkButton2.Visible = false;  //User Sign Up Button
                    LinkButton3.Visible = true; //logout button
                    LinkButton7.Visible = true; //hello user button
                    LinkButton7.Text = "Hello " + Session["username"].ToString();
                    LinkButton6.Visible = true; //admin login button
                    LinkButton11.Visible = false; //Author Management button
                    LinkButton12.Visible = false; //publisher management button
                    LinkButton8.Visible = false; //book inventory button
                    LinkButton9.Visible = false; //book issuing button
                    LinkButton10.Visible = false; //member management butto
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; //user Login Button
                    LinkButton2.Visible = false;  //User Sign Up Button
                    LinkButton3.Visible = true; //logout button
                    LinkButton7.Visible = true; //hello user button
                    LinkButton7.Text = "Hello " + Session["fullname"].ToString() ;
                    LinkButton6.Visible = false; //admin login button
                    LinkButton11.Visible = true; //Author Management button
                    LinkButton12.Visible = true; //publisher management button
                    LinkButton8.Visible = true; //book inventory button
                    LinkButton9.Visible = true; //book issuing button
                    LinkButton10.Visible = true; //member management butto
                }
            }
            catch(Exception ex) 
            {
                Response.Write("<scrip>alert ('" + ex.Message + "'); </script>");
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("book_inventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("book_issuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("member_management.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["status"] = "";
            Session["role"] = "";
            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}