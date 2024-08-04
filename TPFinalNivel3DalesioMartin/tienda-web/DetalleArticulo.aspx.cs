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
    public partial class DetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);

                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo aux = negocio.listarConId(id);

                
                if (aux != null)
                {
                    txtCodigo.Text = aux.Codigo;
                    txtNombre.Text = aux.Nombre;
                    txtDescripcion.Text = aux.Descripcion;
                    txtMarca.Text = aux.Marca != null ? aux.Marca.ToString() : string.Empty;
                    txtCategoria.Text = aux.Categoria != null ? aux.Categoria.ToString() : string.Empty;
                    txtPrecio.Text = aux.Precio.ToString();
                    txtImagen.ImageUrl = aux.ImagenUrl;
                }
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}