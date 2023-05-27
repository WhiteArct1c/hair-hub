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

        public string CadastrarAgendamento(string data, string hora, int idServico, int idCliente)
        {
            Cliente clienteExiste = new Cliente();
            ClienteService clienteService = new ClienteService();
            clienteExiste = clienteService.ObterClientePorId(idCliente);
            if(clienteExiste == null || clienteExiste.Id != idCliente)
            {
                return "Cliente não encontrado.";
            }

            Servico servicoExiste = new Servico();
            ServicoService servicoService = new ServicoService();
            servicoExiste = servicoService.ObterServicoPorId(idServico);
            if (servicoExiste == null || servicoExiste.Id != idServico)
            {
                return "Serviço não encontrado.";
            }

            Agendamento novoAgendamento = new Agendamento(data, hora, idServico, idCliente);
            return agendamentoDao.Create(novoAgendamento);
        }

        public string AtualizarAgendamento(int id, string data, string hora, int idServico, int idCliente)
        {
            Cliente clienteExiste = new Cliente();
            ClienteService clienteService = new ClienteService();
            clienteExiste = clienteService.ObterClientePorId(idCliente);
            if (clienteExiste == null || clienteExiste.Id != idCliente)
            {
                return "Cliente não encontrado.";
            }

            Servico servicoExiste = new Servico();
            ServicoService servicoService = new ServicoService();
            servicoExiste = servicoService.ObterServicoPorId(idServico);
            if (servicoExiste == null || servicoExiste.Id != idServico)
            {
                return "Serviço não encontrado.";
            }

            Agendamento agendamento = agendamentoDao.FindById(id);
            if (agendamento != null && agendamento.Id == id)
            {
                agendamento.Data = data;
                agendamento.Hora = hora;
                agendamento.IdServico = idServico;
                agendamento.IdCliente = idCliente;
                return agendamentoDao.Update(agendamento);
            }
            else
            {
                return "Agendamento não encontrado.";
            }
        }

        public string ExcluirAgendamento(int id)
        {
            Agendamento agendamento = agendamentoDao.FindById(id);
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


            var reader = agendamentoDao.FindAll();

            while (reader.Read())
            {
                string data = reader["DATA"].ToString();
                string hora = reader["HORA"].ToString();
                int IdServico = reader.GetInt32(reader.GetOrdinal("ID_SERVICO"));
                int IdCliente = reader.GetInt32(reader.GetOrdinal("ID_CLIENTE"));
                int id = reader.GetInt32(reader.GetOrdinal("ID"));

                Agendamento agendamento = new Agendamento(id, data, hora, IdServico, IdCliente);
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
    }
}