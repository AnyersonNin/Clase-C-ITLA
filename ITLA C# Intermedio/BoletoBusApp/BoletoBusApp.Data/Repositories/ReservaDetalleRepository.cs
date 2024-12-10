using BoletoBusApp.Data.Base;
using BoletoBusApp.Data.Context;
using BoletoBusApp.Data.Entities.Reservation;
using BoletoBusApp.Data.Interfaces;
using BoletoBusApp.Data.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBusApp.Data.Repositories
{
    public class ReservaDetalleRepository : IReservaDetalleRepository
    {
        private readonly ILogger _logger;
        private readonly BoletoContext _context;
        public ReservaDetalleRepository(BoletoContext boletoContext, ILogger<ReservaDetalleRepository> logger)
        {
            _context = boletoContext;
            _logger = logger;
        }

        public Task<bool> Exists(Expression<Func<ReservaDetalleRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ReservaDetalleModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ReservaDetalleModel>>> GetAll(Expression<Func<ReservaDetalleRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaDetalleModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaDetalleModel>> Remove(ReservaDetalleRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaDetalleModel>> Save(ReservaDetalleRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaDetalleModel>> Update(ReservaDetalleRepository entity)
        {
            throw new NotImplementedException();
        }
    }
}
