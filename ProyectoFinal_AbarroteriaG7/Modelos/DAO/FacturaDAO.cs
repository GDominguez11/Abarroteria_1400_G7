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
    public class FacturaDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool InsertarNuevaFactura(Factura factura, List<DetalleFactura> detalleFactura)
        {                                                              
            bool inserto = false;

            comando.Connection = MiConexion;
            MiConexion.Open();

            SqlTransaction transaction = MiConexion.BeginTransaction();

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO FACTURA ");
                sql.Append(" VALUES (@Fecha, @IdCliente, @SubTotal, @ISV, @Descuento, @Total); ");
                sql.Append(" SELECT SCOPE_IDENTITY() ");

                StringBuilder sqlD = new StringBuilder();
                sql.Append(" INSERT INTO DETALLEFACTURA ");
                sql.Append(" VALUES (@IdFactura, @IdProducto, @Cantidad, @Precio, @Total); ");
                             

                comando.Transaction = transaction;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = factura.Fecha;
                comando.Parameters.Add("@IdCliente", SqlDbType.Int).Value = factura.IdCliente;
                comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = factura.SubTotal;
                comando.Parameters.Add("@ISV", SqlDbType.Decimal).Value = factura.ISV;
                comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = factura.Descuento;
                comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = factura.Total;

                int IdFactura = Convert.ToInt32(comando.ExecuteScalar());

                foreach (var item in detalleFactura)
                {
                    comando.Parameters.Add("@IdFactura", SqlDbType.Int).Value = IdFactura;
                    comando.Parameters.Add("@IdProducto", SqlDbType.Int).Value = item.IdProducto;
                    comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = item.Cantidad;
                    comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = item.Precio;
                    comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = item.Total;
                    comando.ExecuteNonQuery();
                }

                transaction.Commit();              
                MiConexion.Close();
            }
            catch (Exception ex)
            {
                inserto = false;
                transaction.Rollback();
            }
            return inserto;
        }
    }
}
