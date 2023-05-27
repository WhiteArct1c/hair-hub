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
    class AgendamentoDAO: IDAO<Agendamento>
    {
        public string Create(Agendamento agendamento)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();

            sql.Append("INSERT INTO AGENDAMENTO(DATA, HORA, ID_SERVICO, ID_CLIENTE) VALUES " +
                "('" + agendamento.Data + "','" + agendamento.Hora + "','" + agendamento.IdServico + "','" + agendamento.IdCliente+ "')");

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                command.ExecuteNonQuery();
                ConnDB.closeConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro interno ao inserir agendamento, por favor, tente novamente mais tarde!");
                return response.ToString();
            }
            response.Append("Agendamento cadastrado com sucesso!");
            return response.ToString();
        }

        public string Update(Agendamento agendamento)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();

            sql.Append("UPDATE AGENDAMENTO SET DATA = '" + agendamento.Data + "'" +
                ", HORA = '" + agendamento.Hora + "' " +
                ", ID_SERVICO = '" + agendamento.IdServico + "'" +
                ", ID_CLIENTE = '"+agendamento.IdCliente + "' ");

            sql.Append("WHERE ID = " + agendamento.Id);

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                command.ExecuteNonQuery();
                ConnDB.closeConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro interno ao atualizar agendamento, por favor, tente novamente mais tarde!");
                return response.ToString();
            }

            response.Append("Agendamento atualizado com sucesso!");
            return response.ToString();
        }

        public string Delete(Agendamento agendamento)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();

            sql.Append("DELETE FROM AGENDAMENTO ");
            sql.Append("WHERE ID = " + agendamento.Id);

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                command.ExecuteNonQuery();
                ConnDB.closeConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro interno ao deletar agendamento, por favor, tente novamente mais tarde!");
                return response.ToString();
            }

            response.Append("Agendamento excluído com sucesso!");
            return response.ToString();
        }

        public MySqlDataReader FindAll()
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();
            MySqlDataReader dr = null;

            sql.Append("SELECT * FROM AGENDAMENTO");

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                dr = command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro interno ao recuperar agendamentos, por favor, tente novamente mais tarde!");
            }

            return dr;
        }

        public Agendamento FindById(int id)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();
            Agendamento agendamento = new Agendamento();

            sql.Append("SELECT ID, DATA, HORA, ID_SERVICO, ID_CLIENTE FROM AGENDAMENTO WHERE ID = '" + id + "'");

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    agendamento.Id = Convert.ToInt32(dr[0]);
                    agendamento.Data = dr[1].ToString();
                    agendamento.Hora = dr[2].ToString();
                    agendamento.IdServico = Convert.ToInt32(dr[3]);
                    agendamento.IdServico = Convert.ToInt32(dr[4]);
                }

                ConnDB.closeConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro interno ao encontrar agendamento solicitado, por favor, tente novamente mais tarde!");
            }
            return agendamento;
        }
    }
}
