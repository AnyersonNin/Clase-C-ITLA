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
    public sealed class StatusRepository : IStatusRepository
    {
        private readonly ILogger _logger;
        private readonly BoletoContext _context;
        public StatusRepository(BoletoContext boletoContext, ILogger<StatusRepository> logger)
        {
            _context = boletoContext;
            _logger = logger;
        }

        public Task<bool> Exists(Expression<Func<StatusRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<StatusModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<StatusModel>>> GetAll(Expression<Func<StatusRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<StatusModel>> GetEntityBy(short id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<StatusModel>> Remove(StatusRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<StatusModel>> Save(StatusRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<StatusModel>> Update(StatusRepository entity)
        {
            throw new NotImplementedException();
        }
    }


}
