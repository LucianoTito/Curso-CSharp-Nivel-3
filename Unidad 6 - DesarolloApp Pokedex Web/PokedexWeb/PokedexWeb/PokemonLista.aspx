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
                
                <%-- Fila del Filtro Rápido y el CheckBox --%>
<div class="row mb-3">
    <div class="col-6">
        <div class="mb-3">
            <asp:Label Text="Filtrar Rápido:" runat="server" CssClass="form-label" />
            <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" placeholder="Ej: Pikachu..." />
        </div>
    </div>
    
    <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
        <div class="mb-3">
            <%-- El checkbox mágico con AutoPostBack --%>
            <asp:CheckBox Text="Filtro Avanzado" runat="server" ID="chkAvanzado" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" CssClass="form-check-input ms-2" />
        </div>
    </div>
</div>

<%-- 
    Bloque del Filtro Avanzado:
    Solo se renderiza si la variable booleana 'FiltroAvanzado' es verdadera
--%>
<% if (FiltroAvanzado) { %>
    <div class="row mb-3">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" runat="server" CssClass="form-label" />
                <%-- Desplegable principal con AutoPostBack para hacer el efecto cascada --%>
                <asp:DropDownList runat="server" ID="ddlCampo" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="Número" />
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Tipo" />
                </asp:DropDownList>
            </div>
        </div>
        
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" CssClass="form-label" />
                <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-select"></asp:DropDownList>
            </div>
        </div>
        
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" runat="server" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
            </div>
        </div>
        
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Estado" runat="server" CssClass="form-label" />
                <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-select">
                    <asp:ListItem Text="Todos" />
                    <asp:ListItem Text="Activo" />
                    <asp:ListItem Text="Inactivo" />
                </asp:DropDownList>
            </div>
        </div>
    </div>
    
    <div class="row mb-3">
    <div class="col-6">
        <div class="mb-3">
            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
            
            <%--Botón para limpiar los filtros con estilo secundario --%>
            <asp:Button Text="Limpiar Filtro" runat="server" CssClass="btn btn-outline-secondary ms-2" ID="btnLimpiar" OnClick="btnLimpiar_Click" />
        </div>
    </div>
</div>
<% } %>

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
