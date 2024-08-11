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

       <h1 class="mb-3" style=" background-image: url('./Imagenes/fondo/fondo4.jpg');  background-size: cover;  background-position: center; 
   color: white;  padding: 12px 20px;  border-radius: 8px;  box-shadow: 0 4px 15px rgba(0, 0, 0, 0.4);  font-family: 'Roboto', sans-serif; 
   letter-spacing: 1px;  text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.7);"> Tienda Tech Web </h1>

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
                            <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>">Ver Detalle</a>
                          
                            <%if (negocio.Seguridad.SesionActiva(Session["trainee"]))
                                { %>
                            <asp:Button Text="Agregar a favoritos 🤍❤️" CssClass="btn btn-primary" runat="server" ID="btnFavoritos" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnFavoritos_Click" />
                              <%} %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
