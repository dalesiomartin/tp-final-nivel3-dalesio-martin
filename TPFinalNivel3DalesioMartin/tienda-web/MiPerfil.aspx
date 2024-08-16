<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="tienda_web.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion{
            color: red;
            font-size: 15px;
        }
    </style>
    <script>
        function validar() {

            //capturar el control. 
            const txtApellido = document.getElementById("txtApellido");
            const txtNombre = document.getElementById("txtNombre");
            if (txtApellido.value == "") {
                txtApellido.classList.add("is-invalid");
                txtApellido.classList.remove("is-valid");
                txtNombre.classList.add("is-valid");
                return false;
            }
            txtApellido.classList.remove("is-invalid");
            txtApellido.classList.add("is-valid");
            return true;
        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 
    <h1 class="mb-3" style=" background-image: url('./Imagenes/fondo/fondo4.jpg');  background-size: cover;  background-position: center; 
    color: white;  padding: 12px 20px;  border-radius: 8px;  box-shadow: 0 4px 15px rgba(0, 0, 0, 0.4);  font-family: 'Roboto', sans-serif; 
    letter-spacing: 1px;  text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.7);"> Mi Perfil </h1>



    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <asp:Label Text="Email" class="col-sm-2 col-form-label fw-bold" runat="server" />
                <asp:TextBox CssClass="form-control" runat="server" ID="txtEmail"  ReadOnly="true"></asp:TextBox>
                
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre" class="col-sm-2 col-form-label fw-bold" runat="server" />
                <asp:TextBox CssClass="form-control" ClientIDMode="Static" runat="server" ID="txtNombre"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El nombre es requerido" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Apellido" class="col-sm-2 col-form-label fw-bold" runat="server" />
                <asp:TextBox CssClass="form-control" ClientIDMode="Static" runat="server" ID="txtApellido"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El apellido es requerido" ControlToValidate="txtApellido" runat="server" />
            </div>
        </div>
       
        <div class="col-md-4">
             <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imgAvatar" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                runat="server" CssClass="img-fluid mb-3"  />


        </div>

    </div>

    <div class="row">
         <div class="col-md-4">
             <asp:Button Text="Guardar" CssClass="btn btn-outline-secondary" ID="btnGuardar" runat="server" OnClientClick="return validar()" OnClick="btnGuardar_Click"/>
             <a href="Default.aspx" Class=" btn btn-dark">Regresar</a>
         </div>
    </div>

</asp:Content>
