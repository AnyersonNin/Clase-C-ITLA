using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBusApp.Data.Base
{
    /// <summary>
    /// Entidad para manejar la auditoria de las entidades.
    /// </summary>
    /// <typeparam name="TType">Tipo de dato de la tabla</typeparam>
    public abstract class AuditEntity <TType> : BaseEntity<TType>
    {
     public override TType? Id { get; set; }
     public DateTime CreationDate { get; set; }
     public string CreationUser { get; set; }
     public DateTime ModifyDate { get; set; }
     public int UserMod { get; set; }
     public string UserDeletd { get; set; }
     public DateTime DeletedDate { get; set; }
     public bool Deleted {get; set; }
     public bool Estatus { get; set; }
    }
}
