<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="PokedexWeb.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
    <h2>Mi Perfil</h2>
    <div class="row">
        <%-- Columna 1: Datos Personales --%>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" />
            </div>
        </div>

        <%-- Columna 2: Subida de Imagen --%>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                
               <input type="file" id="txtImagen" runat="server" class="form-control" accept="image/*" onchange="previsualizar(this);" />
            </div>
            
            <%-- Imagen de previsualización (Placeholder temporal) --%>
            <asp:Image ID="imgNuevoPerfil" ImageUrl="https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png"
                runat="server" CssClass="img-fluid mb-3" />
        </div>
    </div>
    
    <div class="row">
        <div class="col-md-8">
            <%-- Botón Guardar con su evento OnClick --%>
            <asp:Button Text="Guardar" CssClass="btn btn-primary" ID="btnGuardar" OnClick="btnGuardar_Click" runat="server" />
            <a href="Default.aspx" class="btn btn-link">Regresar</a>
        </div>
    </div>
</div>
    <script>
    function previsualizar(input) {
        if (input.files && input.files[0]) {
            // Usamos FileReader de HTML5 para leer el archivo localmente
            var reader = new FileReader();

            reader.onload = function (e) {
                // Buscamos nuestra imagen de ASP.NET usando su ID dinámico y le cambiamos la ruta (src)
                document.getElementById('<%= imgNuevoPerfil.ClientID %>').src = e.target.result;
            };

            // Ejecutamos la lectura de la foto elegida
            reader.readAsDataURL(input.files[0]);
        }
    }
    </script>
</asp:Content>
