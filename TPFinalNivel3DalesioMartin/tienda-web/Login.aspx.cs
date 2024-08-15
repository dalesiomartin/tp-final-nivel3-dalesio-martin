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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["email"] != null)
                {
                    txtEmail.Text = Session["email"].ToString();

                }
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeNegocio negocio = new TraineeNegocio();

            try
            {
                if (Validacion.validaTextoVacio(txtEmail) || Validacion.validaTextoVacio(txtPass))
                {
                    Session.Add("error", "Debes completar ambos campos...");
                    Response.Redirect("Error.aspx");
                }

                trainee.Email = txtEmail.Text;
                trainee.Pass = txtPass.Text;

                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPass.Text))
                {

                    if (!string.IsNullOrEmpty(txtEmail.Text))
                    {
                        Session["email"] = txtEmail.Text;
                    }
                    Session.Add("error", "Debes completar ambos campos");
                    Response.Redirect("Error.aspx");
                }

                if (negocio.Login(trainee))
                {
                    Session.Add("trainee", trainee);
                    Response.Redirect("MiPerfil.aspx");
                }

                else
                {
                    Session["email"] = txtEmail.Text; // Guardar el email si hay un error de login
                    Session.Add("error", "User o pass incorrectos");
                    Response.Redirect("Error.aspx");
                }

            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }


        }
    }
}