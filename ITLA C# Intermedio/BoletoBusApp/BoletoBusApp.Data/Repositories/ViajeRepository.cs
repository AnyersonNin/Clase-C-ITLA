using BoletoBusApp.Data.Base;
using BoletoBusApp.Data.Entities.Reservation;
using BoletoBusApp.Data.Interfaces;
using BoletoBusApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBusApp.Data.Repositories
{
    public class ViajeRepository : IBaseRepository<Viaje, int, ViajeModel>
    {
        public Task<bool> Exists(Expression<Func<Viaje, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ViajeModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ViajeModel>>> GetAll(Expression<Func<Viaje, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ViajeModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ViajeModel>> Remove(Viaje entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ViajeModel>> Save(Viaje entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ViajeModel>> Update(Viaje entity)
        {
            throw new NotImplementedException();
        }
    }
}
