using System;

namespace Sprint_2
{
    class Program
    {
        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===============================================");
                Console.WriteLine("     BIENVENIDO A LA GESTIÓN DE USUARIOS       ");
                Console.WriteLine("                 RIWI CORE 2025                ");
                Console.WriteLine("===============================================\n");
                Console.ResetColor();

                Console.WriteLine("Selecciona una opción:\n");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  1. Módulo de Consulta");
                Console.WriteLine("  2. Módulo de Eliminación");
                Console.WriteLine("  3. Módulo de Actualización");
                Console.WriteLine("  4. Módulo de Inserción\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  Presiona 's' para salir");
                Console.ResetColor();

                Console.Write("\n👉 Opción: ");
                char option = Console.ReadKey(true).KeyChar;

                Console.Clear();
                switch (option)
                {
                    case '1':
                        Console.WriteLine("🔎 Entrando al módulo de consulta...");
                        break;
                    case '2':
                        Console.WriteLine("🗑 Entrando al módulo de eliminación...");
                        break;
                    case '3':
                        Console.WriteLine("✏ Entrando al módulo de actualización...");
                        break;
                    case '4':
                        Console.WriteLine("➕ Entrando al módulo de inserción...");
                        break;
                    case 's':
                    case 'S':
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("¡Gracias por usar el sistema! 👋");
                        Console.WriteLine("Saliendo del programa...");
                        Console.ResetColor();
                        exit = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("⚠ Opción no válida, intenta de nuevo...");
                        Console.ResetColor();
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey(true);
                }
            }
        }
    }
}
