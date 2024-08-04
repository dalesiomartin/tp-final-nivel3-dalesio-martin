using accesoDatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDatos datos = new ConexionDatos();

            try
            {

                //datos.setearConsulta("select a.Id,Codigo,Nombre,a.Descripcion,a.IdMarca,m.Descripcion Marca,a.IdCategoria,c.Descripcion Categoria,ImagenUrl,Precio  from ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdMarca = m.Id and a.IdCategoria=c.Id ");


                string query = "Select A.Id, A.Codigo, A.Nombre,A.Descripcion,Precio, C.Descripcion Categoria, M.Descripcion Marca, A.ImagenUrl, A.IdCategoria, A.IdMarca From ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id and A.IdMarca = M.Id ";
                if (id != "")
                {
                    query += " and A.Id = " + id;
                }
                datos.setearConsulta(query);



                datos.ejecutarLectura();

                while (datos.lectorData.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.lectorData["Id"];
                    aux.Codigo = (string)datos.lectorData["Codigo"];
                    aux.Nombre = (string)datos.lectorData["Nombre"];
                    aux.Descripcion = (string)datos.lectorData["Descripcion"];

                    if (!(datos.lectorData["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.lectorData["ImagenUrl"];

                    aux.Precio = Math.Floor((decimal)datos.lectorData["Precio"] * 100) / 100;

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.lectorData["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.lectorData["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.lectorData["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.lectorData["Categoria"];




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

        public Articulo listarConId(int id)
        {
            ConexionDatos datos = new ConexionDatos();
            Articulo aux = new Articulo();
            aux.Categoria = new Categoria();
            aux.Marca = new Marca();

            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as MarcaNombre, C.Descripcion as CategoriaNombre, A.ImagenUrl, A.Precio FROM ARTICULOS A INNER JOIN MARCAS M ON M.Id = A.IdMarca INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria WHERE A.Id = @id");
                datos.setearParametros("@id", id);

                datos.ejecutarLectura();

                while (datos.lectorData.Read())
                {
                    aux.Id = int.Parse(datos.lectorData["Id"].ToString());
                    aux.Codigo = datos.lectorData["Codigo"].ToString();
                    aux.Nombre = datos.lectorData["Nombre"].ToString();
                    aux.Descripcion = datos.lectorData["Descripcion"].ToString();
                    aux.ImagenUrl = datos.lectorData["ImagenUrl"].ToString();
                    aux.Marca.Descripcion = datos.lectorData["MarcaNombre"].ToString();
                    aux.Categoria.Descripcion = datos.lectorData["CategoriaNombre"].ToString();
                    aux.Precio = Math.Floor((decimal)datos.lectorData["Precio"] * 100) / 100;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return aux;
        }


        public void agregar(Articulo nuevo)
        {
            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.setearConsulta(" insert into ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values ('" + nuevo.Codigo + "','" + nuevo.Nombre + "','" + nuevo.Descripcion + "', @IdMarca, @IdCategoria, @ImagenUrl, " + nuevo.Precio + ")");

                datos.setearParametros("@IdMarca", nuevo.Marca.Id);
                datos.setearParametros("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametros("@ImagenUrl", nuevo.ImagenUrl);

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

        public void modificar(Articulo artModif)
        {
            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo=@codigo,Nombre=@nombre,Descripcion=@descrip,IdMarca=@idMarcar,IdCategoria=@idCateg,ImagenUrl=@imag,Precio=@precio where Id=@id");

                datos.setearParametros("@codigo", artModif.Codigo);
                datos.setearParametros("@nombre", artModif.Nombre);
                datos.setearParametros("@descrip", artModif.Descripcion);
                datos.setearParametros("@idMarcar", artModif.Marca.Id);
                datos.setearParametros("@idCateg", artModif.Categoria.Id);
                datos.setearParametros("@imag", artModif.ImagenUrl);
                datos.setearParametros("@precio", artModif.Precio);
                datos.setearParametros("@id", artModif.Id);

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

        public void eliminar(int id)
        {
            try
            {
                ConexionDatos datos = new ConexionDatos();
                datos.setearConsulta("delete from ARTICULOS where id=@id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDatos datos = new ConexionDatos();

            try
            {
                string consulta = "select a.Id,Codigo,Nombre,a.Descripcion,a.IdMarca,m.Descripcion Marca,a.IdCategoria,c.Descripcion Categoria,ImagenUrl,Precio  from ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdMarca = m.Id and a.IdCategoria=c.Id and ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Código de Artículo")
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "Codigo like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Codigo like '%" + filtro + "'";
                            break;
                        default: //case "igual a":
                            consulta += "Codigo like '%" + filtro + "%'";
                            break;
                    }

                }
                else if (campo == "Nombre")
                {

                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default: //case "igual a":
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }

                }
                else
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "m.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "m.Descripcion like '%" + filtro + "'";
                            break;
                        default: //case "igual a":
                            consulta += "m.Descripcion like '%" + filtro + "%'";
                            break;
                    }

                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.lectorData.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.lectorData["Id"];
                    aux.Codigo = (string)datos.lectorData["Codigo"];
                    aux.Nombre = (string)datos.lectorData["Nombre"];
                    aux.Descripcion = (string)datos.lectorData["Descripcion"];

                    if (!(datos.lectorData["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.lectorData["ImagenUrl"];


                    aux.Precio = Math.Floor((decimal)datos.lectorData["Precio"] * 100) / 100;

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.lectorData["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.lectorData["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.lectorData["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.lectorData["Categoria"];



                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<Articulo> LimpiarFiltros()
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDatos datos = new ConexionDatos();


            try
            {
                lista = listar();
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;

        }

        
    }
}
