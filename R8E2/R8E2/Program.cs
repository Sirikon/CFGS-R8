using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace R8E2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca la ruta de un directorio para obtener su información");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("> ");
            Console.ResetColor();
            ShowDirectoryInfo(Console.ReadLine());
            Console.WriteLine("\nPulse enter para salir...");
            Console.ReadLine();
        }

        static void ShowDirectoryInfo(String dirPath)
        {
            Console.Clear();

            DirectoryInfo di = new DirectoryInfo(dirPath);

            try
            {
                PrintLine("Directorio Padre    ", di.Parent.Name);
                PrintLine("Directorio Raíz     ", di.Root.FullName);
                PrintLine("Nombre Completo     ", di.FullName);
                PrintLine("Existe Directorio   ", di.Exists.ToString());
                PrintLine("Último acceso       ", di.LastAccessTime.ToString());
                PrintLine("Fecha Creación      ", di.CreationTime.ToString());
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Hubo un error inesperado, cerrando...");
                Console.ResetColor();
            }
            
        }

        static void PrintLine(String key, String val)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(key);
            Console.ResetColor();
            Console.WriteLine(" : " + val);
        }
    }
}
