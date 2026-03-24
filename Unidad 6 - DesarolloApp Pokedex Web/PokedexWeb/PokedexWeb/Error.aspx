<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="PokedexWeb.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5 text-center">
        <h1 class="text-danger">Hubo un problema</h1>
        <asp:Label ID="lblMensaje" runat="server" CssClass="fs-4"></asp:Label>
    </div>
</asp:Content>
