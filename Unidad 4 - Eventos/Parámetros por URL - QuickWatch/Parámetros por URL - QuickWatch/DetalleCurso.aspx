<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleCurso.aspx.cs" Inherits="Parámetros_por_URL___QuickWatch.DetalleCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="padding: 20px;">
    <h2>🔍 Detalle del Curso Seleccionado</h2>
    <hr />
    
    <asp:Label ID="lblMensaje" runat="server" Font-Size="Large" ForeColor="Blue"></asp:Label>
    
    <br /><br />
    <a href="Cursos.aspx">⬅ Volver al Catálogo</a>
</div>
</asp:Content>
