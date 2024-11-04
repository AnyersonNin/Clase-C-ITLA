using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicarSOLID.Entities;

namespace AplicarSOLID.Repository.RepoStudent
{
    public interface IStudent
    {
        void Save(Student student);
        void Delete(Student student);
    }
}
