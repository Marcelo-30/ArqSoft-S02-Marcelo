using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado
{
    public class ConsolaUI
    {
        private readonly MotorAhorcado _motor;

        public ConsolaUI(MotorAhorcado motor)
        {
            _motor = motor;
        }

        public void MostrarTablero()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║        JUEGO AHORCADO        ║");
            Console.WriteLine("╚══════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine();

            MostrarAhorcado();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Intentos restantes: {_motor.IntentosRestantes}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Letras usadas: {string.Join(", ", _motor.LetrasUsadas)}");
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Palabra: ");
            Console.ResetColor();

            foreach (char c in _motor.PalabraSecreta)
            {
                if (_motor.LetrasUsadas.Contains(c))
                    Console.Write($" {c} ");
                else
                    Console.Write(" _ ");
            }

            Console.WriteLine();
        }

        public char PedirLetra()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nIngresa una letra: ");
            Console.ResetColor();

            string? entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada))
                return ' ';

            return entrada.ToLower()[0];
        }

        public void MostrarMensaje(string mensaje)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"» {mensaje}");
            Console.ResetColor();
        }

        public bool PreguntarOtraVez()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            Console.ResetColor();

            return Console.ReadLine()?.ToLower() == "s";
        }

        private void MostrarAhorcado()
        {
            string[] etapas = new string[]
            {
@"  +---+
  |   |
      |
      |
      |
      |
=========",

@"  +---+
  |   |
  O   |
      |
      |
      |
=========",

@"  +---+
  |   |
  O   |
  |   |
      |
      |
=========",

@"  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",

@"  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",

@"  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",

@"  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
========="
            };

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(etapas[6 - _motor.IntentosRestantes]);
            Console.ResetColor();
        }
    }
}