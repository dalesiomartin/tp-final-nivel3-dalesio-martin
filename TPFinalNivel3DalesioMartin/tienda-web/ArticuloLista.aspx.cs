using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace tienda_web
{
    public partial class ProductoLista : System.Web.UI.Page
    {
        public bool FiltroAvanzado
        {
            get { return chkAvanzado.Checked; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.EsAdmin(Session["trainee"]))
            {
                Session.Add("error", "Se requiere permisos de admin para acceder a esta pantalla");
                Response.Redirect("Error.aspx");
            }

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulo", negocio.listar());
                dgvArticulos.DataSource = Session["listaArticulo"];
                dgvArticulos.DataBind();

            }

            pnlFiltroAvanzado.Visible = FiltroAvanzado;


        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataSource = Session["listaArticulo"];
            dgvArticulos.DataBind();

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }



        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //SEGUIR TRABAJANDOLO
            //if ((string.IsNullOrEmpty(ddlCampo.SelectedItem.ToString()) || string.IsNullOrEmpty(ddlCriterio.SelectedItem.ToString())
            //    || string.IsNullOrEmpty(txtFiltroAvanzado.Text)))
            //{
            //    Session.Add("Error", "Faltan campos por completar");
            //}
            

            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = negocio.filtrar(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }


        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            pnlFiltroAvanzado.Visible = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;

        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulo"];
            List<Articulo> listaFiltada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltada;
            dgvArticulos.DataBind();
        }



        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                txtFiltro.Text = string.Empty;

                ddlCampo.ClearSelection();

                // Limpiar los criterios del DropDownList
                ddlCriterio.Items.Clear();

                // Limpiar el texto del filtro avanzado
                txtFiltroAvanzado.Text = string.Empty;
                // Opcional: Deshabilitar el campo de texto del filtro avanzado
                //txtFiltroAvanzado.Enabled = false;

                dgvArticulos.DataSource = negocio.listar();

                dgvArticulos.DataBind();


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlCampo_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CategoriaNegocio cateNeg = new CategoriaNegocio();
            MarcaNegocio marcaNeg = new MarcaNegocio();


            //Session["listaMarca"] = marcaNeg.listar();

            List<Marca> listaMarcas = marcaNeg.listar();
            List<Categoria> listaCategorias = cateNeg.listar();
            

            ddlCriterio.Items.Clear();

            txtFiltroAvanzado.Text = string.Empty;


            if (ddlCampo.SelectedItem.ToString() == "Nombre")
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Termina con");
              //  txtFiltroAvanzado.Text = string.Empty;
                txtFiltroAvanzado.Enabled = true;
            }
            else if (ddlCampo.SelectedItem.ToString() == "Marca")
            {

                ddlCriterio.DataSource = listaMarcas;

                ddlCriterio.DataTextField = "Descripcion"; // Mostrar la propiedad "Descripcion". Es el campo del DropDownList
                ddlCriterio.DataValueField = "Id"; // Usar la propiedad "Id" como valor
                ddlCriterio.DataBind(); // Enlazar los datos al control para que se reflejen en la interfaz de usuario
                txtFiltroAvanzado.Enabled = false;


            }
            else if (ddlCampo.SelectedItem.ToString() == "Categoria")
            {
                ddlCriterio.DataSource = listaCategorias;
                ddlCriterio.DataTextField = "Descripcion";
                ddlCriterio.DataValueField = "Id";
                ddlCriterio.DataBind();

                txtFiltroAvanzado.DataBind();
                txtFiltroAvanzado.Enabled = false;

            }
            else if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
               // txtFiltroAvanzado.Text = string.Empty;
                txtFiltroAvanzado.Enabled = true;
            }
        }

        protected void ddlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {

            //controlo el AutoPostBack para que me traiga solo el id en Marca y Categoria
            string selectedValue = ddlCampo.SelectedItem.ToString();
            //txtFiltroAvanzado.Text = string.Empty;

            if (selectedValue == "Marca" || selectedValue == "Categoria")
            {
                ddlCriterio.AutoPostBack = true;
                if (ddlCriterio.SelectedValue != null)
                {
                    txtFiltroAvanzado.Text = ddlCriterio.SelectedValue;
                }

            }
            else
            {
                ddlCriterio.AutoPostBack = false;
               
            }
            

        }
    }
}







