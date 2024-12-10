using BoletoBusApp.Data.Base;
using BoletoBusApp.Data.Context;
using BoletoBusApp.Data.Entities.Security;
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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ILogger _logger;
        private readonly BoletoContext _context;
        public UsuarioRepository(BoletoContext boletoContext, ILogger<UsuarioRepository> logger)
        {
            _context = boletoContext;
            _logger = logger;
        }

        public Task<bool> Exists(Expression<Func<UsuarioRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<UsuarioModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<UsuarioModel>>> GetAll(Expression<Func<UsuarioRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UsuarioModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UsuarioModel>> Remove(UsuarioRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UsuarioModel>> Save(UsuarioRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UsuarioModel>> Update(UsuarioRepository entity)
        {
            throw new NotImplementedException();
        }
    }
}
