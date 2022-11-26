using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace LogicadelJuego
{
    public class Juego
    {
        //Propiedades
        private Habitacion[] masmorra;
        private int numeroDeHabitacion;
        private Jugador marcjugador;
        private Enemigo[] enemigos;
        private Enemigo[] jefes;

        //Hacer Metodo Contructor
        public Juego()
        {
            //
            this.masmorra = new Habitacion[8];
            marcjugador = new Jugador();
            enemigos = new Enemigo[20];
            jefes = new Enemigo[3];

        }

        //Crear indice para saber con cual enemigo/jefe estoy peleando.
        //Crear indice para saber habitacion actual. Resetear indice si perdi
        //Aumentar el indice de la habitaciones cuando avanzo.

        //JUGADOR
        //Inspeccionar Habitacion
        //Siguiente Habitacion
        //Atacar Enemigo
        //Concentracion del Jugador
        //Agilidad del Jugador
        //Curar vida del Juagador
        //Recibir Daño por parte del enemigo
        //El jugador sigue vivo?

        //ENEMIGO
        //Atacar al jugador
        //Recibir Daño por parte del jugador
        //El enemigo sigue vivo?
        //Crear enemigo.

        //HABITACION
        //Calcular si es una habitacion de cofres.
        //Calcular si hay cofre.

        //Avanzar de Habitacion.
        public void ProgresarHabitaciones()
        {
            numeroDeHabitacion += 1;

        }
        public void PerderJuego()
        {
            numeroDeHabitacion = 0;

        }

        //Cargar datos
        public void CargarDatosHabitacion()
        {
            masmorra[0] = new Habitacion("Piso 1 Habitacion 1", 5, false);
            masmorra[1] = new Habitacion("Piso 1 Habitacion 2", 5, true);
            masmorra[2] = new Habitacion("Piso 1 Habitacion 3", 5, false);
            masmorra[3] = new Habitacion("Piso 2 Habitacion 1", 5, false);
            masmorra[4] = new Habitacion("Piso 2 Habitacion 2", 5, true);
            masmorra[5] = new Habitacion("Piso 2 Habitacion 3", 5, false);
            masmorra[6] = new Habitacion("Piso 3 Habitacion 1", 5, false);
            masmorra[7] = new Habitacion("Piso 3 Habitacion 2", 5, true);
            masmorra[8] = new Habitacion("Piso 3 Habitacion 3", 5, false);
            
           
        }
        

    }
}
