<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="PokedexWeb.PokemonLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Lista de Pokémon (Administración)</h2>
        <hr />

        <%-- Envolvemos todo en un UpdatePanel para que el filtro sea asíncrono y fluido  --%>
        <asp:UpdatePanel ID="UpdatePanelFiltro" runat="server">
            <ContentTemplate>
                
                <%-- Fila del Filtro Rápido  --%>
                <div class="row mb-3">
                    <div class="col-md-4">
                        <label for="txtFiltro" class="form-label">Filtrar por Nombre:</label>
                        <%-- AutoPostBack es clave para que reaccione al terminar de escribir  --%>
                        <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" placeholder="Ej: Pikachu..."></asp:TextBox>
                    </div>
                </div>

                <%-- La Grilla --%>
                <asp:GridView ID="dgvPokemons" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Número" DataField="Numero" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                        <asp:BoundField HeaderText="Debilidad" DataField="Debilidad.Descripcion" />
                        
                        <%-- La columna de estado --%>
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <%# Convert.ToBoolean(Eval("Activo")) ? "✅ Activo" : "❌ Inactivo" %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍️" />
                    </Columns>
                </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="mt-3">
            <a href="PokemonForm.aspx" class="btn btn-success">Agregar Pokémon</a>
        </div>
    </div>
</asp:Content>
