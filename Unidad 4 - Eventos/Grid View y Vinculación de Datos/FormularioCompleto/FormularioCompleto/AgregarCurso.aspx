<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCurso.aspx.cs" Inherits="FormularioCompleto.AgregarCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
    <h2>➕ Agregar Nuevo Curso</h2>
    <hr />
    
    <div class="row">
        <div class="col-md-6">
            
            <div class="mb-3">
                <label class="form-label">Código (ID):</label>
                <asp:TextBox ID="txtID" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Nombre del Curso:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Descripción:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Nivel:</label>
                <asp:DropDownList ID="ddlNivel" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Inicial" Value="Inicial"></asp:ListItem>
                    <asp:ListItem Text="Intermedio" Value="Intermedio"></asp:ListItem>
                    <asp:ListItem Text="Avanzado" Value="Avanzado"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label class="form-label">Fecha de Inicio:</label>
                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="form-check mb-4">
                <asp:CheckBox ID="chkPresencial" runat="server" CssClass="form-check-input" />
                <label class="form-check-label">¿Es Presencial?</label>
            </div>

            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
            <a href="ListaCursos.aspx" class="btn btn-secondary ms-2">Cancelar</a>
            
        </div>
    </div>
</div>
</asp:Content>
