
using HairHub.model;
using HairHub.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HairHub.Forms
{
    public partial class FormAgendamentos : Form
    {
        FormAddAgendamento form;

        public FormAgendamentos()
        {
            InitializeComponent();
            Display();

            form = new FormAddAgendamento(this);
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, System.EventArgs e)
        {

            form.Clear();
            form.ShowDialog();
              
        }

        public void Display()
        {
            if (dataGridAgendamentos.Rows.Count > 0) 
            {
                dataGridAgendamentos.Rows.Clear();
            }
            AgendamentoService agendamento = new AgendamentoService();
            List<Agendamento> agendamentos = agendamento.ObterTodosAgendamentos();
          

            foreach (var agenda in agendamentos)
            {
                dataGridAgendamentos.Rows.Add(agenda.Id, agenda.Servico.Nome, agenda.Cliente.Nome, agenda.Data, agenda.Hora);
            }

        }

        public void DisplaySearch()
        {

            if (dataGridAgendamentos.Rows.Count > 0)
            {
                dataGridAgendamentos.Rows.Clear();
            }
            AgendamentoService agendamento = new AgendamentoService();
            List<Agendamento> agendamentos = agendamento.ObterAgendamentoPorNome(txtPesquisar.Text);

            foreach (var agenda in agendamentos)
            {
                dataGridAgendamentos.Rows.Add(agenda.Id, agenda.Servico.Nome, agenda.Cliente.Nome, agenda.Data, agenda.Hora);
            }

        }



        private void dataGridAgendamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          

            if (e.ColumnIndex == dataGridAgendamentos.Columns["editar"].Index && e.RowIndex >= 0)
            {
                form.Clear();


                form.id = dataGridAgendamentos.Rows[e.RowIndex].Cells[0].Value.ToString();
                form.servico = dataGridAgendamentos.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.cliente = dataGridAgendamentos.Rows[e.RowIndex].Cells[2].Value.ToString();
               
                form.data = dataGridAgendamentos.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.hora = dataGridAgendamentos.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();  

            };


            if (e.ColumnIndex == dataGridAgendamentos.Columns["deletar"].Index && e.RowIndex >= 0)
            {
                AgendamentoService agenda = new AgendamentoService();

                string idAgenda = dataGridAgendamentos.Rows[e.RowIndex].Cells[0].Value.ToString();


                string resposta = agenda.ExcluirAgendamento(int.Parse(idAgenda));
                MessageBox.Show(resposta);
            };

            Display();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            DisplaySearch();
            btnLimpar.Visible = true;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Display();
            txtPesquisar.Clear();
            btnLimpar.Visible = false;
        }
    }
}
