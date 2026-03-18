<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaCursos.aspx.cs" Inherits="Seleccionar_Registro.ListaCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    
    <div style="padding: 20px;">
    <h2>📋 Listado Completo de Cursos (Modo Manual)</h2>
    <asp:GridView  ID="dgvCursos" runat="server" 
        DataKeyNames ="ID" 
        OnSelectedIndexChanged="dgvCursos_SelectedIndexChanged" 
        AutoGenerateColumns="false"
        BackColor="White" 
        BorderColor="#CCCCCC" 
        BorderStyle="None" 
        BorderWidth="1px" 
        CellPadding="3">
            
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Código Interno" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre del Curso" />
            <asp:BoundField DataField="Nivel" HeaderText="Nivel de dificultad" />
            
            <asp:CommandField ShowSelectButton="True"
                SelectText="Seleccionar"  
                HeaderText="Acción" />
           
            </Columns>
     
      

        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
</div>
</asp:Content>
