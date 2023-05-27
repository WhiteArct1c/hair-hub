using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairHub.model
{
    class Cliente: EntidadeDominio
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public Cliente(){ }

        public Cliente(string nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;
        }
    }
}
