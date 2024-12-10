using BoletoBusApp.Data.Base;
using BoletoBusApp.Data.Context;
using BoletoBusApp.Data.Entities.Configuration;
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
    public class ConductorRepository : IConductorRepository
    {
        private readonly ILogger _logger;
        private readonly BoletoContext _context;
        public ConductorRepository(BoletoContext boletoContext, ILogger<ConductorRepository> logger)
        {
            _context = boletoContext;
            _logger = logger;
        }

        public Task<bool> Exists(Expression<Func<ConductorRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ConductorModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ConductorModel>>> GetAll(Expression<Func<ConductorRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorModel>> Remove(ConductorRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorModel>> Save(ConductorRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ConductorModel>> Update(ConductorRepository entity)
        {
            throw new NotImplementedException();
        }
    }
}
