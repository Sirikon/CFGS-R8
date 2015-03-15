using System;
using System.IO;

namespace R8E5
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                WrongNumberOfArgumentsView();
                return;
            }

            String filePath = args[0];

            FileInfo fi = new FileInfo(filePath);
            if (!fi.Exists)
            {
                FileDoesNotExistView();
                return;
            }

            try
            {
                ShowFileContent(args[0]);
            }
            catch
            {
                UnexpectedErrorView();
            }
        }

        static void Help()
        {
            Console.WriteLine("Uso: Ejercicio5.exe <fichero>");
        }

        static void WrongNumberOfArgumentsView()
        {
            Console.WriteLine("El número de argumentos no es el correcto");
            Help();
            EnterToExit();
        }

        static void FileDoesNotExistView()
        {
            Console.WriteLine("El fichero especificado no existe");
            EnterToExit();
        }

        static void UnexpectedErrorView()
        {
            Console.WriteLine("ERROR: Sucedió un error inesperado");
            EnterToExit();
        }

        static void EnterToExit()
        {
            Console.WriteLine("\nPulse enter para salir");
            Console.ReadLine();
        }

        static void ShowFileContent(String filePath)
        {
            String textcontent = File.ReadAllText(filePath, System.Text.Encoding.UTF8);
            Console.WriteLine(textcontent);
            EnterToExit();
        }
    }
}
