using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NominaPolimorfismo
{
    public class EmpleadoPorComision : Empleado

    { 
        private decimal ventasBrutas { get; set; }
        private decimal tarifaDeComision { get; set; }

        public override decimal Calcular() => this.tarifaDeComision * this.ventasBrutas;

       
      public EmpleadoPorComision (string nombre, string apellido, string nss,
       decimal ventas, decimal tarifa) : base(nombre, apellido, nss)
      {
      ventasBrutas = ventas; 
      TarifaComision = tarifa; 
      } 

      public decimal TarifaComision
      {
          get
          {
           return tarifaDeComision;

          } 
         set
         {
                tarifaDeComision = ( value > 0 && value < 1 ) ?
           value : 0; 
         }
        }
      public decimal VentasBrutas
      {
        get
        {
           return ventasBrutas;
        }
        set
        {
              ventasBrutas = (value >= 0 ) ? value : 0;
        } 
      } 

    public override decimal Ingresos()
    {
          return TarifaComision * VentasBrutas;
    }


        public override string ToString()
        {
            return string.Format("{0}: {1}\n{2}: {3:C}\n{4}: {5:F2}",
            "empleado por comisión", base.ToString(),
            "ventas brutas", VentasBrutas, "tarifa de comisión", TarifaComision);
        }
    } 
}

