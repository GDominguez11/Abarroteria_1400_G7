using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_AbarroteriaG7.Modelos.Entidades
{
    public class Producto
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Detalle { get; set; }

        public int Stock { get; set; }

        public decimal Precio { get; set; }

        public string TipoProducto { get; set; }

        public string Proveedor { get; set; }

    }
}
