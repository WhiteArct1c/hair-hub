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
    public partial class FormAddServico : Form
    {
        private readonly FormServicos _parent;
        public string id, nome, valor, descricao;

    

        public FormAddServico(FormServicos parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            lblTitle.Text = "Editar Serviço";
            btnNovo.Text = "Editar";
            txtNome.Text = nome;
            txtValor.Text = valor;
            txtDesc.Text = descricao;   
        }

        public void Clear()
        {
            lblTitle.Text = "Novo Serviço";
            btnNovo.Text = "Salvar";
            txtNome.Clear();
            txtValor.Clear();
            txtDesc.Clear();

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ServicoService service = new ServicoService();
            try
            {
                if (btnNovo.Text == "Salvar")
                {
                    string resposta = service.CadastrarServico(txtNome.Text, txtDesc.Text, double.Parse(txtValor.Text));
                    MessageBox.Show(resposta);

                }
                if (btnNovo.Text == "Editar")
                {
                    string resposta = service.AtualizarServico(int.Parse(id), txtNome.Text, txtDesc.Text, double.Parse(txtValor.Text));
                    MessageBox.Show(resposta);

                }
                Clear();
                _parent.Display();
                this.Close();
                

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                MessageBox.Show("Erro, tente novamente!");
            }
            _parent.Display();
        }


    }
}
