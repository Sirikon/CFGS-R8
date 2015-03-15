using System;
using System.IO;

namespace R8E9
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(String filePath in args)
            {
                MostrarFichero(filePath);
            }
            HLine();
            Console.WriteLine("\nPulse enter para salir...");
            Console.ReadLine();
        }

        static void HLine()
        {
            Console.Write("\n".PadRight(Console.WindowWidth+1, '='));
        }

        static void MostrarFichero(String filePath)
        {
            HLine();
            Console.WriteLine("Mostrando el fichero {0}\n", filePath);
            String textcontent = "";
            try
            {
                FileInfo fi = new FileInfo(filePath);
                if(!fi.Exists)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: El archivo no existe");
                    Console.ResetColor();
                    return;
                }
                textcontent = File.ReadAllText(filePath);
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Error inesperado leyendo el fichero");
                Console.ResetColor();
                return;
            }

            Console.WriteLine(textcontent);
        }
    }
}
