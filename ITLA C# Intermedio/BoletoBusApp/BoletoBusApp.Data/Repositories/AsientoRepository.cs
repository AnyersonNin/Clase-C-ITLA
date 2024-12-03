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
    public class AsientoRepository : IBaseRepository<Asiento, int, AsientoModel>
    {
        public Task<bool> Exists(Expression<Func<Asiento, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<AsientoModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<AsientoModel>>> GetAll(Expression<Func<Asiento, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<AsientoModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<AsientoModel>> Remove(Asiento entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<AsientoModel>> Save(Asiento entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<AsientoModel>> Update(Asiento entity)
        {
            throw new NotImplementedException();
        }
    }
}
