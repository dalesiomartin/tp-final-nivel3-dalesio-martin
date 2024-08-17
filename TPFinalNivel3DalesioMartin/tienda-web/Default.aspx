<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tienda_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-img-top {
            width: 300px;
            height: 300px;
            object-fit: contain;
        }

        .alerta {
            padding: 10px;
            background-color: #f44336;
            color: white;
            opacity: 0;
            transition: opacity 0.6s;
            position: fixed;
            bottom: 10px;
            right: 10px;
            z-index: 1000;
            border-radius: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <h1 class="mb-3" style="background-image: url('./Imagenes/fondo/fondo4.jpg'); background-size: cover; background-position: center; color: white; padding: 12px 20px; border-radius: 8px; box-shadow: 0 4px 15px rgba(0, 0, 0, 0.4); font-family: 'Roboto', sans-serif; letter-spacing: 1px; text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.7);">Tienda Web </h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body">

                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <h5 class="card-title"><%# Eval("Precio", "{0:C}") %></h5>
                            <%--  <p class="card-text"><%#Eval("Descripcion") %></p>--%>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>" class="btn btn-outline-secondary">Ver Detalle </a>

                            <%if (negocio.Seguridad.SesionActiva(Session["trainee"]))
                                { %>
                            <asp:Button Text="Agregar a favoritos ❤️" CssClass="btn btn-primary" runat="server" ID="btnFavoritos" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnFavoritos_Click" />
                            <div id="alerta" class="alerta" style="display: none;">Este producto ya está en tu lista de favoritos.</div>
                            <%} %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
