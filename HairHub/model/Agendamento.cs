using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairHub.model
{
    class Agendamento: EntidadeDominio
    {
        public string Data { get; set; }
        public string Hora { get; set; }

        public Servico Servico { get; set; }
        public Cliente Cliente { get; set; }

        public Agendamento() { }

        public Agendamento(int id) {
            Id = id;
        }

        public Agendamento(string data, string hora, Servico servico, Cliente cliente)
        {
            Data = data;
            Hora = hora;
            Servico = servico;
            Cliente = cliente;
        }

        public Agendamento(int id,string data, string hora, Servico servico, Cliente cliente)
        {
            Id = id;
            Data = data;
            Hora = hora;
            Servico = servico;
            Cliente = cliente;
        }

    }
}
