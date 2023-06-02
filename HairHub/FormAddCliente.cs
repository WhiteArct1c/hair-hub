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
    public partial class FormAddCliente : Form
    {
        private readonly FormClientes _parent;
        public string id, nome, telefone;

        public FormAddCliente(FormClientes parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            lblTitle.Text = "Editar Cliente";
            btnNovo.Text = "Editar";
            txtNome.Text = nome;
            txtTelefone.Text = telefone;
        }

        public void Clear()
        {
            lblTitle.Text = "Novo Cliente";
            btnNovo.Text = "Salvar";
            txtNome.Clear();
            txtTelefone.Clear();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ClienteService service = new ClienteService();
            try
            {
                if (btnNovo.Text == "Salvar")
                {
                    string resposta = service.CadastrarCliente(txtNome.Text, txtTelefone.Text);
                    MessageBox.Show(resposta);

                }
                if(btnNovo.Text == "Editar")
                {
                    string resposta = service.AtualizarCliente(int.Parse(id), txtNome.Text, txtTelefone.Text);
                    MessageBox.Show(resposta);
                }
             }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                MessageBox.Show("Erro, tente novamente!");
            }
            finally
            {
                Clear();
                _parent.Display();
                this.Close();
            }
        }

    }
}
