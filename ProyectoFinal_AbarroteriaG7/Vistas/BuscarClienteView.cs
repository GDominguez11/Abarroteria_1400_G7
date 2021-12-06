using ProyectoFinal_AbarroteriaG7.Modelos.DAO;
using ProyectoFinal_AbarroteriaG7.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_AbarroteriaG7.Vistas
{
    public partial class BuscarClienteView : Form
    {
        public BuscarClienteView()
        {
            InitializeComponent();
        }
        ClienteDAO clienteDAO = new ClienteDAO();
        public Cliente _cliente = new Cliente();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BuscarClienteView_Load(object sender, EventArgs e)
        {
            ClientesdataGridView.DataSource = clienteDAO.GetClientes();
        }

        private void NombreClientetextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ClientesdataGridView.DataSource = clienteDAO.GetClientesPorNombre(NombreClientetextBox.Text);
        }

        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            if (ClientesdataGridView.RowCount > 0)
            {
                if (ClientesdataGridView.SelectedRows.Count > 0)
                {
                    _cliente.Id = (int)ClientesdataGridView.CurrentRow.Cells["ID"].Value;
                    _cliente.Identidad = ClientesdataGridView.CurrentRow.Cells["IDENTIDAD"].Value.ToString();
                    _cliente.Nombre = ClientesdataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                    this.Close();
                }
            }
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
