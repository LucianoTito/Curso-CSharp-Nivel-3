<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="PokedexWeb.PokemonLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h1>Lista de Pokémon</h1>
        <hr />
        
        <asp:GridView ID="dgvPokemons" runat="server" DataKeyNames="Id" 
            AutoGenerateColumns="false" CssClass="table table-dark table-hover"
            AllowPaging="true" PageSize="5" 
            OnPageIndexChanging="dgvPokemons_PageIndexChanging"
            OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged">
            
            <Columns>
                <asp:BoundField HeaderText="Número" DataField="Numero" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                <asp:CommandField ShowSelectButton="true" SelectText="✍️" HeaderText="Acción" />
            </Columns>
        </asp:GridView>
        
        <a href="PokemonForm.aspx" class="btn btn-primary mt-3">Agregar Pokémon</a>
    </div>
</asp:Content>
