using accesoDatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class TraineeNegocio
    {

        public bool validarUser(string email)
        {
            ConexionDatos datos = new ConexionDatos();
            try
            {
                datos.setearConsulta("Select email, id from USERS where email = @email ");
                datos.setearParametros("@email", email);
                datos.ejecutarLectura();
                if (datos.lectorData.Read())
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

      

        public int InsertarNuevo(Trainee nuevo)
        {
            ConexionDatos datos = new ConexionDatos();
            try
            {
                datos.setearConsulta("INSERT into USERS (email, pass, admin) OUTPUT inserted.id VALUES (@email, @pass, 0)");
                datos.setearParametros("@email", nuevo.Email);
                datos.setearParametros("@pass", nuevo.Pass);

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

        public bool Login(Trainee trainee)
        {
            ConexionDatos datos = new ConexionDatos();
            try
            {
                datos.setearConsulta("select id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS where email = @email and pass = @pass");
                datos.setearParametros("@email", trainee.Email);
                datos.setearParametros("@pass", trainee.Pass);
                datos.ejecutarLectura();
                if (datos.lectorData.Read())
                {
                    trainee.Id = (int)datos.lectorData["id"];
                    trainee.Admin = (bool)datos.lectorData["admin"];
                    if (!(datos.lectorData["nombre"] is DBNull))
                        trainee.Nombre = (string)datos.lectorData["nombre"];
                    if (!(datos.lectorData["apellido"] is DBNull))
                        trainee.Apellido = (string)datos.lectorData["apellido"];
                    if (!(datos.lectorData["urlImagenPerfil"] is DBNull))
                        trainee.UrlImagenPerfil = (string)datos.lectorData["urlImagenPerfil"];

                    return true;
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

        public void Actualizar(Trainee user)
        {
            ConexionDatos datos = new ConexionDatos();
            try
            {
                datos.setearConsulta("UPDATE USERS SET nombre = @nombre, apellido = @apellido, urlImagenPerfil = @imagen WHERE id = @id");
                datos.setearParametros("@imagen", (object)user.UrlImagenPerfil ?? DBNull.Value);
                datos.setearParametros("@nombre", user.Nombre);
                datos.setearParametros("@apellido", user.Apellido);
                datos.setearParametros("@id", user.Id);
                datos.ejecutarAccion();
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
