using BoletoBusApp.Data.Entities.Configuration;
using BoletoBusApp.Data.Models;


namespace BoletoBusApp.Data.Interfaces
{
    public interface IBusRepository : IBaseRepository<Bus,int,BusModel>
    {
    }
}
