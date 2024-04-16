<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InternalWebSiteStats._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <p class="lead">Show current stats and results choosing the category</p>
            <p>
                <a href="Maschile.aspx" class="btn btn-primary btn-lg"" style="width: 150px; background-color: #6e7bd9">Male &raquo;</a>
                <a href="Femminile.aspx" class="btn btn-primary btn-lg" style="width: 150px; background-color: #6e7bd9">Female &raquo;</a>

            </p>

        </section>
        <table style="width: 100%">
            <tr>
                <td style="align-content: center">
                    <asp:Image runat="server" ID="bannerImage" ImageUrl="~/Images/atleta_sfondo_bianco.jpg" Width="75%" />
                </td>
            </tr>
        </table>
    </main>

</asp:Content>
