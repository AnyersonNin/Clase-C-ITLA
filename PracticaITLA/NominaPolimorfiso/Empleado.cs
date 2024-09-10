using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NominaPolimorfismo
{
    public abstract class Empleado
    {
      private string Nombre { get; set; }
      private string Apellido1 { get; set; }
      private string NSS { get; set; }

      public abstract decimal Calcular();

        public Empleado(string nombre, string apellido, string nss)
        {
            Nombre = nombre;
            Apellido1 = apellido;
            NSS = nss;
        } 
        public string nombre
        {
            get
            {
                return nombre;
            } 
        } 
        public string apellido
        {
            get
            {
                return apellido;
            } 
        } 
       
        public string nss
        {
            get
            {
                return nss;
            } 
        } 

        public override string ToString()
        {
            return string.Format("{0} {1}\nnúmero de seguro social: {2}",
           Nombre, Apellido1,NSS);
        } 

        public abstract decimal Ingresos(); 


    } 

}

