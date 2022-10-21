<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="FirstWeb.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/adminuser.png" /></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center><h3>User SignUp</h3></center>
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                                
                            </div>
                            <div class="col-md-6">
                                
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                                
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="Contact Number"></asp:TextBox>
                                </div>
                                
                            </div>
                            <div class="col-md-4">
                                
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="Email ID"></asp:TextBox>
                                </div>
                                
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">

                                        <asp:ListItem Text="Select" Value="select"></asp:ListItem>
                                         <asp:ListItem Text="Mechi" Value="Mechi"></asp:ListItem>
                                         <asp:ListItem Text="Gandaki" Value="Gandaki"></asp:ListItem>
                                         <asp:ListItem Text="Bagmati" Value="Bagmati"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                
                            </div>

                            <div class="col-md-4">
                                
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="City"></asp:TextBox>
                                </div>
                                
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Pin Code"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center><span class="badge badge-pill badge-info">Login Credentials</span></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="User ID"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>

                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                   <asp:LinkButton class="btn btn-primary btn-block btn-lg" runat="server" ID="LinkButton2" Text="Sign Up" OnClick="LinkButton2_Click" ></asp:LinkButton> 
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <a href="homepage.aspx"><--Back to Home </a>
                <br />

            </div>
        </div>

    </div>
</asp:Content>
