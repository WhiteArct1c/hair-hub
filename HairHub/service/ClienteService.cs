using HairHub.dao.impl;
using HairHub.db;
using HairHub.model;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HairHub.service
{
    internal class ClienteService
    {
        private ClienteDAO clienteDao;

        public ClienteService()
        {
            clienteDao = new ClienteDAO();
        }

        public string CadastrarCliente(string nome, string telefone)
        {
            if(nome.Trim() == null || nome.Trim() == "" || Regex.IsMatch(nome, "[0-9]"))
            {
                return "Nome do cliente é obrigatório e deve ser válido!";
            }
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
            Console.WriteLine("ID: " + cliente.Id, "Name: " + cliente.Nome, "Telefone: " + cliente.Telefone);
            if (cliente != null && cliente.Id == id)
            {
                return cliente;
            }
            else
            {
                return null;
            }

        }

        public List<Cliente> ObterClientesPorNome(string nome)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = clienteDao.FindByName(nome.Trim());

            return clientes;
        }

        public List<ClienteServico> ObterServicosCliente(Cliente cliente)
        {
            List<ClienteServico> servicosCliente = new List<ClienteServico>();
            var reader = clienteDao.findAllClienteServicos(cliente);

            while (reader.Read())
            {
                Console.WriteLine("passou aqui");
                string nomeCliente = reader["NOME"].ToString();
                string telefoneCliente = reader["TELEFONE"].ToString();
                string nomeServico = reader["NOMESV"].ToString();
                string valorServico = reader["VALOR"].ToString();

                ClienteServico clienteServico = new ClienteServico(nomeCliente, telefoneCliente, nomeServico, valorServico);
                servicosCliente.Add(clienteServico);
            }
            ConnDB.closeConnection();
            reader.Close();
            return servicosCliente;
        }

    }
}
