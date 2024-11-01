using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NominaPolimorfismo
{
    public class EmpleadoAsalariado: Empleado
    {
     private decimal salarioSemanal {  get; set; }

     public override decimal Calcular() => this.salarioSemanal;

        public EmpleadoAsalariado(string nombre, string apellido, string nss,
        decimal salario) : base(nombre, apellido, nss)
        {
          SalarioSemanal = salario; 
        } 


    public decimal SalarioSemanal
     {
        get
        {
           return salarioSemanal;
        } 
        set
        {
           salarioSemanal = ( ( value >= 0 ) ? value : 0 ); 
        } 
    } 

    public override decimal Ingresos()
    {
      return SalarioSemanal;
    } 


    public override string ToString()
    {
      return string.Format("empleado asalariado: {0}\n{1}: {2:C}",
      base.ToString(), "salario semanal", SalarioSemanal);
    } 
       
      

    }
}
