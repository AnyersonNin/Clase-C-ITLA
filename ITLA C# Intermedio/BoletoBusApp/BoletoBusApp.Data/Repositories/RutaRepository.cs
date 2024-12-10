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
    public class RutaRepository : IRutaRepository
    {
        private readonly ILogger _logger;
        private readonly BoletoContext _context;

        public RutaRepository(BoletoContext boletoContext, ILogger<RutaRepository> logger)
        {
            _context = boletoContext;
            _logger = logger;
        }

        public Task<bool> Exists(Expression<Func<RutaRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<RutaModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<RutaModel>>> GetAll(Expression<Func<RutaRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RutaModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RutaModel>> Remove(RutaRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RutaModel>> Save(RutaRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RutaModel>> Update(RutaRepository entity)
        {
            throw new NotImplementedException();
        }
    }
}
