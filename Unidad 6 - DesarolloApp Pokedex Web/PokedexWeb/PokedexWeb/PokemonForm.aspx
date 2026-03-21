<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PokemonForm.aspx.cs" Inherits="PokedexWeb.PokemonForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

    <div class="container mt-4">
        <h2>Formulario de Pokémon</h2>
        <hr />
        
        <div class="row">
            <%-- Columna Izquierda: Datos de texto y desplegables --%>
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtNumero" class="form-label">Número</label>
                    <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="ddlTipo" class="form-label">Tipo</label>
                    <%-- Desplegable que cargaremos desde la BD --%>
                    <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlDebilidad" class="form-label">Debilidad</label>
                    <asp:DropDownList ID="ddlDebilidad" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripción</label>
                    <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                
                <div class="mt-4">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                    <a href="PokemonLista.aspx" class="btn btn-secondary">Cancelar</a>
                </div>
            </div>

            <%-- Columna Derecha: Imagen dinámica con UpdatePanel --%>
            <div class="col-md-6">
                <asp:UpdatePanel ID="UpdatePanelImagen" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="txtUrlImagen" class="form-label">URL Imagen</label>
                            <%-- AutoPostBack="true" para que dispare el evento al salir de la caja de texto --%>
                            <asp:TextBox ID="txtUrlImagen" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" runat="server"></asp:TextBox>
                        </div>
                        <asp:Image ID="imgPokemon" ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/1024px-No_image_available.svg.png" Width="60%" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            

<%--Panel de Eliminación Segura  --%>
<div class="row mt-3">
    <div class="col-md-6">
        <asp:UpdatePanel ID="UpdatePanelEliminar" runat="server">
            <ContentTemplate>
                <div class="mb-3">
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                </div>

                <%-- Solo se dibuja si la propiedad ConfirmaEliminacion es TRUE  --%>
                <% if (ConfirmaEliminacion) { %>
                    <div class="mb-3">
                        <asp:CheckBox ID="chkConfirmaEliminacion" Text="Confirmar Eliminación" runat="server" CssClass="me-2" />
                        <asp:Button ID="btnConfirmaEliminar" runat="server" Text="Eliminar Definitivamente" CssClass="btn btn-outline-danger" OnClick="btnConfirmaEliminar_Click" />
                    </div>
                <% } %>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>

        </div>
    </div>

</asp:Content>
