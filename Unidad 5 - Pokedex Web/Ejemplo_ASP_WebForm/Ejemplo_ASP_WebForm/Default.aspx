<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ejemplo_ASP_WebForm.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row row-cols-1 row-cols-md-3 g-4">
        
        <%-- 1. Abrimos el bucle C# --%>
        <% foreach (Dominio.Pokemon poke in ListaPokemon) { %>
            
            <%-- 2. Todo este HTML se va a repetir por cada Pokémon --%>
            <div class="col">
                <div class="card h-100 text-bg-dark border-secondary">
                    
                    <%-- 3. Inyectamos la URL de la imagen --%>
                    <img src="<%: poke.UrlImagen %>" class="card-img-top" alt="Imagen de <%: poke.Nombre %>" 
                         onerror="this.src='https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/1024px-No_image_available.svg.png'">
                    
                    <div class="card-body">
                        <%-- 4. Inyectamos el Nombre y la Descripción --%>
                        <h5 class="card-title"><%: poke.Nombre %></h5>
                        <p class="card-text"><%: poke.Descripcion %></p>
                    </div>
                    
                    <div class="card-footer text-center">
                        <%-- 5. Armamos el link dinámico para la pantalla de detalle --%>
                        <a href="DetallePokemon.aspx?id=<%: poke.Id %>" class="btn btn-warning">Ver Detalle</a>
                    </div>
                </div>
            </div>
            
        <%-- 6. Cerramos la llave del bucle C# --%>
        <% } %>

    </div>



</asp:Content>
