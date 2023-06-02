using HairHub.model;
using HairHub.service;
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
        FormAddServico form;
        public FormServicos()
        {
            InitializeComponent();
            Display();
            form = new FormAddServico(this);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            form.Clear();          
            form.ShowDialog();
        }

        public void Display()
        {
            if (dataGridServicos.Rows.Count > 0)
            {
                dataGridServicos.Rows.Clear();
            }
                ServicoService servico = new ServicoService();
                List<Servico> servicos = servico.ObterTodosServicos();

                foreach (var serv in servicos)
                {
                    dataGridServicos.Rows.Add(serv.Id, serv.Nome, serv.Descricao, serv.Valor);
                } 
            
        }

        public void DisplaySearch()
        {
            if (dataGridServicos.Rows.Count > 0)
            {
                dataGridServicos.Rows.Clear();
            }

            ServicoService servico = new ServicoService();
            List<Servico> servicos = servico.ObterServicosPorNome(txtPesquisar.Text);
            foreach (var serv in servicos)
            {
                dataGridServicos.Rows.Add(serv.Id, serv.Nome, serv.Descricao, serv.Valor);
            }

        }

        private void dataGridServicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          

                if (e.ColumnIndex == dataGridServicos.Columns["editar"].Index && e.RowIndex >= 0)

                {
                form.Clear();   
                form.id = dataGridServicos.Rows[e.RowIndex].Cells[0].Value.ToString();
                form.nome = dataGridServicos.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.descricao = dataGridServicos.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.valor = dataGridServicos.Rows[e.RowIndex].Cells[3].Value.ToString();
                
                form.UpdateInfo();
                form.ShowDialog();
                
                };


                if (e.ColumnIndex == dataGridServicos.Columns["deletar"].Index && e.RowIndex >= 0)
                {

                ServicoService servico = new ServicoService();

                string idServico = dataGridServicos.Rows[e.RowIndex].Cells[0].Value.ToString();

                string resposta = servico.ExcluirServico(int.Parse(idServico));
                MessageBox.Show(resposta);

                Display();
          
                };
            
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
