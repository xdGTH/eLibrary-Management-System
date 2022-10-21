<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="FirstWeb.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <img src="images/home-bg.jpg" class="img-fluid" />
    </section>
    <section>
        <div class="container">
           <%-- 1st row--%>
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2>Our features</h2>
                     <p><b>Our 3 Primary Features</b></p>
                    </center>
                </div>
                </div>
           <%-- 2nd row--%>
                <div class="row">
                    <div class="col-md-4">
                        <center>
                        <img width ="150px" src="images/digital-inventory.png" />
                        <h4>Digital Book Inventory</h4>
                        <p class="text-justify">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla rhoncus purus vitae 
                            libero dignissim, quis blandit augue fringilla. Quisque vitae lobortis odio, eu 
                            vehicula diam. Praesent vel urna vel ex ullamcorper dapibus ut sed lorem. Orci 
                            varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.
                        </p>
                        </center>
                    </div>
                    <div class="col-md-4">
                        <center>
                        <img width="150px" src="images/search-online.png" />
                        <h4>Search Books</h4>
                        <p class="text-justify">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla rhoncus purus vitae 
                            libero dignissim, quis blandit augue fringilla. Quisque vitae lobortis odio, eu 
                            vehicula diam. Praesent vel urna vel ex ullamcorper dapibus ut sed lorem. Orci 
                            varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.
                        </p>
                        </center>
                    </div>
                    <div class="col-md-4">
                        <center>
                        <img width="150px" src="images/defaulters-list.png" />
                        <h4>Defaulters Lists</h4>
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

    <section>
        <img src="images/in-homepage-banner.jpg" class="img-fluid" />
    </section>

     <section>
        <div class="container">
           <%-- 1st row--%>
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2>Our Processes</h2>
                     <p><b>We have 3 simple processes</b></p>
                    </center>
                </div>
           <%-- 2nd row--%>
                <div class="row">
                    <div class="col-md-4">
                        <center>
                        <img width ="150px" src="images/sign-up.png" />
                        <h4>Sign-Up</h4>
                        <p class="text-justify">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla rhoncus purus vitae 
                            libero dignissim, quis blandit augue fringilla. Quisque vitae lobortis odio, eu 
                            vehicula diam. Praesent vel urna vel ex ullamcorper dapibus ut sed lorem. Orci 
                            varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.
                        </p>
                        </center>
                    </div>
                    <div class="col-md-4">
                        <center>
                        <img width="150px" src="images/search-online.png" />
                        <h4>Search Books</h4>
                        <p class="text-justify">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla rhoncus purus vitae 
                            libero dignissim, quis blandit augue fringilla. Quisque vitae lobortis odio, eu 
                            vehicula diam. Praesent vel urna vel ex ullamcorper dapibus ut sed lorem. Orci 
                            varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.
                        </p>
                        </center>
                    </div>
                    <div class="col-md-4">
                        <center>
                        <img width="150px" src="images/library.png" />
                        <h4>Visit Us</h4>
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
        </div>
    </section>


</asp:Content>
