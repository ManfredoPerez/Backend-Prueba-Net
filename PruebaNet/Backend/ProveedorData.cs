using PruebaNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PruebaNet.Backend
{
    public class ProveedorData
    {
        //REGISTRAR PROVEEDORES
        public static bool Registrar(Proveedores oProveedores)
        {
            //realizamos o llamamos a la conexion
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                //llamamos al procedimiento almacenado de la base de daots 
                SqlCommand cmd = new SqlCommand("prov_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //enviamos los datos a la BD
                cmd.Parameters.AddWithValue("@nombre", oProveedores.nombre);
                cmd.Parameters.AddWithValue("@direccion", oProveedores.direccion);
                cmd.Parameters.AddWithValue("@telefono", oProveedores.telefono);
               

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
        public static bool Modificar(Proveedores oProveedores)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("prov_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //enviamos los datos a la BD
                cmd.Parameters.AddWithValue("@id", oProveedores.id);
                cmd.Parameters.AddWithValue("@nombre", oProveedores.nombre);
                cmd.Parameters.AddWithValue("@direccion", oProveedores.direccion);
                cmd.Parameters.AddWithValue("@telefono", oProveedores.telefono);

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


        //LISTAR PROVEEDOR
        public static List<Proveedores> Listar()
        {
            List<Proveedores> oListaProveedor = new List<Proveedores>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("prov_listar", oConexion);
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
                            oListaProveedor.Add(new Proveedores()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                direccion = dr["direccion"].ToString(),
                                telefono = dr["telefono"].ToString()
                      
                            });
                        }

                    }



                    return oListaProveedor;
                }
                catch (Exception ex)
                {
                    return oListaProveedor;
                }
            }
        }


        //OBTENER/MOSTRAR PROVEEDOR EN ESPECIFICO
        public static Proveedores Obtener(int id)
        {
            Proveedores oProveedores = new Proveedores();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("prov_obtener", oConexion);
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
                            oProveedores = new Proveedores()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                direccion = dr["direccion"].ToString(),
                                telefono = dr["telefono"].ToString()
                            };
                        }

                    }



                    return oProveedores;
                }
                catch (Exception ex)
                {
                    return oProveedores;
                }
            }
        }

        //ELIMINAR PRODUCTOS
        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("prov_eliminar", oConexion);
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