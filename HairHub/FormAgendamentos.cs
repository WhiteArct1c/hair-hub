using System;
using System.Windows.Forms;

namespace HairHub.Forms
{
    public partial class FormAgendamentos : Form
    {
        public FormAgendamentos()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, System.EventArgs e)
        {
           FormAddAgendamento form = new FormAddAgendamento();

            form.ShowDialog();
              
        }

        public void Display()
        {

        }


        private void dataGridAgendamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          

            if (e.ColumnIndex == dataGridAgendamentos.Columns["editar"].Index && e.RowIndex >= 0)
            {
       
                MessageBox.Show("Editar");
            };


            if (e.ColumnIndex == dataGridAgendamentos.Columns["deletar"].Index && e.RowIndex >= 0)
            {
       
                MessageBox.Show("Deletar");
            };



        }

    }
}
