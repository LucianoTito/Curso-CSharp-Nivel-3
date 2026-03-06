<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="Parámetros_por_URL___QuickWatch.Cursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>📚 Catálogo de Cursos UTN / Maxi Programa</h2>
        <p>Seleccioná un curso para ver los detalles:</p>
        <br />

        <asp:Button ID="btnNivel3" runat="server" Text="Ver C# Nivel 3" OnClick="btnNivel3_Click" />
        <br /><br />

        <asp:Button ID="btnProg2" runat="server" Text="Ver Programación II" OnClick="btnProg2_Click" />
        <br /><br />

        <asp:Button ID="btnBBDD" runat="server" Text="Ver Bases de Datos" OnClick="btnBBDD_Click" />
    </div>
</asp:Content>