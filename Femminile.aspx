<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Femminile.aspx.cs" Inherits="InternalWebSiteStats.Femminile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    <br />
    <br />
        <p>
        <asp:Button ID="btnPools" runat="server" OnClick="btnPools_Click" Text="Pools" class="btn btn-primary btn-lg" BackColor="#6e7bd9"/>
        <asp:Button ID="btnStats" runat="server" OnClick="btnStats_Click" Text="Statistics" class="btn btn-primary btn-lg" BackColor="#6e7bd9"/>

    </p>
    <%--<asp:GridView runat="server" ID="poolsDataGrid" UseAccessibleHeader="true" CssClass="table table-condensed table-hover" Width="100%" />--%>
    <asp:Panel ID="gridPanel" runat="server"></asp:Panel>
    <asp:GridView runat="server" ID="statsDataGrid" UseAccessibleHeader="true" CssClass="table table-condensed table-hover" Width="100%" />
</asp:Content>
