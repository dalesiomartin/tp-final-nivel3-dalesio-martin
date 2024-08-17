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
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.SesionActiva(Session["trainee"]))
                {

                    FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                    Trainee user = new Trainee();
                    user = (Trainee)Session["trainee"];

                    var favoritos = favoritoNegocio.Listar(user.Id);
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    ListaFavoritos = new List<Articulo>();

                    foreach (var fav in favoritos)
                    {
                        Articulo art = articuloNegocio.listarConId(fav.IdArticulo);
                        if (art != null)
                        {
                            ListaFavoritos.Add(art);
                        }
                    }

                    repFavoritos.DataSource = ListaFavoritos;
                    repFavoritos.DataBind();
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Trainee user = (Trainee)Session["trainee"];
                FavoritoNegocio favoritoNegocio = new FavoritoNegocio();

                Button btn = (Button)sender; // Obtener el botón que fue clickeado

                string artIdStr = btn.CommandArgument;// Obtener el ID del artículo desde el CommandArgument del botón

                if (int.TryParse(artIdStr, out int idArticulo))
                {
                    Favorito fav = new Favorito
                    {
                        IdUser = user.Id,
                        IdArticulo = idArticulo
                    };

                    favoritoNegocio.EliminarFav(fav);

                    Response.Redirect("Favoritos.aspx", false);
                }
                else
                {
                    throw new ApplicationException("ID del artículo no válido.");
                }
            }
            catch (Exception ex)
            {
                // Manejar errores y redirigir a la página de error
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }



        }




    }
}
