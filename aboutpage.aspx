<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="aboutpage.aspx.cs" Inherits="FirstWeb.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <img class="img-fluid" src="images/home-bg.jpg" />
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center><h1><b>About Elibrary</b></h1>
                    
                    </center>
                </div>
            </div>

                <div class="row">
                    <div class="col-md-6">
                        <center><img width="200px" src="images/digital-data.png" />
                        <h4>Hello World</h4>
                        <p class="text-justify">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla rhoncus purus vitae 
                            libero dignissim, quis blandit augue fringilla. Quisque vitae lobortis odio, eu 
                            vehicula diam. Praesent vel urna vel ex ullamcorper dapibus ut sed lorem. Orci 
                            varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.
                        </p>
                        </center>
                    </div>

                    <div class="col-md-6">
                        <center><img width="200px" src="images/digital-inventory.png" />
                        <h4>Hello World 1</h4>
                        <p class="text-justify">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla rhoncus purus vitae 
                            libero dignissim, quis blandit augue fringilla. Quisque vitae lobortis odio, eu 
                            vehicula diam. Praesent vel urna vel ex ullamcorper dapibus ut sed lorem. Orci 
                            varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.
                        </p>
                        </center>
                    </div>
                </div>

            
        </div>
    </section>
</asp:Content>
