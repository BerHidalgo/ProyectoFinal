using System.Security.Cryptography.X509Certificates;
using LogicadelJuego;

namespace MarcAdventure
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int seleccionDelUsuario = 0;

            //Gameloop 
            while (seleccionDelUsuario != 4)
            {
                //Despliega la portada del juego
                MostrarPortada();

                //Desplegamos la lista de opciones, cada opcion es numerada
                MostrarOpciones();

                //Se captura la decision del usuario

                seleccionDelUsuario = CapturarNumero();

                //Si la persona escribio 1

                if (seleccionDelUsuario == 1)
                {
                    Console.WriteLine("Ha escogido iniciar el juego");
                    Console.ReadLine();
                    IniciarJuego();

                }

                else if (seleccionDelUsuario == 2)
                {
                    Console.WriteLine("Ha escogido instrucciones");
                    Console.ReadLine();
                    MostrarInstrucciones();

                }
                else if (seleccionDelUsuario == 3)
                {
                    Console.WriteLine("Ha escogido Creditos");
                    Console.ReadLine();
                    MostrarCreditos();

                }
                else if (seleccionDelUsuario == 4)
                {
                    Console.WriteLine("Ha escogido Salir");
                    Console.ReadLine();

                }
            }
        
        }

        static public void MostrarPortada()
        {
            Console.Clear();
            Console.WriteLine("Marc's Adventure");

        }

        static public void MostrarInstrucciones()
        {
            Console.Clear();
            Console.WriteLine("Instrucciones");
            Console.ReadLine();

        }

        static public void MostrarCreditos()
        {
            Console.WriteLine("Creditos");
            Console.ReadLine();

        }
        
        //Funcion que arranca el juego
        static public void IniciarJuego()
        {
            int respuestaDelJugador;

            Juego juegoActual = new Juego();

            Console.WriteLine("Marc es un aventurero que investiga masmorras.");
            Console.WriteLine("En busca de tesoros para pagar los estudios de su hermana");
            Console.WriteLine("Pero un dia se quedo atrapado en una masmorra y ahora no puede salir");
            Console.WriteLine("Pero tu puedes ayudarlo a salir");
            Console.ReadLine();
            Console.Clear();

            respuestaDelJugador = CapturarNumero();
            juegoActual.RespuestaJugador(respuestaDelJugador);
            //Primera Habitacion
            Console.WriteLine("Marc esta una habitacion con una sola puerta al final");
            Console.WriteLine("Marc se pregunta si deberia de abrir la puerta");
            Console.WriteLine("Que decides?");
            Console.WriteLine("1- Avanzar");
            Console.WriteLine("2- No hacer nada");
            while (respuestaDelJugador != 1)
            {
                respuestaDelJugador = CapturarNumero();
                juegoActual.RespuestaJugador(respuestaDelJugador);

                if (respuestaDelJugador == 1)
                {
                    Console.WriteLine("Marc decide avanzar. Al abir la puerte se ve una habitacion con un enemigo");
                    Console.WriteLine("Sin ningun lugar para correr empieza el combate");
                    juegoActual.ObtenerEnemigoActual();
                }
                else if (respuestaDelJugador == 2)
                {
                    Console.WriteLine("Marc decide no avanzar.");
                    Console.WriteLine(".....");
                    Console.WriteLine("Pasan horas y no pasa nada.");
                    Console.WriteLine(".....");
                }
                
                    
                
            }

            // OBTENER SOLO EL NOMBRE

            Console.WriteLine("Marc esta en {0}", juegoActual.ObtenerHabitacionActual());
            juegoActual.Combate();
                //Avanzar o Investigar.
                Console.WriteLine("Enemigo derrotado. Hay una puerta al final de la sala.");
            Console.WriteLine("Podrias avanzar a la siguiente habitacion o investigar para encontrar tesoros.");
            Console.WriteLine("1- Avanzar");
            Console.WriteLine("2- Investigar");
            if(juegoActual.PostCombate() == 1)
            {
                Console.WriteLine("Has decidido avanzar.");
            }
            else if (juegoActual.PostCombate() == 2)
            {
                Console.WriteLine("Has decidido Investigar");
                if (juegoActual.InspeccionarHabitacion() == true)
                {
                    Console.WriteLine("Felicidades has encontrado un cofre");
                }

            }
            else if (juegoActual.PostCombate() == 0)
            {
                Console.WriteLine("Error.");
                Console.WriteLine("Por favor seleccione un valor entre 1 y 2");
            }
        }

        //Funcion que captura lo que escribe el usuario.
        //Si hay un error regresa un -1.
        static public int CapturarNumero()
        {
            try
            {
                string textoEscritoPorElUsuario;
                textoEscritoPorElUsuario = Console.ReadLine();
                return int.Parse(textoEscritoPorElUsuario);
            }
            catch
            {
                Console.WriteLine("Error al escribir un numero!");
                Console.WriteLine("Solo se aceptan numeros");
                return -1;
            }
        }
        //Imprime en la pantalla las opciones que el usuario tiene.
        static public void MostrarOpciones()
        {
            Console.WriteLine("1 - Iniciar Juego");
            Console.WriteLine("2 - Instrucciones");
            Console.WriteLine("3 - Creditos");
            Console.WriteLine("4 - Salir");
            Console.Write("Digite su seleccion: ");
        }
    }
}


