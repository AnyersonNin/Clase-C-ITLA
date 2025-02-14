using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class EvaluacionContext
    {
        private IEstatus _estatus;

        public enum Comportamiento
        {
            Aprobada, Pendiente, Reprobada
        }

        public EvaluacionContext()
        {
            this._estatus = new TareaPendiente();
        }
        //public void evaluarTareaAprovada()
        //{
        //    this._estatus = new TareaAprobada();
        //}
        //public void evaluarTareaPendiente() 
        //{ 
        //  this._estatus = new TareaPendiente();
        //}
        //public void evaluarTareaReprobada()
        //{
        // this._estatus = new TareaReprobada();
        //}
        public void evaluar(Comportamiento comportamiento)
        {
            switch (comportamiento)
            {
                case Comportamiento.Aprobada:
                {
                 this._estatus = new TareaAprobada();
                }break;

                case Comportamiento.Pendiente:
                {
                  this._estatus = new TareaPendiente();
                } break;

                case Comportamiento.Reprobada:
                {
                 this._estatus = new TareaReprobada();
                }break;
            }

            this._estatus.notas();
        }
    }
}
