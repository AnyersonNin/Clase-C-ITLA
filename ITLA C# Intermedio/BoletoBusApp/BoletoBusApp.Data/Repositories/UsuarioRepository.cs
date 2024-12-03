using BoletoBusApp.Data.Base;
using BoletoBusApp.Data.Entities.Security;
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
    public class UsuarioRepository : IBaseRepository<Usuario, int, UsuarioModel>
    {
        public Task<bool> Exists(Expression<Func<Usuario, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<UsuarioModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<UsuarioModel>>> GetAll(Expression<Func<Usuario, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UsuarioModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UsuarioModel>> Remove(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UsuarioModel>> Save(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UsuarioModel>> Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
