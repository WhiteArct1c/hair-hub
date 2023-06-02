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
                "('" + agendamento.Data + "','" + agendamento.Hora + "','" + agendamento.Servico.Id + "','" + agendamento.Cliente.Id+ "')");

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
                ", ID_SERVICO = '" + agendamento.Servico.Id + "'" +
                ", ID_CLIENTE = '"+agendamento.Cliente.Id + "' ");

            sql.Append("WHERE ID = " + agendamento.Id);

            Console.WriteLine("passou aq ");

            Console.WriteLine(sql.ToString());  

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

            sql.Append("SELECT ag.ID as AG_ID, ag.DATA as AG_DATA, ag.HORA as AG_HORA, ");
            sql.Append("sv.ID as SV_ID, sv.NOME as SV_NOME, sv.DESCRICAO as SV_DESCRICAO, sv.VALOR as SV_VALOR, ");
            sql.Append("cl.ID as CLI_ID, cl.NOME as CLI_NOME, cl.TELEFONE as CLI_TELEFONE ");
            sql.Append("FROM AGENDAMENTO ag ");
            sql.Append("INNER JOIN SERVICO sv ON sv.ID = ag.ID_SERVICO ");
            sql.Append("INNER JOIN CLIENTE cl ON cl.ID = ag.ID_CLIENTE");

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
            Cliente cliente = new Cliente();
            Servico servico = new Servico();

            sql.Append("SELECT ag.ID as AG_ID, ag.DATA as AG_DATA, ag.HORA as AG_HORA, ");
            sql.Append("sv.ID as SV_ID, sv.NOME as SV_NOME, sv.DESCRICAO as SV_DESCRICAO, sv.VALOR as SV_VALOR, ");
            sql.Append("cl.ID as CLI_ID, cl.NOME as CLI_NOME, cl.TELEFONE as CLI_TELEFONE ");
            sql.Append("FROM AGENDAMENTO ag ");
            sql.Append("INNER JOIN SERVICO sv ON sv.ID = ag.ID_SERVICO ");
            sql.Append("INNER JOIN CLIENTE cl ON cl.ID = ag.ID_CLIENTE ");
            sql.Append("WHERE ag.ID = " + id);

            Console.WriteLine(sql.ToString());
            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    agendamento.Id = Convert.ToInt32(dr[0]);
                    agendamento.Data = dr[1].ToString();
                    agendamento.Hora = dr[2].ToString();
                    servico.Id = Convert.ToInt32(dr[3]);
                    servico.Nome = dr[4].ToString();
                    servico.Descricao = dr[5].ToString();
                    servico.Valor = dr[6].ToString();
                    cliente.Id = Convert.ToInt32(dr[7]);
                    cliente.Nome = dr[8].ToString();
                    cliente.Telefone = dr[9].ToString();
                    agendamento.Servico = servico;
                    agendamento.Cliente = cliente;
                }

                ConnDB.closeConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro interno ao encontrar agendamento solicitado, por favor, tente novamente mais tarde!");
            }

            Console.WriteLine("ID agendamento: "+agendamento.Id);
            return agendamento;
        }

        public List<Agendamento> FindByName(string name)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder response = new StringBuilder();

            List<Agendamento> agendamentos = new List<Agendamento>();
            

            sql.Append("SELECT ag.ID as AG_ID, ag.DATA as AG_DATA, ag.HORA as AG_HORA, ");
            sql.Append("sv.ID as SV_ID, sv.NOME as SV_NOME, sv.DESCRICAO as SV_DESCRICAO, sv.VALOR as SV_VALOR, ");
            sql.Append("cl.ID as CLI_ID, cl.NOME as CLI_NOME, cl.TELEFONE as CLI_TELEFONE ");
            sql.Append("FROM AGENDAMENTO ag ");
            sql.Append("INNER JOIN SERVICO sv ON sv.ID = ag.ID_SERVICO ");
            sql.Append("INNER JOIN CLIENTE cl ON cl.ID = ag.ID_CLIENTE ");
            sql.Append("WHERE cl.NOME LIKE '" + name+"%'");

            Console.WriteLine(sql.ToString());
            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), ConnDB.openConnection());
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Agendamento agendamento = new Agendamento();
                    Cliente cliente = new Cliente();
                    Servico servico = new Servico();

                    agendamento.Id = Convert.ToInt32(dr[0]);
                    agendamento.Data = dr[1].ToString();
                    agendamento.Hora = dr[2].ToString();
                    servico.Id = Convert.ToInt32(dr[3]);
                    servico.Nome = dr[4].ToString();
                    servico.Descricao = dr[5].ToString();
                    servico.Valor = dr[6].ToString();
                    cliente.Id = Convert.ToInt32(dr[7]);
                    cliente.Nome = dr[8].ToString();
                    cliente.Telefone = dr[9].ToString();
                    agendamento.Servico = servico;
                    agendamento.Cliente = cliente;

                    agendamentos.Add(agendamento);
                }

                ConnDB.closeConnection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Append("Erro interno ao encontrar agendamento solicitado, por favor, tente novamente mais tarde!");
            }

           
            return agendamentos;
        }
    }
}
