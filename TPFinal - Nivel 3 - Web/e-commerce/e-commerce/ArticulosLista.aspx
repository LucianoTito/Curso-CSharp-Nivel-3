<%@ Page Title="Administración de Artículos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticulosLista.aspx.cs" Inherits="e_commerce.ArticulosLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row mb-4">
        <div class="col">
            <h2 class="fw-bold">Gestión de Artículos</h2>
            <hr />
        </div>
    </div>

    <div class="row mb-4">
        <div class="col">
           
            <%-- LA GRILLA DE DATOS --%>
            <div class="table-responsive shadow-sm rounded">
                <asp:GridView ID="dgvArticulos" runat="server" CssClass="table table-striped table-hover table-bordered mb-0 align-middle" 
                    AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
                    
           
                    <HeaderStyle CssClass="table-dark" />
                    
                    <Columns>
                        <asp:BoundField HeaderText="Código" DataField="Codigo" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                        <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                        
                        <%-- uso DataFormatString para que formatee como moneda con 2 decimales --%>
                        <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C2}" />
                        
                        <%-- columna de acción para seleccionar y editar --%>
                        <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍️ Editar" ControlStyle-CssClass="btn btn-sm btn-outline-primary" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col">
            <%-- Btn para ir al formulario de alta --%>
            <a href="ArticuloForm.aspx" class="btn btn-success fw-bold">➕ Agregar Nuevo Artículo</a>
        </div>
    </div>
</asp:Content>