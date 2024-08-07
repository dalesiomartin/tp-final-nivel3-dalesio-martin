<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="tienda_web.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <h1>Creá tu perfil Trainee</h1>
    
    <asp:Label Text="Email" runat="server" Font-Size="Larger" Font-Bold="true" />
    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
    <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El email es requerido" ControlToValidate="txtEmail" runat="server" />
    <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Formato de email incorrecto" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="txtEmail" runat="server" />
    <asp:Label ID="lbError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
   
    <br />
   
    <asp:Label Text="Password" runat="server" Font-Size="Larger" Font-Bold="true" />
    <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" />
    
    <br />
   
    <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" />
    <a href="Default.aspx">Cancelar</a>

</asp:Content>
