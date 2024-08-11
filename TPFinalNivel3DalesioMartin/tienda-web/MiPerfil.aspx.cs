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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.SesionActiva(Session["trainee"]))
                    {
                        Trainee user = (Trainee)Session["trainee"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                            imgAvatar.ImageUrl = "~/Imagenes/perfil/" + user.UrlImagenPerfil;
                            

                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Trainee user = (Trainee)Session["trainee"];
                TraineeNegocio negocio = new TraineeNegocio();

                if (txtImagen.PostedFile.FileName != "") //escribir imagen solo si se cargo algo, sino sigue como estaba la db (con imagen o sin nada, si no hacia esta validacion me cargaba cualquier cosa, me cambiaba lo que ya tenia)
                {
                    string ruta = Server.MapPath("./Imagenes/perfil/"); //capturo la ruta donde guardare las imagenes
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg"); //en la ruta guardamos la imagen seleccionada con el id
                    user.UrlImagenPerfil = "perfil-" + user.Id + ".jpg";
                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Email = txtEmail.Text;



                negocio.Actualizar(user);
                // Verificar que la master page no sea nula
                if (Master != null)
                {
                    Image img = (Image)Master.FindControl("imgAvatar");
                    if (img != null)
                    {
                        // Añadir un parámetro aleatorio para evitar caché
                        img.ImageUrl = "~/Imagenes/perfil/" + user.UrlImagenPerfil;
                    }
                    else
                    {
                        throw new Exception("Control imgAvatar no encontrado en la Master Page.");
                    }
                }

               
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}