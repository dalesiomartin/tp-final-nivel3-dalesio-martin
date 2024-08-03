<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticuloLista.aspx.cs" Inherits="tienda_web.ProductoLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista de Articulos</h1>
    <div class="row">
         <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
            </div>
        </div>
         <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" CssClass="" ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
            </div>
        </div>
        <div class="col-6">

            <asp:Button Text="Limpiar" ID="btnLimpiar" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" runat="server" />
        </div>

        <%if (chkAvanzado.Checked)
            { %>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:label text="Campo" id="lbCampo" runat="server"/>
                    <asp:DropDownList runat="server" autopostback="true" cssclass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged1">
                        <asp:ListItem Text="Precio" />
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Descripcion" />
                    </asp:DropDownList>
                    
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:label text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" cssclass="form-control"> </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:label text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" cssclass="form-control" />
                    
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:button text="Buscar" runat="server" cssclass="btn btn-primary" id="btnBuscar" OnClick="btnBuscar_Click" />
                </div>
            </div>
        </div>
        <%}%>
    </div>

    <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" 
        OnPageIndexChanging="dgvArticulos_PageIndexChanging"
        AllowPaging="true" PageSize="5" PageIndex="0">
        <Columns>
            <asp:BoundField HeaderText="Codigo de Articulo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" SelectText="✍️ Modificar" />

        </Columns>

    </asp:GridView>
    <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>

</asp:Content>
