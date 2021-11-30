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



    }
}
