<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCurso.aspx.cs" Inherits="PracticaSession.DetalleCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding: 20px;">
    <h2>🔍 Información del Curso Recuperada</h2>
    <hr />
    
    <asp:Label ID="lblDetalle" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
    
    <br /><br />
    <a href="Cursos.aspx">⬅ Volver al Catálogo</a>
</div>
</asp:Content>
