using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBusApp.Data.Models
{
    public class AsientoBusModel
    {
        public int AsientoId { get; set; }
        public int BusId { get; set; }
        public string? Bus { get; set; }
        public int NumeroPiso { get; set; }
        public int NumeroAsiento { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string UserMod { get; set; }
    }
}
