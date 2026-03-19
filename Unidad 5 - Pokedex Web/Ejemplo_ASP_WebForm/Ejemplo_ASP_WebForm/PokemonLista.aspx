<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="Ejemplo_ASP_WebForm.PokemonLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
    <h1>Lista de Pokémon</h1>
    <hr />
    <asp:GridView ID="dgvPokemons" runat="server" DataKeyNames="Id" 
        AutoGenerateColumns="false" CssClass="table table-dark table-hover">
        <Columns>
            <asp:BoundField HeaderText="Número" DataField="Numero" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <%-- Acceso a propiedades de objetos anidados  --%>
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:BoundField HeaderText="Debilidad" DataField="Debilidad.Descripcion" />
            
            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" />
        </Columns>
    </asp:GridView>
    <a href="PokemonForm.aspx" class="btn btn-primary">Agregar</a>
</div>


</asp:Content>
