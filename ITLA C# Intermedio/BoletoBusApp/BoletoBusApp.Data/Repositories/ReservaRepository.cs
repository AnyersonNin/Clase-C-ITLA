﻿using BoletoBusApp.Data.Base;
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
    public class ReservaRepository : IReservaRepository
    {
        private readonly ILogger _logger;
        private readonly BoletoContext _context;

        public ReservaRepository(BoletoContext boletoContext, ILogger<ReservaRepository> logger)
        {
            _context = boletoContext;
            _logger = logger;
        }

        public Task<bool> Exists(Expression<Func<ReservaRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ReservaModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<ReservaModel>>> GetAll(Expression<Func<ReservaRepository, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaModel>> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaModel>> Remove(ReservaRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaModel>> Save(ReservaRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaModel>> Update(ReservaRepository entity)
        {
            throw new NotImplementedException();
        }
    }
}