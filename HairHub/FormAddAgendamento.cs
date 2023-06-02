using HairHub.Forms;
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
    public partial class FormAddAgendamento : Form
    {
        private readonly FormAgendamentos _parent;
        public string id, cliente, servico, data, hora;

      

        public FormAddAgendamento(FormAgendamentos parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            lblTitle.Text = "Editar Agendamento";
            btnNovo.Text = "Editar";
            //txtNome.Text = servico;
           // txtServico.Text = cliente;
            txtData.Text = data;
            txtHora.Text = hora;
        }

        public void Clear()
        {
            lblTitle.Text = "Novo Agendamento";
            btnNovo.Text = "Salvar";
            txtNome.Clear();
            txtServico.Clear();
            txtData.Clear();
            txtHora.Clear();

        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            AgendamentoService service = new AgendamentoService();
            try
            {
                if (btnNovo.Text == "Salvar")
                {
                    string resposta = service.CadastrarAgendamento(txtData.Text, txtHora.Text, int.Parse(txtNome.Text), int.Parse(txtServico.Text));
                    MessageBox.Show(resposta);

                }
                if (btnNovo.Text == "Editar")
                {
                    string resposta = service.AtualizarAgendamento(int.Parse(id), txtData.Text, txtHora.Text, int.Parse(txtNome.Text), int.Parse(txtServico.Text));
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
