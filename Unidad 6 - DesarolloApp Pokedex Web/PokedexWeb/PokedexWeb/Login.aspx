<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PokedexWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-header text-center">
                        <h4>Ingreso de Entrenadores</h4>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <asp:Label Text="Usuario:" runat="server" CssClass="form-label" />
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
                        </div>
                        <div class="mb-3">
                            <asp:Label Text="Contraseña:" runat="server" CssClass="form-label" />
                            <%-- El TextMode="Password" oculta los caracteres con puntitos--%>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                        </div>
                        <div class="d-grid">
                            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnIngresar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>