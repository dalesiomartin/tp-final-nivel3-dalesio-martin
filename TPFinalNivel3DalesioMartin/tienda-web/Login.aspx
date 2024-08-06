<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="tienda_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hoja Login</h1>
    
    <asp:Label Text="User" runat="server" Font-Size="Larger" Font-Bold="true" />
    <asp:TextBox runat="server" ID="txtUser" CssClass="form-control" />
    <br />
   
    <asp:Label Text="Password" runat="server" Font-Size="Larger" Font-Bold="true" />
    <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" TextMode="Password" />
    <br />
    
    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-dark" OnClick="btnIngresar_Click" />

</asp:Content>
