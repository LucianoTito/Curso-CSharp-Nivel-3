<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PokedexWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-4">
            <div class="card">
                <div class="card-header text-center bg-success text-white">
                    <h4>Iniciar Sesión</h4>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <asp:Label Text="Email:" runat="server" CssClass="form-label" />
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="tu@email.com" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Contraseña:" runat="server" CssClass="form-label" />
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                    </div>
                    <div class="d-grid gap-2">
                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-success" OnClick="btnIngresar_Click" />
                        <a href="Default.aspx" class="btn btn-outline-secondary">Cancelar</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>