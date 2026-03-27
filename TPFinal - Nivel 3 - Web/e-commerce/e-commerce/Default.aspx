<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="e_commerce.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="mb-4">¡Bienvenido a mi Tienda Virtual!</h1>

    <%--  BARRA DE BÚSQUEDA --%>
    <div class="row mb-4">
        <div class="col-md-6">
            <div class="input-group shadow-sm">
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" placeholder="Buscar producto..." />
                <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-success" OnClick="btnBuscar_Click" />
                <asp:Button Text="Limpiar" runat="server" ID="btnLimpiar" CssClass="btn btn-outline-secondary" OnClick="btnLimpiar_Click" />
            </div>
        </div>
    </div>

    <%--  GRILLA DE TARJETAS --%>
    <div class="row row-cols-1 row-cols-md-4 g-4 mb-5">
        
        <% foreach (Dominio.Articulo art in ListaArticulos)
           { %>
            
            <div class="col">
                <div class="card h-100 shadow-sm">
                    <img src="<%: art.ImagenUrl %>" class="card-img-top p-2" alt="<%: art.Nombre %>" 
                         onerror="this.src='https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png'"
                         style="max-height: 200px; object-fit: contain;">
                    
                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title"><%: art.Nombre %></h5>
                        <p class="card-text flex-grow-1 text-muted"><%: art.Descripcion %></p>
                        <p class="card-text fs-5 text-success fw-bold">$ <%: art.Precio.ToString("N2") %></p>
                        
                        <a href="Detalle.aspx?id=<%: art.Id %>" class="btn btn-primary mt-auto">Ver Detalles</a>
                    </div>
                </div>
            </div>

        <% } %>

    </div>

</asp:Content>