using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    public class Jugador
    {
        //Propiedades
        public int vida;
        public int ataque;
        public int defensa;
        public int pociones;

        //Metodo constructor
        public Jugador()
        {
            vida = 50;
            ataque = 5;
            defensa = 2;
            pociones = 3;

        }
    }
}
