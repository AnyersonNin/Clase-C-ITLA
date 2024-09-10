using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NominaPolimorfismo
{
    public class EmpleadoPorHoras : Empleado
    {
        private decimal sueldo { get; set; }
        private decimal horas { get; set; }
        public override decimal Calcular()
        {
            decimal pago = 0;
            decimal porcentaje = 1.5m;
            decimal horasPordefecto = 40;

            if (this.horas <= horasPordefecto)
            {
                pago = this.sueldo * this.horas;
            }
            else if (this.horas > horasPordefecto)
            {
                pago = horasPordefecto * this.sueldo + (this.horas - horasPordefecto) * this.sueldo * porcentaje;

            }
            return pago;
        }

        public EmpleadoPorHoras(string nombre, string apellido, string nss,
                                decimal sueldoPorHoras, decimal horasTrabajadas)
                                 : base(nombre, apellido, nss)

        {
            Sueldo = sueldoPorHoras;
            Horas = horasTrabajadas;
        }


        public decimal Sueldo
        {
            get
            {
                return sueldo;
            } 
            set
            {
                sueldo = (value >= 0) ? value : 0; 
            } 
        } 

        public decimal Horas
        {
            get
            {
                return horas;
            }
            set
            {
                horas = ((value >= 0) && (value <= 168)) ? value : 0;
            }
        }
        public override decimal Ingresos()
        {
            if (horas <= 40)
                return Sueldo * horas;
             else
                return (40 * Sueldo) + ((horas - 40) * Sueldo * 1.5M);
        } 

    public override string ToString()
    {
      return string.Format(
      "empleado por horas: {0}\n{1}: {2:C}; {3}: {4:F2}",
       base.ToString(), "sueldo por horas", Sueldo, "horas trabajadas", Horas );
     } 
    }
}

