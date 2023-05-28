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
    public partial class FormDetalhesCliente : Form
    {
        public FormDetalhesCliente()
        {
            InitializeComponent();
      
        }

        public void Display()
        {

        }

        private void dataGridDetalhesCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridDetalhesCliente.Columns["editar"].Index && e.RowIndex >= 0)
            {
        
                MessageBox.Show("Editar");
            };


            if (e.ColumnIndex == dataGridDetalhesCliente.Columns["deletar"].Index && e.RowIndex >= 0)
            {
           
                MessageBox.Show("Deletar");
            };
        }
    }


}

