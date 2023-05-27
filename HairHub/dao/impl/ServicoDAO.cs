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
    class ServicoDAO: IDAO<Servico>
    {
        public string Create(Servico servico)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();

            sql.Append("INSERT INTO SERVICO(NOME, DESCRICAO, VALOR) VALUES ('" + servico.Nome + "','" + servico.Descricao + "','" + servico.Valor + "')");

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                command.ExecuteNonQuery();
                ConnDB.closeConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro interno ao inserir serviço, por favor, tente novamente mais tarde!");
                return response.ToString();
            }
            response.Append("Serviço cadastrado com sucesso!");
            return response.ToString();
        }

        public string Update(Servico servico)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();

            sql.Append("UPDATE SERVICO SET NOME = '" + servico.Nome + "', DESCRICAO = '" + servico.Descricao + "' , VALOR = '" + servico.Valor + "' ");
            sql.Append("WHERE ID = " + servico.Id);

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                command.ExecuteNonQuery();
                ConnDB.closeConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro interno ao atualizar serviço, por favor, tente novamente mais tarde!");
                return response.ToString();
            }

            response.Append("Serviço atualizado com sucesso!");
            return response.ToString();
        }

        public string Delete(Servico servico)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();

            sql.Append("DELETE FROM SERVICO ");
            sql.Append("WHERE ID = " + servico.Id);

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                command.ExecuteNonQuery();
                ConnDB.closeConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro interno ao deletar serviço, por favor, tente novamente mais tarde!");
                return response.ToString();
            }

            response.Append("Serviço excluído com sucesso!");
            return response.ToString();
        }

        public MySqlDataReader FindAll()
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();
            MySqlDataReader dr = null;

            sql.Append("SELECT * FROM SERVICO");

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                dr = command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro interno ao recuperar serviços, por favor, tente novamente mais tarde!");
            }

            return dr;
        }

        public Servico FindById(int id)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();
            Servico servico = new Servico();

            sql.Append("SELECT ID, NOME, DESCRICAO, VALOR FROM SERVICO WHERE ID = '" + id + "'");

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    servico.Id = Convert.ToInt32(dr[0]);
                    servico.Nome = dr[1].ToString();
                    servico.Descricao = dr[2].ToString();
                    servico.Valor = dr[3].ToString();
                }

                ConnDB.closeConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro interno ao encontrar cliente solicitado, por favor, tente novamente mais tarde!");
            }
            return servico;
        }
    }
}
