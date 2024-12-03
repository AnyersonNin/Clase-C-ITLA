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
    public class ConductorRepository : IBaseRepository<Conductor ,int, ConductorModel>
    {
        public Task<bool> Exists(Expression<Func<Conductor, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ConductorModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ConductorModel>>> GetAll(Expression<Func<Conductor, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorModel>> Remove(Conductor entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorModel>> Save(Conductor entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorModel>> Update(Conductor entity)
        {
            throw new NotImplementedException();
        }
    }
}
