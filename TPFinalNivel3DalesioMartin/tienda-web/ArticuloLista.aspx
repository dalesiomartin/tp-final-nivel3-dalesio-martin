<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticuloLista.aspx.cs" Inherits="tienda_web.ProductoLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista Articulo</h1>
    <div class="row">
       <%-- <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtfiltro" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
            </div>
        </div>--%>
       <%-- <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" CssClass="" ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
            </div>
        </div>--%>
        <%--<%if (chkAvanzado.Checked)
            { %>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="Precio" />
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Descripcion" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                </div>
            </div>
        </div>
        <%}%>--%>
    </div>

     <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnPageIndexChanging="dgvArticulos_PageIndexChanging"
         AllowPaging="true" PageSize="5" PageIndex="0">
        <Columns>
            <asp:BoundField HeaderText="Codigo de Articulo" DataField="codArticulo" />
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="precio" />
            <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />
            <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" SelectText="Modificar" />

        </Columns>

    </asp:GridView>
    <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>

</asp:Content>
