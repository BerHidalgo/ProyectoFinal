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
        public int evasionEnemigo;

        public Enemigo(string pnombreEnemigo,int pvidaEnemigo,int pataqueEnemigo,bool pjefe,int pevasionEnemigo)
        {
           nombreEnemigo = pnombreEnemigo;
           vidaEnemigo = pvidaEnemigo;
           ataqueEnemigo = pataqueEnemigo;
           jefe = pjefe;
           evasionEnemigo = pevasionEnemigo;   

        }

    }
}
