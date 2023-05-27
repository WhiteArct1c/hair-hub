using HairHub.dao.impl;
using HairHub.db;
using HairHub.model;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairHub.service
{
    internal class ClienteService
    {

        public interface IClienteServico
        {
            string NomeCliente { get; }
            string TelefoneCliente { get; }
            string NomeServico { get; }
            string ValorServico { get; }
        }
        public class ClienteServico : IClienteServico
        {
            public string NomeCliente { get; set; }
            public string TelefoneCliente { get; set; }
            public string NomeServico { get; set; }
            public string ValorServico { get; set; }

            public ClienteServico(string nomeCliente, string telefoneCliente, string nomeServico, string valorServico)
            {
                NomeCliente = nomeCliente;
                TelefoneCliente = telefoneCliente;
                NomeServico = nomeServico;
                ValorServico = valorServico;
            }
        }// tirar daqui talvez?

        private ClienteDAO clienteDao;

        public ClienteService()
        {
            clienteDao = new ClienteDAO();
        }

        public string CadastrarCliente(string nome, string telefone)
        {
                Cliente novoCliente = new Cliente(nome, telefone);
                return clienteDao.Create(novoCliente);
        }

        public string AtualizarCliente(int id, string nome, string telefone)
        {
            Cliente cliente = clienteDao.FindById(id);
            if (cliente != null && cliente.Id == id)
            {
                cliente.Nome = nome;
                cliente.Telefone = telefone;
                return clienteDao.Update(cliente);
            }
            else
            {
                return "Cliente não encontrado.";
            }
        }

        public string ExcluirCliente(int id)
        {
            Cliente cliente = clienteDao.FindById(id);
            if (cliente != null && cliente.Id == id)
            {
                return clienteDao.Delete(cliente);
            }
            else
            {
                return "Cliente não encontrado.";
            }
        }

        public List<Cliente> ObterTodosClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            var reader = clienteDao.FindAll();

            while (reader.Read())
            {
                string nome = reader["NOME"].ToString();
                string telefone = reader["TELEFONE"].ToString();
                int id = reader.GetInt32(reader.GetOrdinal("ID"));

                Cliente cliente = new Cliente(id ,nome, telefone);
                clientes.Add(cliente);
            }
            ConnDB.closeConnection();
            reader.Close();
            return clientes;
        }

        public Cliente ObterClientePorId(int id)
        {
            Cliente cliente = new Cliente();
            cliente = clienteDao.FindById(id);
            if(cliente != null && cliente.Id == id)
            {
                return cliente;
            }
            else
            {
                return null;
            }

        }

        public List<IClienteServico> ObterServicosCliente(Cliente cliente)
        {
            List<IClienteServico> servicosCliente = new List<IClienteServico>();
            var reader = clienteDao.findAllClienteServicos(cliente);

            while (reader.Read())
            {
                Console.WriteLine("passou aqui");
                string nomeCliente = reader["NOME"].ToString();
                string telefoneCliente = reader["TELEFONE"].ToString();
                string nomeServico = reader["NOMESV"].ToString();
                string valorServico = reader["VALOR"].ToString();

                IClienteServico clienteServico = new ClienteServico(nomeCliente, telefoneCliente, nomeServico, valorServico);
                servicosCliente.Add(clienteServico);
            }
            ConnDB.closeConnection();
            reader.Close();
            return servicosCliente;
        }

    }
}
