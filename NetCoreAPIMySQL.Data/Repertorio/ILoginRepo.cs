using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data.Repertorio
{
    public interface ILoginRepo
    {
        Task<IEnumerable<DataUsuario>> GetAllDataUsuario();
        Task<DataUsuario> GetDataUsuarioDetails(int id);

        Task<bool> InsertDataUsuario(DataUsuario DataUsuario);

        Task<bool> UpdateDataUsuario(DataUsuario DataUsuario);

        Task<bool> DeleteDataUsuario(DataUsuario DataUsuario);

    }
}
