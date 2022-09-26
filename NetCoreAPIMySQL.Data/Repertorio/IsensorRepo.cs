using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data.Repertorio
{
    public interface IsensorRepo
    {
        Task<IEnumerable<DataSensor>> GetAllDataSensor();
        Task<DataSensor> GetDataSensorDetails(int id);

        Task<bool> InsertDataSensor(DataSensor DataSensor);

        Task<bool> UpdateDataSensor(DataSensor DataSensor);

        Task<bool> DeleteDataSensor(DataSensor DataSensor);


    }
}
