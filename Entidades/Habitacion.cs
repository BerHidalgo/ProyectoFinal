using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Habitacion
    {
        public string nombre;
        public int probabilidad; 
        public bool cofre;
        public bool habitacionJefe;

        //Metodo Cosntructor
        public Habitacion(string pnombre,int pprobabilidad, bool pcofre, bool habitacionJefe)
        {
            nombre = pnombre;
            probabilidad = pprobabilidad;
            cofre = pcofre;
            this.habitacionJefe = habitacionJefe;
        }
    }
}
