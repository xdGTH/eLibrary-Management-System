<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagement.aspx.cs" Inherits="FirstWeb.adminpublishermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        

                        <div class="row">
                            <div class="col">
                                <center><h3>Publisher Details</h3>
                                </center>
                                <hr/>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/publisher.png" /></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Publisher ID</label>
                                
                                <div class="form-group">
                                    <div class ="input-group">
                                    <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                    <asp:Button class="btn btn-secondary" ID="Button2" runat="server" Text="GO" OnClick="Button2_Click" ></asp:Button>
                                        </div>
                                </div>
                                
                            </div>
                            <div class="col-md-8">
                                <label>Publisher Name</label>
                                
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Name"></asp:TextBox>
                                </div>
                                
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                   <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="ADD" OnClick="Button1_Click" ></asp:Button>
                            </div>
                            <div class="col-4">
                                    <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button6" runat="server" Text="UPDATE" OnClick="Button6_Click" ></asp:Button>
                                   
                            </div>
                            <div class="col-4">
                                    <asp:Button class="btn btn-danger btn-lg btn-block" ID="Button10" runat="server" Text="DELETE" OnClick="Button10_Click" ></asp:Button>
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
                                <center><h3>Publisher List</h3>
                                </center>
                                <hr/>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                                <asp:GridView class="table table-dark table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>

    </div>

</asp:Content>
