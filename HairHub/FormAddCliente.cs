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
        public FormAddCliente(FormClientes parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {

        }
    }
}
