using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTransport.Core.Data;

namespace CityTransport.Core.Interfaces
{
    public interface ISchedulesRepository
    {
        Task<Schedule> GetScheduleById(int id);
        Task<IReadOnlyList<Schedule>> GetSchedules();
    }
}
