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
        // 1. Declaramos la función que recibe como parámetro el propio 'input' de HTML
        function previsualizar(input) {

            // 2. Verificamos que el input tenga archivos ('files') y que al menos haya seleccionado uno ('files[0]')
            if (input.files && input.files[0]) {

                // 3. Instanciamos FileReader. Es una API nativa de HTML5 diseñada 
                // exclusivamente para leer el contenido de archivos guardados en la compu del usuario SIN subirlos al servidor.
                var reader = new FileReader();

                // 4. Definimos un "evento": ¿Qué va a pasar cuando el reader TERMINE de leer el archivo?
                reader.onload = function (e) {

        // a) document.getElementById busca la etiqueta <img> en la pantalla.
            // b) <%= imgNuevoPerfil.ClientID %> es C# inyectando el ID real que ASP.NET le puso a la imagen.
            // c) .src = e.target.result; cambia la ruta de la imagen por el resultado de la lectura (un código larguísimo en base64 que representa la foto).
            document.getElementById('<%= imgNuevoPerfil.ClientID %>').src = e.target.result;
        };

        // 5.Le damos la orden al reader para que empiece a leer el archivo físico.
        // Lo lee como "DataURL", que es básicamente transformar los píxeles de la foto en texto puro para que el navegador lo entienda.
        reader.readAsDataURL(input.files[0]);
    }
}
    </script>
</asp:Content>
