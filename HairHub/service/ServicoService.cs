using HairHub.dao.impl;
using HairHub.db;
using HairHub.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HairHub.service
{
    internal class ServicoService
    {

        private ServicoDAO servicoDao;

        public ServicoService()
        {
            servicoDao = new ServicoDAO();
        }

        public string CadastrarServico(string nome, string descricao, double valor)
        {
            if (valor < 0)
            {
                MessageBox.Show("O valor do serviço não pode ser menor que 0.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Erro ao criar serviço";
            }

                Servico novoServico = new Servico(nome, descricao, valor.ToString());
                return servicoDao.Create(novoServico);
           
        }

        public string AtualizarServico(int id,string nome, string descricao, double valor)
        {
            if (valor < 0)
            {
                MessageBox.Show("O valor do serviço não pode ser menor que 0.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Erro ao criar serviço";
            }

                Servico servico = servicoDao.FindById(id);
                if (servico != null && servico.Id == id)
                {
                    servico.Nome = nome;
                    servico.Descricao = descricao;
                    servico.Valor = valor.ToString();
                    return servicoDao.Update(servico);
                }
                else
                {
                    return "Serviço não encontrado.";
                }

        }

        public string ExcluirServico(int id)
        {

                Servico servico = servicoDao.FindById(id);
                if (servico != null && servico.Id == id)
                {
                    return servicoDao.Delete(servico);
                }
                else
                {
                    return "Servico não encontrado.";
                }
  
        }

        public List<Servico> ObterTodosServicos()
        {
            List<Servico> servicos = new List<Servico>();


                var reader = servicoDao.FindAll();

                while (reader.Read())
                {
                    string nome = reader["NOME"].ToString();
                    string descricao = reader["DESCRICAO"].ToString();
                    string valor = reader["VALOR"].ToString();
                    int id = reader.GetInt32(reader.GetOrdinal("ID"));

                Servico cliente = new Servico(id ,nome, descricao, valor);
                    servicos.Add(cliente);
                }

                ConnDB.closeConnection();
                reader.Close();
                return servicos;
            }

        public Servico ObterServicoPorId(int id)
        {
            Servico servico = new Servico();
            servico = servicoDao.FindById(id);
            if (servico != null && servico.Id == id)
            {
                return servico;
            }
            else
            {
                return null;
            }

        }
    }
}


