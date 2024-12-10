using BoletoBusApp.Data.Base;
using BoletoBusApp.Data.Entities.Configuration;
using BoletoBusApp.Data.Models;

namespace BoletoBusApp.Data.Interfaces
{
    public interface IAsientosRepository : IBaseRepository<Asiento,int,AsientoBusModel>
    {
        public Task<OperationResult<List<AsientoBusModel>>> GetAsientosByBus(int idBus);

    }
}
