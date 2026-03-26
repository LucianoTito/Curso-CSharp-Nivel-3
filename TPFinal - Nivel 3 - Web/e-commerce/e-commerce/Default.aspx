<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="e_commerce.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="mb-4">¡Bienvenido a mi Tienda Virtual!</h1>

    <%-- Grilla de Bootstrap: 1 columna en celulares, 3 columnas en pantallas medianas --%>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        
        <%-- Bucle foreach nativo de C# incrustado en HTML --%>
        <% foreach (Dominio.Articulo art in ListaArticulos)
           { %>
            
            <div class="col">
                <div class="card h-100">
                    <%-- Imagen del artículo. Si la URL está rota, el 'onerror' carga una imagen por defecto --%>
                    <img src="<%: art.ImagenUrl %>" class="card-img-top" alt="<%: art.Nombre %>" 
                         onerror="this.src='https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png'">
                    
                    <div class="card-body">
                        <h5 class="card-title"><%: art.Nombre %></h5>
                        <p class="card-text"><%: art.Descripcion %></p>
                        <p class="card-text fs-5 text-success fw-bold">$ <%: art.Precio %></p>
                        
                        <%-- Botón que nos llevará a la futura pantalla de detalle --%>
                        <a href="Detalle.aspx?id=<%: art.Id %>" class="btn btn-primary">Ver Detalles</a>
                    </div>
                </div>
            </div>

        <% } %>

    </div>

</asp:Content>
