<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="tienda_web.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-img-top {
            width: 300px;
            height: 300px;
            object-fit: contain;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="mb-3" style="background-image: url('./Imagenes/fondo/fondo4.jpg'); background-size: cover; background-position: center; color: white; padding: 12px 20px; border-radius: 8px; box-shadow: 0 4px 15px rgba(0, 0, 0, 0.4); font-family: 'Roboto', sans-serif; letter-spacing: 1px; text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.7);">Mis Favoritos </h1>



    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repFavoritos" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <h5 class="card-title"><%# Eval("Precio", "{0:C}") %></h5>
                            <a href="DetalleArticulo.aspx?id=<%# Eval("Id") %>" class="btn btn-outline-secondary">Ver detalles</a>
                            <asp:Button Text="Eliminar Favorito" CommandArgument='<%# Eval("Id") %>' ID="btnEliminar" runat="server" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                        </div>

                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
