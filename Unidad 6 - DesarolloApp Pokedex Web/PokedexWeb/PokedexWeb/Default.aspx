<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PokedexWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row row-cols-1 row-cols-md-3 g-4">
        
        <%-- Nuestro nuevo control Repeater --%>
        <asp:Repeater ID="repPokemons" runat="server">
            
            <%-- La plantilla que se va a repetir --%>
            <ItemTemplate>
                
                <div class="col">
                    <div class="card h-100 text-bg-dark border-secondary">
                        
                        <%-- La sintaxis cambia a Eval("")  --%>
                        <img src="<%# Eval("UrlImagen") %>" class="card-img-top" alt="Imagen de <%# Eval("Nombre") %>" 
                             onerror="this.src='https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/1024px-No_image_available.svg.png'">
                        
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %> </p>
                        </div>
                        
                        <div class="card-footer text-center">
                            <%-- Botón viejo del foreach (navega a otra página) --%>
                            <asp:Button ID="btnEjemplo" runat="server" Text="Ver Detalle" CssClass="btn btn-warning" CommandArgument='<%# Eval("Id") %>' OnClick="btnEjemplo_Click" />
                            
                        </div>
                    </div>
                </div>

            </ItemTemplate>

        </asp:Repeater>

    </div>

</asp:Content>
