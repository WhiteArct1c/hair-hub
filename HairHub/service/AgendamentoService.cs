using HairHub.dao.impl;
using HairHub.db;
using HairHub.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairHub.service
{
    internal class AgendamentoService
    {

        private AgendamentoDAO agendamentoDao;

        public AgendamentoService()
        {
            agendamentoDao = new AgendamentoDAO();
        }

        public string CadastrarAgendamento(string data, string hora, int IdServico, int IdCliente)
        {
            Cliente clienteExiste = new Cliente();
            ClienteService clienteService = new ClienteService();
            clienteExiste = clienteService.ObterClientePorId(IdCliente);
            if(clienteExiste == null || clienteExiste.Id != IdCliente)
            {
                return "Cliente não encontrado.";
            }

            Servico servicoExiste = new Servico();
            ServicoService servicoService = new ServicoService();
            servicoExiste = servicoService.ObterServicoPorId(IdServico);
            if (servicoExiste == null || servicoExiste.Id != IdServico)
            {
                return "Serviço não encontrado.";
            }

            Agendamento novoAgendamento = new Agendamento(data, hora, servicoExiste, clienteExiste);
            return agendamentoDao.Create(novoAgendamento);
        }

        public string AtualizarAgendamento(int id, string data, string hora, int IdServico, int IdCliente)
        {
            Console.WriteLine("Chegou no service agendamento");
            Console.WriteLine("Id ag:"+id + "data"+data + "IdServico:"+IdServico + "IdCliente:"+ IdCliente);

            Cliente clienteExiste = new Cliente();
            ClienteService clienteService = new ClienteService();
            clienteExiste = clienteService.ObterClientePorId(IdCliente);
            if (clienteExiste == null || clienteExiste.Id != IdCliente)
            {
                return "Cliente não encontrado.";
            }

            Servico servicoExiste = new Servico();
            ServicoService servicoService = new ServicoService();
            servicoExiste = servicoService.ObterServicoPorId(IdServico);
            if (servicoExiste == null || servicoExiste.Id != IdServico)
            {
                return "Serviço não encontrado.";
            }

            Agendamento agendamento = agendamentoDao.FindById(id);

            if (agendamento != null && agendamento.Id == id)
            {
                agendamento.Data = data;
                agendamento.Hora = hora;
                agendamento.Servico = servicoExiste;
                agendamento.Cliente = clienteExiste;
                return agendamentoDao.Update(agendamento);
            }
            else
            {
                return "Agendamento não encontrado.";
            }
        }

        public string ExcluirAgendamento(int id)
        {
            Agendamento agendamento = new Agendamento(id);
            if (agendamento != null && agendamento.Id == id)
            {
                return agendamentoDao.Delete(agendamento);
            }
            else
            {
                return "Agendamento não encontrado.";
            }
        }

        public List<Agendamento> ObterTodosAgendamentos()
        {
            List<Agendamento> agendamentos = new List<Agendamento>();
            ServicoService servicoService = new ServicoService();
            ClienteService clienteService = new ClienteService();

            var reader = agendamentoDao.FindAll();

            while (reader.Read())
            {
                string data = reader["AG_DATA"].ToString();
                string hora = reader["AG_HORA"].ToString();
                Servico servico = new Servico(
                    reader.GetInt32(reader.GetOrdinal("SV_ID")),
                    reader["SV_NOME"].ToString(),
                    reader["SV_DESCRICAO"].ToString(),
                    reader["SV_VALOR"].ToString()
                 );
                Cliente cliente = new Cliente
                (  reader.GetInt32(reader.GetOrdinal("CLI_ID")),
                   reader["CLI_NOME"].ToString(),
                   reader["CLI_TELEFONE"].ToString()
                );
                int id = reader.GetInt32(reader.GetOrdinal("AG_ID"));

                Agendamento agendamento = new Agendamento(id, data, hora, servico, cliente);
                agendamentos.Add(agendamento);
            }

            ConnDB.closeConnection();
            reader.Close();
            return agendamentos;
        }


        public Agendamento ObterAgendamentoPorId(int id)
        {
            Agendamento agendamento = new Agendamento();
            agendamento = agendamentoDao.FindById(id);
            if (agendamento != null && agendamento.Id == id)
            {
                return agendamento;
            }
            else
            {
                return null;
            }

        }

        public List<Agendamento> ObterAgendamentoPorNome(string nome)
        {
            List<Agendamento> agendamentos = new List<Agendamento>();
            agendamentos = agendamentoDao.FindByName(nome);


            ConnDB.closeConnection();
           
            return agendamentos;
        }

    }
}