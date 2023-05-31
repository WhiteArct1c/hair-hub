using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairHub.model
{
    class ClienteServico : EntidadeDominio
    {
        public string NomeCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public string NomeServico { get; set; }
        public string ValorServico { get; set; }

        public ClienteServico() { }

        public ClienteServico(string nomeCliente, string telefoneCliente, string nomeServico, string valorServico)
        {
            NomeCliente = nomeCliente;
            TelefoneCliente = telefoneCliente;
            NomeServico = nomeServico;
            ValorServico = valorServico;
        }

    }
}
