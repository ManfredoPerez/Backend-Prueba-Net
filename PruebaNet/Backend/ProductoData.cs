using PruebaNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PruebaNet.Backend
{
    public class ProductoData
    {
        //REGISTRAR PRODUCTOS
        public static bool Registrar(Productos oProductos)
        {
            //realizamos o llamamos a la conexio 
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                //llamamos al procedimiento almacenado de la base de daots 
                SqlCommand cmd = new SqlCommand("pro_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //enviamos los datos a la BD
                cmd.Parameters.AddWithValue("@nombre", oProductos.nombre);
                cmd.Parameters.AddWithValue("@marca", oProductos.marca);
                cmd.Parameters.AddWithValue("@precio", oProductos.precio);
                cmd.Parameters.AddWithValue("@descripcion", oProductos.descripcion);
                cmd.Parameters.AddWithValue("@tipo", oProductos.tipo);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        //MODIFICAR PRODUCTOS
        public static bool Modificar(Productos oProductos)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("pro_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //enviamos los datos a la BD
                cmd.Parameters.AddWithValue("@id", oProductos.id);
                cmd.Parameters.AddWithValue("@nombre", oProductos.nombre);
                cmd.Parameters.AddWithValue("@marca", oProductos.marca);
                cmd.Parameters.AddWithValue("@precio", oProductos.precio);
                cmd.Parameters.AddWithValue("@descripcion", oProductos.descripcion);
                cmd.Parameters.AddWithValue("@tipo", oProductos.tipo);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        //LISTAR PRODUCTOS
        public static List<Productos> Listar()
        {
            List<Productos> oListaProducto = new List<Productos>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("pro_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            //Lista la base de datos 
                            oListaProducto.Add(new Productos()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                marca = dr["marca"].ToString(),
                                precio = Convert.ToInt32(dr["precio"]),
                                descripcion = dr["descripcion"].ToString(),
                                fecha = Convert.ToDateTime(dr["fecha"].ToString()),
                                tipo = dr["tipo"].ToString()
                            });
                        }

                    }



                    return oListaProducto;
                }
                catch (Exception ex)
                {
                    return oListaProducto;
                }
            }
        }


        //OBTENER/MOSTRAR PRODUCTO EN ESPECIFICO
        public static Productos Obtener(int id)
        {
            Productos oProductos = new Productos();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("pro_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //para pedir por medio del id
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            //lista la bd
                            oProductos = new Productos()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                marca = dr["marca"].ToString(),
                                precio = Convert.ToInt32(dr["precio"]),
                                descripcion = dr["descripcion"].ToString(),
                                fecha = Convert.ToDateTime(dr["fecha"].ToString()),
                                tipo = dr["tipo"].ToString()
                            };
                        }

                    }



                    return oProductos;
                }
                catch (Exception ex)
                {
                    return oProductos;
                }
            }
        }

        //ELIMINAR PRODUCTOS
        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("pro_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //para eliminar por medio del id
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}