using BoletoBusApp.Data.Base;
using BoletoBusApp.Data.Context;
using BoletoBusApp.Data.Interfaces;
using BoletoBusApp.Data.Models;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace BoletoBusApp.Data.Repositories
{
    public class ConductorBusRepository : IConductorBusRepository
    {
        private readonly ILogger _logger;
        private readonly BoletoContext _context;
        public ConductorBusRepository(BoletoContext boletoContext, ILogger<ConductorBusRepository> logger)
        {
            _context = boletoContext;
            _logger = logger;
        }
        public Task<bool> Exists(Expression<Func<ConductorBusRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ConductorBusModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ConductorBusModel>>> GetAll(Expression<Func<ConductorBusRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorBusModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorBusModel>> Remove(ConductorBusRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorBusModel>> Save(ConductorBusRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorBusModel>> Update(ConductorBusRepository entity)
        {
            throw new NotImplementedException();
        }
    }
}
