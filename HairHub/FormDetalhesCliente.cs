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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace HairHub
{
    public partial class FormDetalhesCliente : Form
    {
        private readonly FormClientes _parent;
        public string id, nome, telefone;
        public FormDetalhesCliente(FormClientes parent)
        {
            InitializeComponent();
            _parent = parent;
 
        }

        public void Display()
        {
            ClienteService cliente = new ClienteService();

            Console.WriteLine("id :" + id);
            Console.WriteLine("nome :" + nome);
            Console.WriteLine("telefone :" + telefone);
            Cliente historicoCliente = new Cliente(int.Parse(id),nome,telefone);

            List<ClienteServico> clienteServico = cliente.ObterServicosCliente(historicoCliente);


            dataGridDetalhesCliente.Rows.Clear();

         foreach (var historico in clienteServico)
            {
             
                dataGridDetalhesCliente.Rows.Add(historico.NomeCliente, historico.TelefoneCliente, historico.NomeServico, historico.ValorServico);

            };
        

          

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

            _parent.Display();
        }
    }


}

