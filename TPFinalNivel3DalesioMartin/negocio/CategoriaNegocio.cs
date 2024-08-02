using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesoDatos;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar() 
        {
            List<Categoria> lista = new List<Categoria>();
            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.setearConsulta("select Id,Descripcion from CATEGORIAS");

                datos.ejecutarLectura();

                while (datos.lectorData.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)datos.lectorData["Id"];
                    aux.Descripcion = (string)datos.lectorData["Descripcion"];

                    lista.Add(aux);

                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            
            
        
        }
        

    }
}
