using ProyectoFinal_AbarroteriaG7.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_AbarroteriaG7.Modelos.DAO
{
    public class ProductoDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool InsertarNuevoProducto(Producto producto)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO PRODUCTO ");
                sql.Append(" VALUES (@Codigo, @Detalle, @Stock, @Precio, @TipoProducto, @Proveedor); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Codigo", SqlDbType.NVarChar, 50).Value = producto.Codigo;
                comando.Parameters.Add("@Detalle", SqlDbType.NVarChar, 70).Value = producto.Detalle;
                comando.Parameters.Add("@Stock", SqlDbType.Int).Value = producto.Stock;
                comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = producto.Precio;
                comando.Parameters.Add("@TipoProducto", SqlDbType.NVarChar, 50).Value = producto.TipoProducto;
                comando.Parameters.Add("@Proveedor", SqlDbType.NVarChar, 50).Value = producto.Proveedor;
                comando.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public DataTable GetProductos()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM PRODUCTO ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                SqlDataReader dr = comando.ExecuteReader();
                dt.Load(dr);
                MiConexion.Close();
            }
            catch (Exception)
            {


            }
            return dt;
        }

        public bool ActualizarProductos(Producto producto)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE PRODUCTO ");
                sql.Append(" SET CODIGO = @Codigo, DETALLE = @Detalle, STOCK = @Stock, PRECIO = @Precio, TIPOPRODUCTO = @TipoProducto, PROVEEDOR = @Proveedor  ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = producto.Id;
                comando.Parameters.Add("@Codigo", SqlDbType.NVarChar, 50).Value = producto.Codigo;
                comando.Parameters.Add("@Detalle", SqlDbType.NVarChar, 70).Value = producto.Detalle;
                comando.Parameters.Add("@Stock", SqlDbType.Int).Value = producto.Stock;
                comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = producto.Precio;
                comando.Parameters.Add("@TipoProducto", SqlDbType.NVarChar, 50).Value = producto.TipoProducto;
                comando.Parameters.Add("@Proveedor", SqlDbType.NVarChar, 50).Value = producto.Proveedor;
                comando.ExecuteNonQuery();
                modifico = true;
                MiConexion.Close();



            }
            catch
            {
                return modifico;
            }
            return modifico;
        }

        public bool EliminarProducto(int id)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM PRODUCTO ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                comando.ExecuteNonQuery();
                modifico = true;
                MiConexion.Close();



            }
            catch
            {
                return modifico;
            }
            return modifico;
        }

        public DataTable GetProductosPorCodigo(string codigo)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM PRODUCTO WHERE NOMBRE LIKE ('%" + codigo + "%') ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                SqlDataReader dr = comando.ExecuteReader();
                dt.Load(dr);
                MiConexion.Close();
            }
            catch (Exception)
            {
                MiConexion.Close();
            }
            return dt;
        }

        public Producto GetProductoPorCodigo(string codigo)
        {
            Producto producto = new Producto();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM PRODUCTO ");
                sql.Append(" WHERE CODIGO = @Codigo; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Codigo", SqlDbType.NVarChar, 50).Value = codigo;
                SqlDataReader dr = comando.ExecuteReader();

                if (dr.Read())
                {
                    producto.Id = (int)dr["ID"];
                    producto.Codigo = (string)dr["CODIGO"];
                    producto.Detalle = (string)dr["DETALLE"];
                    producto.Stock = (int)dr["STOCK"];
                    producto.Precio = (decimal)dr["PRECIO"];
                }

                MiConexion.Close();

            }
            catch (Exception ex)
            {
                MiConexion.Close();
            }
            return producto;
        }


    }
}
