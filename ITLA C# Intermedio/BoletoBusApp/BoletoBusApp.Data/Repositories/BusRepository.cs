using BoletoBusApp.Data.Base;
using BoletoBusApp.Data.Entities.Configuration;
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
    public class BusRepository : IBaseRepository<Bus, int, BusModel>
    {
        public Task<bool> Exists(Expression<Func<Bus, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<BusModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<BusModel>>> GetAll(Expression<Func<Bus, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<BusModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<BusModel>> Remove(Bus entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<BusModel>> Save(Bus entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<BusModel>> Update(Bus entity)
        {
            throw new NotImplementedException();
        }
    }
}
