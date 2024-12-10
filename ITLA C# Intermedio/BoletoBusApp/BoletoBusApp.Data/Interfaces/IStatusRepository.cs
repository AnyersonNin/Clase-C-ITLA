using BoletoBusApp.Data.Models;
using BoletoBusApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBusApp.Data.Interfaces
{
    public interface IStatusRepository : IBaseRepository<StatusRepository,short,StatusModel>
    {
    }
}
