<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="tienda_web.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-img-top {
           width: 400px;
           height: 400px;
           object-fit: contain;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Mis Favoritos</h1>
    
    <div class="row row-cols-1 row-cols-md-3 g-4">
    <asp:Repeater ID="repFavoritos" runat="server">
        <ItemTemplate>
            <div class="col">
                <div class="card">
                    <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                        <p class="card-text"><%# Eval("Descripcion") %></p>
                        <a href="DetalleArticulo.aspx?id=<%# Eval("Id") %>" class="btn btn-outline-secondary">Ver detalles</a>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    </div>

</asp:Content>
