using HairHub.db;
using HairHub.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairHub.dao.impl
{
    class ClienteDAO : IDAO<Cliente>
    {
        public string Create(Cliente cliente)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();

            sql.Append("INSERT INTO CLIENTE(NOME, TELEFONE) VALUES ('"+cliente.Nome+"','"+cliente.Telefone+"')");

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                command.ExecuteNonQuery();
                ConnDB.closeConnection();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro ao inserir cliente, por favor, tente novamente mais tarde!");
                return response.ToString();
            }
            response.Append("Cliente cadastrado com sucesso!");
            return response.ToString();      
        }

        public string Update(Cliente cliente)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();

            sql.Append("UPDATE CLIENTE SET NOME = '" + cliente.Nome + "', TELEFONE = '" + cliente.Telefone +"' ");
            sql.Append("WHERE ID = "+cliente.Id);

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                command.ExecuteNonQuery();
                ConnDB.closeConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro ao atualizar cliente, por favor, tente novamente mais tarde!");
                return response.ToString();
            }

            response.Append("Cliente atualizado com sucesso!");
            return response.ToString();
        }

        public string Delete(Cliente cliente)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();

            sql.Append("DELETE FROM CLIENTE ");
            sql.Append("WHERE ID = " + cliente.Id);

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                command.ExecuteNonQuery();
                ConnDB.closeConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro ao deletar cliente, por favor, tente novamente mais tarde!");
                return response.ToString();
            }

            response.Append("Cliente excluído com sucesso!");
            return response.ToString();
        }

        public MySqlDataReader FindAll()
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();
            MySqlDataReader dr = null;

            sql.Append("SELECT * FROM CLIENTE ORDER BY ID");

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                dr = command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro ao recuperar clientes, por favor, tente novamente mais tarde!");
            }

            return dr;
        }

        public Cliente FindById(int id)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();
            Cliente cliente = new Cliente();

            sql.Append("SELECT ID, NOME, TELEFONE FROM CLIENTE WHERE ID = '"+id+"'");

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    cliente.Id = Convert.ToInt32(dr[0]);
                    cliente.Nome = dr[1].ToString();
                    cliente.Telefone = dr[2].ToString();
                }

                ConnDB.closeConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro interno ao encontrar cliente solicitado, por favor, tente novamente mais tarde!");
            }
            return cliente;
        }

        public MySqlDataReader findAllClienteServicos(Cliente cliente)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();
            MySqlDataReader dr = null;

            sql.Append("SELECT C.NOME, C.TELEFONE, SV.NOME AS NOMESV, SV.VALOR ");
            sql.Append("FROM AGENDAMENTO AG ");
            sql.Append("INNER JOIN CLIENTE C ON C.ID = AG.ID_CLIENTE ");
            sql.Append("INNER JOIN SERVICO SV ON SV.ID = AG.ID_SERVICO ");
            sql.Append("WHERE C.ID = "+cliente.Id);

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                dr = command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro ao recuperar serviços do cliente, por favor, tente novamente mais tarde!");
            }

            return dr;
        }

        public List<Cliente> FindByName(string name)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();
            
            List<Cliente> clientes = new List<Cliente>();

            sql.Append("SELECT DISTINCT ID, NOME, TELEFONE FROM CLIENTE WHERE NOME LIKE '" + name + "%'");

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = dr.GetInt32(dr.GetOrdinal("ID"));
                    cliente.Nome = dr["NOME"].ToString();
                    cliente.Telefone = dr["TELEFONE"].ToString();
                    clientes.Add(cliente);
                }

                ConnDB.closeConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro interno ao encontrar cliente solicitado, por favor, tente novamente mais tarde!");
            }
            return clientes;
        }

    }
}
