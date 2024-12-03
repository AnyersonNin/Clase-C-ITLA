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
    public class ConductorBusRepository : IBaseRepository<ConductorBus, int, ConductorBusModel>
    {
        public Task<bool> Exists(Expression<Func<ConductorBus, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ConductorBusModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ConductorBusModel>>> GetAll(Expression<Func<ConductorBus, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorBusModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorBusModel>> Remove(ConductorBus entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorBusModel>> Save(ConductorBus entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorBusModel>> Update(ConductorBus entity)
        {
            throw new NotImplementedException();
        }
    }
}
