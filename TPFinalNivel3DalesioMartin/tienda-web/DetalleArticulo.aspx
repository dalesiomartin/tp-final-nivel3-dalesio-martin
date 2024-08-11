<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="tienda_web.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img-thumbnail {
            width: 250px;
            height: 250px;
            object-fit: contain;
            transition: width 0.5s ease, height 0.5s ease;
        }

            .img-thumbnail:hover {
                width: 500px;
                height: 500px;
                object-fit: contain;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

     <h1 class="mb-3" style=" background-image: url('./Imagenes/fondo0.jpg');  background-size: cover;  background-position: center; 
color: white;  padding: 12px 20px;  border-radius: 8px;  box-shadow: 0 4px 15px rgba(0, 0, 0, 0.4);  font-family: 'Roboto', sans-serif; 
letter-spacing: 1px;  text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.7);"> Detalle del Artículo </h1>

    <div class="row">
        <%-- --columna izq----%>
        <div class="col-6">

            <div class="mb-3">
                <label for="lbCodigo" class="col-sm-2 col-form-label fw-bold">Código:</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="lbNombre" class="col-sm-2 col-form-label fw-bold">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="lbDescripcion" class="col-sm-2 col-form-label fw-bold">Descripción:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="lbMarca" class="col-sm-2 col-form-label fw-bold">Marca:</label>
                <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <asp:Button ID="btnAtras" runat="server" Text="Volver" CssClass="btn btn-dark" OnClick="btnAtras_Click" />

        </div>

        <%-- --columna der----%>
        <div class="col-6">

            <div class="mb-3">
                <label for="lbCategoria" class="col-sm-2 col-form-label fw-bold">Categoría:</label>
                <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="lbPrecio" class="col-sm-2 col-form-label fw-bold">Precio:</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="rmb-5">
                <asp:Image ID="txtImagen" runat="server" CssClass="img-thumbnail" />
            </div>

        </div>


    </div>


</asp:Content>
