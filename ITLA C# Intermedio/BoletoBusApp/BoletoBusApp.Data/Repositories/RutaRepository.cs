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
    public class RutaRepository : IBaseRepository<Ruta, int, RutaModel>
    {
        public Task<bool> Exists(Expression<Func<Ruta, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<RutaModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<RutaModel>>> GetAll(Expression<Func<Ruta, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RutaModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RutaModel>> Remove(Ruta entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RutaModel>> Save(Ruta entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RutaModel>> Update(Ruta entity)
        {
            throw new NotImplementedException();
        }
    }
}
