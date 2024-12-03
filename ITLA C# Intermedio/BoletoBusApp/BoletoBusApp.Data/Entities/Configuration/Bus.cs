using BoletoBusApp.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BoletoBusApp.Data.Entities.Configuration
{
    [Table("Bus", Schema = "Configuration")]
    public sealed class Bus : AuditEntity<int>
    {
      [Key]
      [Column("IdBus")]
      public override int Id { get; set; }
      public int IdBus { get; set; }
      public string NumeroPlaca { get; set; }
      public string Nombre {get; set; }
      public int CapacidadPiso1 { get; set; }
      public int CapacidadPiso2 { get; set; }
      public bool Disponible { get; set; }
      
    }
}
