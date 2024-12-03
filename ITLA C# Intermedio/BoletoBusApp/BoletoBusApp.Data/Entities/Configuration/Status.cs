using BoletoBusApp.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBusApp.Data.Entities.Configuration
{
    [Table("Status")]
    public sealed class Status : AuditEntity<short>
    {
        [Key]
        [Column("Id")]
        public override short Id {  get; set; }
        public string? Description { get; set; }
    }
}
