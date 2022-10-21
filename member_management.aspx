<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="member_management.aspx.cs" Inherits="FirstWeb.member_management" %>
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
                                <center><h3>Member Info</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/generaluser.png" /></center>
                            </div>
                        </div>
                        <hr/>

                        <div class="row">
                            <div class="col-md-3">
                                <label>USER ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="User ID"></asp:TextBox>
                                        <asp:Button class="btn btn-secondary" ID="Button4" runat="server" Text="GO" OnClick="Button4_Click" ></asp:Button>

                                    </div>
                                </div>
                                
                            </div>
                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                         <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Name" ReadOnly="true"></asp:TextBox> 
                                </div>
                                
                            </div>
                            <div class="col-md-5">
                                <label>Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                         <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="Status" ReadOnly="true"></asp:TextBox>
                                         <asp:Button class="btn btn-success mr-1" ID="Button5" runat="server" Text="A" OnClick="Button5_Click" ></asp:Button>
                                         <asp:Button class="btn btn-danger mr-1" ID="Button1" runat="server" Text="P" OnClick="Button1_Click" ></asp:Button>
                                         <asp:Button class="btn btn-warning mr-1" ID="Button6" runat="server" Text="D" OnClick="Button6_Click" ></asp:Button>

                                    </div>
                                   
                                </div>
                                
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox4" runat="server" ReadOnly="true" TextMode="Date"></asp:TextBox>
                                </div>
                                
                            </div>
                            <div class="col-md-4">
                                <label>Contact</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="-" ReadOnly="true"></asp:TextBox>
                                </div>  
                            </div>
                            <div class="col-md-5">
                                <label>E-mail</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="abc@example.com" ReadOnly="true"></asp:TextBox>
                                </div>
                        </div>

                    </div>

                         <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox7" runat="server" ReadOnly="true" placeholder="State"></asp:TextBox>
                                </div>
                                
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox8" runat="server" ReadOnly="true" placeholder="City"></asp:TextBox>
                                </div>
                                
                            </div>
                             <div class="col-md-4">
                                <label>Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server" ReadOnly="true" placeholder="Pin Code"></asp:TextBox>
                                </div>
                                
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <label>Full Postal Address</label>
                                 <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server" ReadOnly="true" placeholder="Address" TextMode="MultiLine"></asp:TextBox>
                                </div>

                            </div>

                        </div>

                         <div class="row">
                            <div class="col-12">
                                   <asp:Button class="btn btn-danger btn-block btn-lg" ID="Button3" runat="server" Text="Delete Permanently" OnClick="Button3_Click1" ></asp:Button> 
                            </div>
                                
                        </div>
                </div>              

            </div>
           </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center><h3>Members List</h3>
                                </center>
                                <hr/>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT [full_name], [dob], [contact_no], [email], [state], [city], [pincode], [full_address], [member_id], [account_status] FROM [member_master_tbl]"></asp:SqlDataSource>
                                <asp:GridView class="table table-dark table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id" ReadOnly="True" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
          <a href="homepage.aspx"><--Back to Home </a>
                <br />

    </div>

</asp:Content>
