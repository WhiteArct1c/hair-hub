using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairHub.model
{
    class Agendamento
    {
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public int IdServico { get; set; }
        public int IdCliente { get; set; }

        public Agendamento(DateTime data, DateTime hora, int id_servico, int id_cliente)
        {
            this.Data = data;
            this.Hora = hora;
            this.IdServico = id_servico;
            this.IdCliente = id_cliente;
        }
    }
}
