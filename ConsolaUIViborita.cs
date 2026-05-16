using System;
using System.Linq;

namespace Ahorcado
{
    public class ConsolaUIViborita
    {
        private readonly MotorViborita _motor;

        public ConsolaUIViborita(MotorViborita motor)
        {
            _motor = motor;
        }

        public void MostrarTablero()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            DibujarTitulo();
            DibujarHUD();
            DibujarMapa();
            DibujarControles();
        }

        private void DibujarTitulo()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("======================================");
            Console.WriteLine("            JUEGO VIBORITA            ");
            Console.WriteLine("======================================");

            Console.ResetColor();
        }

        private void DibujarHUD()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" PUNTOS: {_motor.Puntos}");
            Console.ResetColor();

            Console.WriteLine();
        }

        private void DibujarMapa()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("#" + new string('#', _motor.Ancho) + "#");
            Console.ResetColor();

            for (int y = 0; y < _motor.Alto; y++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("#");
                Console.ResetColor();

                for (int x = 0; x < _motor.Ancho; x++)
                {
                    var pos = (x, y);

                    if (_motor.Cuerpo.First() == pos)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("@"); // cabeza
                    }
                    else if (_motor.Cuerpo.Contains(pos))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("O"); // cuerpo
                    }
                    else if (_motor.Comida == pos)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("*"); // comida
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("#");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("#" + new string('#', _motor.Ancho) + "#");
            Console.ResetColor();
        }

        private void DibujarControles()
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" CONTROLES:");
            Console.WriteLine(" Flechas -> mover");
            Console.WriteLine(" Q -> salir");
            Console.ResetColor();
        }

        public ConsoleKey LeerTecla()
        {
            if (Console.KeyAvailable)
                return Console.ReadKey(intercept: true).Key;

            return ConsoleKey.NoName;
        }

        public void MostrarMensaje(string mensaje)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($">>> {mensaje}");
            Console.ResetColor();
        }
    }
}