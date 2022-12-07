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
        //Crear indice para saber habitacion actual. Resetear indice si perdi
        private int numeroDeHabitacion;
        private int numeroEnemigo;
        private Jugador marcjugador;
        private Enemigo[] enemigos;
        private Enemigo[] jefes;
        private  Random generardorNumeros;
        private int decisionDelUsuario;
        
        //Hacer Metodo Contructor
        public Juego()
        {
            //Incializador.
            generardorNumeros = new Random();
            numeroEnemigo = 0;
            numeroDeHabitacion = 0;
            this.masmorra = new Habitacion[9];
            marcjugador = new Jugador();
            enemigos = new Enemigo[18];
            jefes = new Enemigo[3];
            CargarDatosHabitacion();
            CargarDatosEnemigos();
            CargarDatosJefes(); 

        }

        
        
        //Aumentar el indice de la habitaciones cuando avanzo.

        //JUGADOR
        //Control del Jugador
        public void RespuestaJugador(int parametro)
        {
            decisionDelUsuario = parametro;

        }
        //Opciones despues del combate
        public int PostCombate()
        {

            if (decisionDelUsuario == 1)
            {
                return 1;

            }
            else if (decisionDelUsuario == 2)
            {
                return 2;
            }
            else
            {
                return 0;
            }
                    
        }


        //Inspeccionar Habitacion
        public bool InspeccionarHabitacion()
        {
             
            int posibilidadCofre = generardorNumeros.Next(1, 11);
            if (posibilidadCofre >= masmorra[numeroDeHabitacion].probabilidad)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
        //ARREGLAR OBETENERENEMIGO. ENEMIGO SE OBTIENE DEPENDIENDO DEL PISO
        public Enemigo ObtenerEnemigoActual()
        {
            if (numeroDeHabitacion < 2)
            {
                numeroEnemigo = generardorNumeros.Next(0, 6);
           }
            else if (numeroDeHabitacion < 5)
            {
                numeroEnemigo = generardorNumeros.Next(6, 11);
            }
            else if (numeroDeHabitacion > 6)
            {
                numeroEnemigo = generardorNumeros.Next(11, 18);
            }

            return enemigos[numeroEnemigo];
        }

        //Combate
        //COMBATE NO LEE LOS INPUTS DEL USUARIO
        public void Combate()
        {
            Console.WriteLine("Has encontrado un " + enemigos[numeroEnemigo].nombreEnemigo);
            while (marcjugador.vida > 0 | enemigos[numeroEnemigo].vidaEnemigo > 0)
            {
                
                Console.WriteLine("Que deberia de hacer Marc");
                Console.WriteLine("1-Atacar");
                Console.WriteLine("2-Concentracion");
                Console.WriteLine("3-Agilidad");
                Console.WriteLine("4-Curarse");
                Console.WriteLine("Pociones: " + marcjugador.pociones); 
                Console.WriteLine("Vida: " + marcjugador.vida);
                try
                {
                    decisionDelUsuario = int.Parse(Console.ReadLine());
                }
                catch
                {
                    decisionDelUsuario = 1;
                }
                int damage = marcjugador.ataque;

                if (decisionDelUsuario == 1)
                {
                    Console.WriteLine("Marc decide atacar");
                    enemigos[numeroEnemigo].vidaEnemigo -= damage;

                    Console.WriteLine("Marc inflinge " + damage + " al " + enemigos[numeroEnemigo].nombreEnemigo);
                    Console.WriteLine("Vida del "+ enemigos[numeroEnemigo].nombreEnemigo + " es " + enemigos[numeroEnemigo].vidaEnemigo);
                    Console.ReadLine();

                }
                else if(decisionDelUsuario == 2)
                {
                    Console.WriteLine("Marc empieza a Concentrarse");
                    Console.ReadLine();
                }
                else if(decisionDelUsuario == 3)
                {
                    Console.WriteLine("Marc aumenta su velocidad");
                    Console.ReadLine();
                }
                else if(decisionDelUsuario == 4)
                {
                    Console.WriteLine("Marc decide curarse");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Error");
                    
                }
               
            }

        }
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

        public Habitacion ObtenerHabitacionActual()
        {

            return masmorra[numeroDeHabitacion];
               

        }
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
        //Calcular si es una habitacion de cofres.
        //Calcular si hay cofre.
        //Crear indice para saber con cual enemigo/jefe estoy peleando.
        public void CargarDatosHabitacion()
        {
            masmorra[0] = new Habitacion("Piso 1 Habitacion 1", 5, false,false);
            masmorra[1] = new Habitacion("Piso 1 Habitacion 2", 5, true,false);
            masmorra[2] = new Habitacion("Piso 1 Habitacion 3", 5, false,true);
            masmorra[3] = new Habitacion("Piso 2 Habitacion 1", 5, false, false);
            masmorra[4] = new Habitacion("Piso 2 Habitacion 2", 5, true, false);
            masmorra[5] = new Habitacion("Piso 2 Habitacion 3", 5, false,true);
            masmorra[6] = new Habitacion("Piso 3 Habitacion 1", 5, false, false);
            masmorra[7] = new Habitacion("Piso 3 Habitacion 2", 5, true, false);
            masmorra[8] = new Habitacion("Piso 3 Habitacion 3", 5, false, true);
               
        }
        //Enemigo(string pnombreEnemigo,int pvidaEnemigo,int pataqueEnemigo,bool pjefe)
        //20 Enemigos
        public void CargarDatosEnemigos()
        {
            //Enemigos Faciles
            enemigos[0] = new Enemigo("Goblin Guerrero", 20, 2,false);
            enemigos[1] = new Enemigo("Goblin Hechicero", 10, 10, false);
            enemigos[2] = new Enemigo("Goblin Ladron", 10, 5, false);
            enemigos[3] = new Enemigo("Goblin Arquero", 5, 5, false);
            enemigos[4] = new Enemigo("Slime", 7, 3, false);
            enemigos[5] = new Enemigo("Rata Grande", 2, 5, false);

            //Enemigos Dificiles
            enemigos[6] = new Enemigo("Zombie Guerrero", 20, 5, false);
            enemigos[7] = new Enemigo("Necromancer", 15, 12, false);
            enemigos[8] = new Enemigo("Esqueleto", 10, 5, false);
            enemigos[9] = new Enemigo("Zombie Arquero", 5, 8, false);
            enemigos[10] = new Enemigo("Slime Grande", 10, 5, false);

            //Enemigos Muy Dificiles
            enemigos[11] = new Enemigo("Bandido Arquero", 5, 10, false);
            enemigos[12] = new Enemigo("Bandido Guerrero", 25, 5, false);
            enemigos[13] = new Enemigo("Bandido Hechicero", 15, 15, false);
            enemigos[14] = new Enemigo("Bandido", 10, 10, false);
            enemigos[15] = new Enemigo("Hombre Lagarto", 30, 8, false);
            enemigos[16] = new Enemigo("Lagarto Hechizero", 20, 15, false);
            enemigos[17] = new Enemigo("Lagarto Arquero", 10, 20, false);
            

        }

        public void CargarDatosJefes()
        {
            jefes[0] = new Enemigo("Mousse el Baboso", 50, 5, true);
            jefes[1] = new Enemigo("Dednot el Resurrector", 30, 20, true);
            jefes[2] = new Enemigo("Dis'noot el Apostrofe", 100, 10, true);

        }
    }
}
