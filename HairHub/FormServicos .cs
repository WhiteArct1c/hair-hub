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
    public partial class FormServicos : Form
    {
        public FormServicos()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FormAddServico form = new FormAddServico();
            form.ShowDialog();

        }

    

        private void dataGridServicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          

                if (e.ColumnIndex == dataGridServicos.Columns["editar"].Index && e.RowIndex >= 0)
                {

                    MessageBox.Show("Editar");
                };


                if (e.ColumnIndex == dataGridServicos.Columns["deletar"].Index && e.RowIndex >= 0)
                {

                    MessageBox.Show("Deletar");
                };



            
        }
    }
}
