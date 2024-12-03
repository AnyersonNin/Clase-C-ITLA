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
    public sealed class StatusRepository : IBaseRepository<Status, short, StatusModel>
    {
        public Task<bool> Exists(Expression<Func<Status, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<StatusModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<StatusModel>>> GetAll(Expression<Func<Status, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<StatusModel>> GetEntityBy(short id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<StatusModel>> Remove(Status entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<StatusModel>> Save(Status entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<StatusModel>> Update(Status entity)
        {
            throw new NotImplementedException();
        }
    }


}
