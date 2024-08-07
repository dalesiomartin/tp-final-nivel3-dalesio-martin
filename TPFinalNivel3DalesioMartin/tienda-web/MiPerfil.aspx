﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="tienda_web.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h1>Mi perfil</h1>
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="Email" class="col-sm-2 col-form-label fw-bold" runat="server" />
                <asp:TextBox CssClass="form-control-plaintext" runat="server" ID="txtEmail"  ReadOnly="true"></asp:TextBox>
    
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre" class="col-sm-2 col-form-label fw-bold" runat="server" />
                <asp:TextBox CssClass="form-control" REQUIRED ClientIDMode="Static" runat="server" ID="txtNombre"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label Text="Apellido" class="col-sm-2 col-form-label fw-bold" runat="server" />
                <asp:TextBox CssClass="form-control" REQUIRED ClientIDMode="Static" runat="server" ID="txtApellido"></asp:TextBox>
            </div>
        </div>
        <div class="col-4">
            <div class="mb-3">
                <label class="form-label  fw-bold"">Imagen Perfil</label>
                <input type="file" ID="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imgAvatar" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                runat="server" CssClass="img-fluid mb-3" />
        </div>
    </div>
    <div class="row">
         <div class="col-4">
             <asp:Button Text="Guardar" CssClass="btn btn-outline-secondary" ID="btnGuardar" runat="server" OnClientClick="return validar()" OnClick="btnGuardar_Click"/>
             <a href="Default.aspx" Class=" btn btn-dark">Regresar</a>
         </div>
    </div>

</asp:Content>
