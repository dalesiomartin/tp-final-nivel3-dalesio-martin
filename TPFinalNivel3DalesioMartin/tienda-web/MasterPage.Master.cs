using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tienda_web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login || Page is Default || Page is Registro || Page is Error))
            {
              
                imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
               
                if (!(Page is Login || Page is Registro || Page is Default || Page is Error))
                {
                    if (!Seguridad.SesionActiva(Session["trainee"]))
                        Response.Redirect("Login.aspx", false);
                    else
                    {
                        Trainee user = (Trainee)Session["trainee"];
                        lbUser.Text = user.Email;
                        if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                            imgAvatar.ImageUrl = "~/Imagenes/perfil/" + user.UrlImagenPerfil + "?t=" + DateTime.Now.Ticks; // Añadido parámetro de caché
                    }
                }



            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);

        }
    }
}