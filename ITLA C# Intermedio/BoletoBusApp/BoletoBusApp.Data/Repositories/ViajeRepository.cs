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
    public class ViajeRepository : IViajeRepository
    {
        private readonly ILogger _logger;
        private readonly BoletoContext _context;

        public ViajeRepository(BoletoContext boletoContext, ILogger<ViajeRepository> logger)
        {
            _context = boletoContext;
            _logger = logger;
        }

        public Task<bool> Exists(Expression<Func<ViajeRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ViajeModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ViajeModel>>> GetAll(Expression<Func<ViajeRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ViajeModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ViajeModel>> Remove(ViajeRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ViajeModel>> Save(ViajeRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ViajeModel>> Update(ViajeRepository entity)
        {
            throw new NotImplementedException();
        }
    }
}
