<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="Practica_Session.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center;">
    <h2> Catálogo de Cursos</h2>
    <p>Haz clic en un botón para guardar la selección en la <b>Session</b>:</p>
    <hr />

    <asp:Button ID="btnNivel3" runat="server" Text="Elegir C# Nivel 3" OnClick="btnNivel3_Click" style="padding: 10px; margin: 5px;"/>
    <br />
    <asp:Button ID="btnProg2" runat="server" Text="Elegir Programación II" OnClick="btnProg2_Click" style="padding: 10px; margin: 5px;"/>
</div>
</asp:Content>
