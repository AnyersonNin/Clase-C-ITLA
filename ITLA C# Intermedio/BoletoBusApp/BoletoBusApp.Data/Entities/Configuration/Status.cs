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
    [Table("Status", Schema = "Configuration")]
    public sealed class Status : BaseEntity<short>
    {
        [Key]
        [Column("StatusId")]
        public override short Id {  get; set; }
        public string? Description { get; set; }
    }
}
