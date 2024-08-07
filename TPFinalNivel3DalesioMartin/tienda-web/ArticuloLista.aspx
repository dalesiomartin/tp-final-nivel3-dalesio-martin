<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticuloLista.aspx.cs" Inherits="tienda_web.ProductoLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <div class="container">

        <h1>Lista de Articulos</h1>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>

                <div class="row">
                    <div class="col-6">
                        <div class="mb-3">
                            <asp:Label Text="Filtrar" runat="server" />
                            <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtFiltro_TextChanged" />
                        </div>
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
                <br />

                <asp:Panel runat="server" ID="pnlFiltroAvanzado" Visible="false">

                    <div class="row">
                        
                        <div class="col-3">
                            <div class="mb-3">
                                <asp:Label Text="Campo" ID="lbCampo" runat="server" />
                                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged1">
                                    <asp:ListItem Text="Precio" />
                                    <asp:ListItem Text="Nombre" />
                                    <asp:ListItem Text="Marca" />
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

                    <%----Otra Fila----%>

                    <div class="row">
                        <div class="col-3">
                            <div class="mb-3">
                                <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                            </div>
                        </div>
                    </div>
                 
                    <br />

                </asp:Panel>


                <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                    OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                    AllowPaging="true" PageSize="5" PageIndex="0">
                    <Columns>
                        <asp:BoundField HeaderText="Codigo de Articulo" DataField="Codigo" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C}" HtmlEncode="False" />
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" SelectText="✍️ Modificar" />

                    </Columns>

                </asp:GridView>
                <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>

            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
