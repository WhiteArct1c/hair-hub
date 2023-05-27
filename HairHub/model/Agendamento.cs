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
        public int IdServico { get; set; }
        public int IdCliente { get; set; }

        public Agendamento() { }

        public Agendamento(string data, string hora, int idServico, int idCliente)
        {
            Data = data;
            Hora = hora;
            IdServico = idServico;
            IdCliente = idCliente;
        }
    }
}
