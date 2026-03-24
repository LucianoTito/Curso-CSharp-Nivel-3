<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PokedexWeb.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-header text-center bg-dark text-white">
                        <h2>Crear tu perfil Trainee</h2>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <label class="form-label">Email</label>
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="tu@email.com" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Password</label>
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" />
                        </div>
                        
                        <div class="d-grid gap-2">
                            <asp:Button Text="Registrarse" runat="server" ID="btnRegistrarse" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" />
                            <a href="Default.aspx" class="btn btn-outline-secondary">Cancelar</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
