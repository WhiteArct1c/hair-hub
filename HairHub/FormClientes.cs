using HairHub.model;
using HairHub.service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HairHub
{
    public partial class FormClientes : Form
    {
        FormAddCliente form;
        FormDetalhesCliente formDetalhes;

        public FormClientes()
        {
            InitializeComponent();
            Display();

            form = new FormAddCliente(this);
            formDetalhes = new FormDetalhesCliente(this);
        }

     
        private void btnNovo_Click(object sender, EventArgs e)
        {
            //FormAddCliente form = new FormAddCliente(this);
            form.Clear();
            form.ShowDialog();

        }

        public void Display()
        {
            if (dataGridClientes.Rows.Count > 0)
            {
                dataGridClientes.Rows.Clear();
            }
            ClienteService cliente = new ClienteService();
            List<Cliente> clientes = cliente.ObterTodosClientes();
            foreach (var pessoa in clientes)
            {
                dataGridClientes.Rows.Add(pessoa.Id, pessoa.Nome, pessoa.Telefone);
            }

        }

        public void DisplaySearch()
        {
            if (dataGridClientes.Rows.Count > 0)
            {
                dataGridClientes.Rows.Clear();
            }
            ClienteService cliente = new ClienteService();
            List<Cliente> clientes = cliente.ObterClientesPorNome(txtPesquisar.Text);
            foreach (var pessoa in clientes)
            {
                dataGridClientes.Rows.Add(pessoa.Id, pessoa.Nome, pessoa.Telefone);
            }

        }

        private void dataGridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridClientes.Columns["detalhes"].Index && e.RowIndex >= 0)
            {
                //formDetalhes.Clear();
                formDetalhes.id = dataGridClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
                formDetalhes.nome = dataGridClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
                formDetalhes.telefone = dataGridClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
                formDetalhes.Display(); 
                formDetalhes.ShowDialog();
            };


            if (e.ColumnIndex == dataGridClientes.Columns["editar"].Index && e.RowIndex >= 0)
            {   
                form.Clear();
                form.id = dataGridClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
                form.nome = dataGridClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.telefone = dataGridClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
            };


            if (e.ColumnIndex == dataGridClientes.Columns["deletar"].Index && e.RowIndex >= 0)
            {
                ClienteService cliente = new ClienteService();

                string idCliente = dataGridClientes.Rows[e.RowIndex].Cells[0].Value.ToString();

                string reposta = cliente.ExcluirCliente(int.Parse(idCliente));
                            
                MessageBox.Show(reposta);
                  
                Display();
            };



        }



        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {

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
