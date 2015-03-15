using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace R8E1
{
    class Program
    {
        static void Main(string[] args)
        {
            String fileURI = @"C:/basura/basura1/basura2/basura3/texto.txt";

            String extension = Path.GetExtension(fileURI);
            String name = Path.GetFileName(fileURI);
            String nameWithoutExtension = Path.GetFileNameWithoutExtension(fileURI);
            String directoryPath = Path.GetDirectoryName(fileURI);
            String fileRoot = Path.GetPathRoot(fileURI);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n                         Información de Fichero\n");
            Console.ResetColor();

            Console.WriteLine("           Ruta y fichero de origen: {0}", fileURI);
            Console.WriteLine("                          Extensión: {0}", extension);
            Console.WriteLine("         Nombre completo de fichero: {0}", name);
            Console.WriteLine("   Nombre del fichero sin extensión: {0}", nameWithoutExtension);
            Console.WriteLine("       Nombre y ruta del directorio: {0}", directoryPath);
            Console.WriteLine("            Unidad/raíz del fichero: {0}", fileRoot);

            Console.WriteLine("\nPulse enter para salir...");
            Console.ReadLine();
        }
    }
}