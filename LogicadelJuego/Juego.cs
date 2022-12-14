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
        private int numeroJefe;
        private Jugador marcjugador;
        private Enemigo[] enemigos;
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
            enemigos = new Enemigo[21];
            
            CargarDatosHabitacion();
            CargarDatosEnemigos();
             

        }

        
        
        //Aumentar el indice de la habitaciones cuando avanzo.

        //JUGADOR
        //Control del Jugador
        public void RespuestaJugador(int parametro)
        {
            decisionDelUsuario = parametro;

        }
        //Opciones despues del combate
        


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

        public void ElegirTesoro()
        {
            Console.WriteLine("Dentro del cofre se encuentran 3 objetos. Pero solo te puedes lelvar uno");
            Console.WriteLine("1-Anillo de Ataque");
            Console.WriteLine("2-Anillo de Defensa");
            Console.WriteLine("3-Una Pocion");
            try
            {
                decisionDelUsuario = int.Parse(Console.ReadLine());
            }
            catch
            {
                decisionDelUsuario = 1;
            }
            if (decisionDelUsuario == 1)
            {
                Console.WriteLine("Haz escogido el Anillo de Ataque");
                Console.WriteLine("El ataque de Marc aumenta +1");
                marcjugador.ataque += 1;
                Console.WriteLine("El ataque de Marc es " + marcjugador.ataque );
                Console.ReadLine();
            }
            else if (decisionDelUsuario == 2)
            {
                Console.WriteLine("Haz escogido el Anillo de Defensa");
                Console.WriteLine("La defensa de Marc aumenta +1");
                marcjugador.defensa += 1;
                Console.WriteLine("La defensa de Marc es " + marcjugador.defensa );
                Console.ReadLine();
            }
            else if (decisionDelUsuario == 3)
            {
                Console.WriteLine("Haz escogido una pocion");
                Console.WriteLine("La pociones de Marc aumentan +1");
                marcjugador.pociones += 1;
                Console.WriteLine("Marc tiene " +marcjugador.pociones + " pociones");
                Console.ReadLine();
            }



        }
        //ARREGLAR OBETENERENEMIGO. ENEMIGO SE OBTIENE DEPENDIENDO DEL PISO

        public Enemigo ObtenerEnemigoActual()
        {
            if (masmorra[numeroDeHabitacion].habitacionJefe == true)
            {
                if (numeroDeHabitacion == 2)
                {
                    numeroEnemigo = 18;

                }
                else if (numeroDeHabitacion == 5)
                {
                    numeroEnemigo = 19;
                }
                else if (numeroDeHabitacion == 8)
                {
                    numeroEnemigo = 20;
                }
            }
            else
            {
                if (numeroDeHabitacion < 2)
                {
                    numeroEnemigo = generardorNumeros.Next(0, 6);

                }
                else if (numeroDeHabitacion < 5)
                {
                    numeroEnemigo = generardorNumeros.Next(6, 11);

                }
                else if (numeroDeHabitacion < 8)
                {
                    numeroEnemigo = generardorNumeros.Next(11, 18);

                }
            }
            return enemigos[numeroEnemigo];
        }

        //Combate
        //COMBATE NO LEE LOS INPUTS DEL USUARIO
        public void Combate()
        {
            int damageEnemigo = enemigos[numeroEnemigo].ataqueEnemigo / marcjugador.defensa;
            int damage = marcjugador.ataque;
            bool concentracion = false;
            Console.WriteLine("Has encontrado un " + enemigos[numeroEnemigo].nombreEnemigo);

            while (marcjugador.vida > 0 && enemigos[numeroEnemigo].vidaEnemigo > 0)
            {
                
                Console.WriteLine("Que deberia de hacer Marc");
                Console.WriteLine("1-Atacar");
                Console.WriteLine("2-Concentracion");
                Console.WriteLine("3-Agilidad");
                Console.WriteLine("4-Curarse");
                Console.WriteLine("Pociones: " + marcjugador.pociones); 
                Console.WriteLine("Vida: " + marcjugador.vida);
                Console.WriteLine("Vida Enemigo: " + enemigos[numeroEnemigo].vidaEnemigo);
                try
                {
                    decisionDelUsuario = int.Parse(Console.ReadLine());
                }
                catch
                {
                    decisionDelUsuario = 1;
                }
                
                

                if (decisionDelUsuario == 1)
                {
                    Console.WriteLine("Marc decide atacar");
                    var probabilidadAtaque = generardorNumeros.Next(1,11);
                    if(probabilidadAtaque > enemigos[numeroEnemigo].evasionEnemigo)
                    {
                        if (concentracion == true)
                        {
                            int ataqueConcetracion = damage * 2;
                            enemigos[numeroEnemigo].vidaEnemigo -= ataqueConcetracion;
                            Console.WriteLine("Marc inflinge " + ataqueConcetracion + " al " + enemigos[numeroEnemigo].nombreEnemigo);
                            Console.WriteLine("Vida del " + enemigos[numeroEnemigo].nombreEnemigo + " es " + enemigos[numeroEnemigo].vidaEnemigo);
                            Console.ReadLine();
                            concentracion = false;
                        }
                        else
                        {
                            enemigos[numeroEnemigo].vidaEnemigo -= damage;

                            Console.WriteLine("Marc inflinge " + damage + " al " + enemigos[numeroEnemigo].nombreEnemigo);
                            Console.WriteLine("Vida del " + enemigos[numeroEnemigo].nombreEnemigo + " es " + enemigos[numeroEnemigo].vidaEnemigo);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("El " + enemigos[numeroEnemigo].nombreEnemigo + " ha esquivado el ataque de Marc");
                    }

                    if (enemigos[numeroEnemigo].vidaEnemigo < 0)
                    {
                        break;
                    }
                }
                else if(decisionDelUsuario == 2)
                {
                    Console.WriteLine("Marc empieza a Concentrarse");
                    concentracion = true;
                    Console.ReadLine();
                }
                else if(decisionDelUsuario == 3)
                {
                    Console.WriteLine("Marc aumenta su velocidad");
                    marcjugador.agilidad += 2;
                    Console.ReadLine();

                }
                else if(decisionDelUsuario == 4)
                {
                    Console.WriteLine("Marc decide curarse");
                    if(marcjugador.vida != 50)
                    {
                        marcjugador.pociones -= 1;
                        marcjugador.vida += 10;
                        if (marcjugador.vida > 50)
                        {
                            marcjugador.vida = 50;
                        }
                    }
                    else
                    {
                        Console.Write("La vida de Marc ya esta al maximo");
                        Console.ReadLine();
                    }
                
                    
                }
                
                Console.WriteLine("El " + enemigos[numeroEnemigo].nombreEnemigo + "se prepara para atacar");

                var probabilidadDano = generardorNumeros.Next(1, 11);
                if (probabilidadDano > marcjugador.agilidad)
                {
                    if (damageEnemigo < 0)
                    {
                        damageEnemigo = 1;
                    }
                    else
                    {
                        marcjugador.vida -= damageEnemigo;
                        Console.WriteLine("El " + enemigos[numeroEnemigo].nombreEnemigo + " inflinge " + damageEnemigo + " a Marc");
                        Console.WriteLine("Vida de Marc " + marcjugador.vida);
                        Console.ReadLine();
                        Console.Clear();
                    }
                    
                }
                else
                {
                    Console.WriteLine("Marc logro esquivar el ataque del enemigo.");
                    marcjugador.agilidad = 5;
                    Console.ReadLine();
                    Console.Clear();
                }
               


            }

        }

        public int ObtenerVidaJugador()
        {
            return marcjugador.vida;
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

        public int ObtenerNumeroHabitacion()
        {
            return numeroDeHabitacion;
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
            enemigos[0] = new Enemigo("Goblin Guerrero", 20, 2,false,1);
            enemigos[1] = new Enemigo("Goblin Hechicero", 10, 10, false,1);
            enemigos[2] = new Enemigo("Goblin Ladron", 10, 5, false, 1);
            enemigos[3] = new Enemigo("Goblin Arquero", 5, 5, false, 1);
            enemigos[4] = new Enemigo("Yan", 7, 3, false, 1);
            enemigos[5] = new Enemigo("Rata Grande", 2, 5, false, 1);

            //Enemigos Dificiles
            enemigos[6] = new Enemigo("Zombie Guerrero", 20, 5, false, 3);
            enemigos[7] = new Enemigo("Necromancer", 15, 12, false, 3);
            enemigos[8] = new Enemigo("Esqueleto", 10, 5, false, 3);
            enemigos[9] = new Enemigo("Zombie Arquero", 5, 8, false, 3);
            enemigos[10] = new Enemigo("Slime Grande", 10, 5, false, 3);

            //Enemigos Muy Dificiles
            enemigos[11] = new Enemigo("Bandido Arquero", 5, 10, false, 5);
            enemigos[12] = new Enemigo("Bandido Guerrero", 25, 5, false, 5);
            enemigos[13] = new Enemigo("Bandido Hechicero", 15, 15, false, 5);
            enemigos[14] = new Enemigo("Bandido", 10, 10, false, 5);
            enemigos[15] = new Enemigo("Hombre Lagarto", 30, 8, false, 5);
            enemigos[16] = new Enemigo("Lagarto Hechizero", 20, 15, false, 5);
            enemigos[17] = new Enemigo("Lagarto Arquero", 10, 20, false, 5);
            
            //Jefes
            enemigos[18] = new Enemigo("Mousse el Baboso", 50, 5, true, 3);
            enemigos[19] = new Enemigo("Dednot el Resurrector", 30, 20, true, 5);
            enemigos[20] = new Enemigo("Dis'noot el Apostrofe", 100, 25, true, 1);

        }
    }
}
