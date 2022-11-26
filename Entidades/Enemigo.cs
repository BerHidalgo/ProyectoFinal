using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Enemigo
    {
        public string nombreEnemigo;
        public int vidaEnemigo;
        public int ataqueEnemigo;
        public bool jefe;

        public Enemigo(string pnombreEnemigo,int pvidaEnemigo,int pataqueEnemigo,bool pjefe)
        {
            nombreEnemigo = pnombreEnemigo;
           vidaEnemigo = pvidaEnemigo;
           ataqueEnemigo = pataqueEnemigo;
           jefe = pjefe;

        }

    }
}
