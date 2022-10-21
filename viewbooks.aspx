<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="FirstWeb.viewbooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
            $(document).ready(function () {
                $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col">
           <center> <h3>Books Availabe</h3></center>
        </div>
    </div>
    
    <center>
        <div class="col-md-6">
            <hr />
        <div class="row">
         <div class="col">
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
            <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="book_id" HeaderText="book_id" ReadOnly="True" SortExpression="book_id">
                        <ItemStyle Font-Bold ="true" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-lg-10">
                                                <div class="row">
                                                     <div class="col-12">
                                                            <asp:Label ID="label5" runat="server" Font-Bold="True" Text='<%# Eval("book_name") %>'></asp:Label>
                                                     </div>
                                                     <div class="col-12">
                                                            Author- <asp:Label ID="label1" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label> | Genre- <asp:Label ID="label6" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label> | Language- <asp:Label ID="label7" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label> 
                                                     </div>
                                                     <div class="col-12">
                                                             Publisher- <asp:Label ID="label2" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label> | Publishe Date- <asp:Label ID="label8" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label> | Pages- <asp:Label ID="label9" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label> | Edition- <asp:Label ID="label10" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>
                                                     </div>
                                                     <div class="col-12">
                                                             Cost- <asp:Label ID="label3" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label> | Actual Stock- <asp:Label ID="label12" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label> | Availabe Stock- <asp:Label ID="label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>
                                                     </div>
                                                     <div class="col-12">
                                                             Description- <asp:Label ID="label4" runat="server" Font-Bold="True" Text='<%# Eval("book_description") %>'></asp:Label>
                                                     </div>
                                              </div>  
                                          </div>
                                            
                            <div class="col-lg-2">
                                <asp:Image class="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                            </div>
                        </div>
                    </div>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
             </asp:GridView>
         </div>
    </div>
    </div>
    </center>
    
        

</asp:Content>
