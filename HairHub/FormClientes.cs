using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HairHub
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FormAddCliente form = new FormAddCliente(this);
            //form.Clear();
            form.ShowDialog();

        }
        public void Display()
        {

        }



        private void dataGridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridClientes.Columns["detalhes"].Index && e.RowIndex >= 0)
            {
      
          
                FormDetalhesCliente form = new FormDetalhesCliente();
                form.Show();
            };


            if (e.ColumnIndex == dataGridClientes.Columns["editar"].Index && e.RowIndex >= 0)
            {
       
                MessageBox.Show("Editar");
            };


            if (e.ColumnIndex == dataGridClientes.Columns["deletar"].Index && e.RowIndex >= 0)
            {

                MessageBox.Show("Deletar");
            };


       
        }

  

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
