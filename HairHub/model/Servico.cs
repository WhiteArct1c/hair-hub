using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairHub.model
{
    class Servico: EntidadeDominio
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }

        public Servico() { }

        public Servico(string nome, string descricao, string valor)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Valor = valor;
        }


    }
}
