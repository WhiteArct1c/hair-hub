using HairHub.Forms;
using System;
using System.Windows.Forms;

namespace HairHub
{
    public partial class Form1 : Form
    {
        private Form activeForm;


        public Form1()
        {

            InitializeComponent();
           
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }



        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            childForm.BringToFront();
            lblTitle.Text = childForm.Text;
        }



        private void btnHome_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            lblTitle.Text = "";
        }

        private void btnAgendamentos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAgendamentos());
        }


        private void btnClientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormClientes());
        }

        private void btnServicos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormServicos());
        }
    }
}
