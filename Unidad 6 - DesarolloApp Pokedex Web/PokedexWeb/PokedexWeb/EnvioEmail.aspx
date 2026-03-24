<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="EnvioEmail.aspx.cs" Inherits="PokedexWeb.EnvioEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header bg-primary text-white text-center">
                        <h4>✉️ Enviar Mensaje a Entrenadores</h4>
                    </div>
                    <div class="card-body">
                        
                        <div class="mb-3">
                            <label class="form-label">Email Destino:</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="ejemplo@pokemon.com" />
                        </div>
                        
                        <div class="mb-3">
                            <label class="form-label">Asunto:</label>
                            <asp:TextBox ID="txtAsunto" runat="server" CssClass="form-control" />
                        </div>
                        
                        <div class="mb-3">
                            <label class="form-label">Mensaje:</label>
                            <%-- TextMode="MultiLine" convierte el TextBox en un Textarea (caja grande) --%>
                            <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
                        </div>
                        
                        <div class="d-grid">
                            <asp:Button ID="btnEnviar" runat="server" Text="Enviar Correo" CssClass="btn btn-success" OnClick="btnEnviar_Click" />
                        </div>
                        <div class="text-center mt-3">
                            <asp:Label ID="lblMensaje" runat="server" CssClass="text-success fw-bold"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>