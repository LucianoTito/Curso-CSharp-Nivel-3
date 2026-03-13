<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoCursos.aspx.cs" Inherits="PracticaSession.ListadoCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding: 21px;">   

        
        <h2>📚 Listado Completo de Cursos Disponibles</h2>

        <asp:GridView ID ="dgvCursos" runat ="server" AutoGenerateColumns="true" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
            <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" /> 
            </asp:GridView>


    </div>
</asp:Content>
