using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairHub.dao
{
    interface IDAO<T>
    {
        string Create(T entidade);

        string Update(T entidade);

        string Delete(T entidade);

        MySqlDataReader FindAll();

        T FindById(int id);

        List<T> FindByName(string name);
    }
}
