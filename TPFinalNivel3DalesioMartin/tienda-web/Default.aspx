<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tienda_web.Default" %>

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

    <h1>Pagina HOME</h1>

    <h1>Bienvenido a tu catalogo de tecnologia</h1>
    <p>Estos son todos nuestros productos en stock</p>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body">
          
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>">Ver Detalle</a>
                          <%-- ---FALTA Negocio.Seguridad.SesionActiva(Session["trainee"]------%>
                            <asp:Button Text="Agregar a favoritos 🤍❤️" CssClass="btn btn-primary" runat="server" ID="btnFavoritos" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId"  OnClick="btnFavoritos_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
