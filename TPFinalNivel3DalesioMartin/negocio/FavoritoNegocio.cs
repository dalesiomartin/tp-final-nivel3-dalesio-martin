using accesoDatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class FavoritoNegocio
    {

        public int InsertarNuevo(Favorito fav)
        {
            ConexionDatos datos = new ConexionDatos();
            try
            {
                datos.setearConsulta("INSERT INTO FAVORITOS (IdUser, IdArticulo) OUTPUT INSERTED.Id VALUES (@IdUser, @IdArticulo)");
                datos.setearParametros("@IdUser", fav.IdUser);
                datos.setearParametros("@IdArticulo", fav.IdArticulo);

                return datos.ejecutarAccionScalar();
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

        public List<Favorito> Listar(int idUser)
        {
            List<Favorito> lista = new List<Favorito>();
            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.setearConsulta("SELECT Id, IdUser, IdArticulo FROM FAVORITOS WHERE IdUser = @IdUser");
                datos.setearParametros("@IdUser", idUser);
                datos.ejecutarLectura();

                while (datos.lectorData.Read())
                {
                    Favorito fav = new Favorito
                    {
                        Id = (int)datos.lectorData["Id"],
                        IdUser = (int)datos.lectorData["IdUser"],
                        IdArticulo = (int)datos.lectorData["IdArticulo"]
                    };
                    lista.Add(fav);
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

        public void EliminarFav(Favorito fav)
        {
            ConexionDatos datos = new ConexionDatos();
            try
            {
                datos.setearConsulta("DELETE FROM FAVORITOS WHERE IdUser = @IdUser AND IdArticulo = @IdArticulo");
                datos.setearParametros("@IdUser", fav.IdUser);
                datos.setearParametros("@IdArticulo", fav.IdArticulo);

                datos.ejecutarAccion(); // No se espera un valor de retorno para un DELETE
            }
            catch (Exception ex)
            {
                // Manejo de errores detallado
                throw new ApplicationException("Error al eliminar favorito.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }




        public bool ExisteFavorito(int idUser, int idArticulo)
        {
            ConexionDatos datos = new ConexionDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM FAVORITOS WHERE IdUser = @IdUser AND IdArticulo = @IdArticulo");
                datos.setearParametros("@IdUser", idUser);
                datos.setearParametros("@IdArticulo", idArticulo);

                datos.ejecutarLectura();

                if (datos.lectorData.Read())
                {
                    int count = (int)datos.lectorData[0];
                    return count > 0;
                }
                return false;
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
