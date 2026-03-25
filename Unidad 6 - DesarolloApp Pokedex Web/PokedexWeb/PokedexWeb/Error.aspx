<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="PokedexWeb.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-6">
            <div class="card border-danger mb-3">
                <div class="card-header bg-danger text-white">
                    <h4>¡Ups! Hubo un problema</h4>
                </div>
                <div class="card-body text-center">
                    <p class="card-text">
                        <%-- Muestro el mensaje técnico o la validación --%>
                        <asp:Label ID="lblMensaje" runat="server" CssClass="fs-5 text-danger"></asp:Label>
                    </p>
                    <div class="mt-4">
                        <%-- Botón de escape (Llamado a la acción)  --%>
                        <asp:Button ID="btnVolver" runat="server" Text="Volver al Inicio" CssClass="btn btn-outline-dark" OnClick="btnVolver_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
