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
    public class ReservaRepository : IBaseRepository<Reserva, int, ReservaModel>
    {
        public Task<bool> Exists(Expression<Func<Reserva, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ReservaModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ReservaModel>>> GetAll(Expression<Func<Reserva, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaModel>> Remove(Reserva entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaModel>> Save(Reserva entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaModel>> Update(Reserva entity)
        {
            throw new NotImplementedException();
        }
    }
}
