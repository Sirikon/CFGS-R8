using System;
using System.IO;

namespace R8E6
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 2)
            {
                WrongNumberOfArguments();
                return;
            }

            if (args[1].Length != 1)
            {
                SecondArgumentNotChar();
                return;
            }

            String filePath = args[0];
            Char character = args[1][0];

            FileInfo fi = new FileInfo(filePath);
            if(!fi.Exists)
            {
                FileNotExists();
                return;
            }

            try
            {
                CountCharInFile(filePath, character);
            }
            catch(Exception e)
            {
                UnexpectedError();
            }
        }

        static void WrongNumberOfArguments()
        {
            Console.WriteLine("Numero incorrecto de argumentos");
            Help();
        }

        static void SecondArgumentNotChar()
        {
            Console.WriteLine("El segundo argumento tiene que ser un único carácter");
            Help();
        }

        static void FileNotExists()
        {
            Console.WriteLine("El fichero especificado no existe");
            EnterToExit();
        }

        static void UnexpectedError()
        {
            Console.WriteLine("Hubo un error inesperado");
            EnterToExit();
        }

        static void Help()
        {
            Console.WriteLine("\nUso: Ejercicio6.exe <fichero> <caracter>");
            EnterToExit();
        }

        static void EnterToExit()
        {
            Console.WriteLine("\nPulsa enter para salir...");
            Console.ReadLine();
        }

        static void CountCharInFile(String filePath, Char character)
        {
            Int32 count = 0;
            FileStream file;
            file = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None);

            int b;
            b = file.ReadByte();
            while (b != -1)
            {
                if (character == b)
                {
                    count++;
                }
                b = file.ReadByte();
            }

            file.Close();

            Console.WriteLine("En el fichero '{0}' el caracter '{1}' aparece {2} veces", filePath, character, count);
        }
    }
}
