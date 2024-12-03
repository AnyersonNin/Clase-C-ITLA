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
    public class ReservaDetalleRepository : IBaseRepository<ReservaDetalle, int, ReservaDetalleModel>
    {
        public Task<bool> Exists(Expression<Func<ReservaDetalle, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ReservaDetalleModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ReservaDetalleModel>>> GetAll(Expression<Func<ReservaDetalle, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaDetalleModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaDetalleModel>> Remove(ReservaDetalle entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaDetalleModel>> Save(ReservaDetalle entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaDetalleModel>> Update(ReservaDetalle entity)
        {
            throw new NotImplementedException();
        }
    }
}
