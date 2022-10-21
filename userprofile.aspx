<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="FirstWeb.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/generaluser.png" /></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center><h3>Your Profile</h3>
                                <span>Account Status-</span>
                                
                                <asp:Label class="badge badge-pill badge-success" ID="Label1" runat="server" Text="Your Status"></asp:Label>
                                </center>
                                <hr/>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                                
                            </div>
                            <div class="col-md-6">
                                
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="Date Of Birth"></asp:TextBox>
                                </div>
                                
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="Contact Number"></asp:TextBox>
                                </div>
                                
                            </div>
                            <div class="col-md-4">
                                
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="Email ID"></asp:TextBox>
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
                                    <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="City"></asp:TextBox>
                                </div>
                                
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Pin Code"></asp:TextBox>
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
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="User ID" ReadOnly="true"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Password" ReadOnly="true"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                                </div>

                            </div>

                        </div>

                        <div class="row">
                            <div class="col-8 mx-auto">
                            <center>
                                <div class="form-group">
                                   <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" ></asp:Button> 
                                </div>
                                </center>
                            </div>
                                
                        </div>

                    </div>
                </div>

                <a href="homepage.aspx"><--Back to Home </a>
                <br />

            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/book-icon-transparent-20.jpg" /></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center><h3>Your Issued Book</h3>
                                    
                                <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text="Info of due Date"></asp:Label>
                                </center>
                                <hr/>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-dark table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound">
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>

    </div>

</asp:Content>
