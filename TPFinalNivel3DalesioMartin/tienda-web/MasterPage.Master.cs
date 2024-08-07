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
                if (!Seguridad.SesionActiva(Session["trainee"]))
                    Response.Redirect("Login.aspx", false);
                    
                if (Seguridad.SesionActiva(Session["trainee"]))
                {
                    Trainee user = new Trainee();
                    user = (Trainee)Session["trainee"];
                    imgAvatar.ImageUrl = "~/Imagenes/" + user.ImagenPerfil;
                    lbUser.Text = user.Email;
                }
                else
                {
                    imgAvatar.ImageUrl = "https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg";
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