using System;
using System.IO;

namespace R8E6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Contador de caracteres en fichero");
            Console.Write("Ruta del fichero: ");
            String filePath = Console.ReadLine();

            Console.Write("Caracter a contar: ");
            String characterLine = Console.ReadLine();

            if (characterLine.Length != 1)
            {
                SecondArgumentNotChar();
                return;
            }

            Char character = characterLine[0];

            try
            {
                FileInfo fi = new FileInfo(filePath);
                if (!fi.Exists)
                {
                    FileNotExists();
                    return;
                }
                CountCharInFile(filePath, character);
            }
            catch(ArgumentException ae)
            {
                FileNotExists();
            }
            catch(Exception e)
            {
                UnexpectedError();
            }
        }

        static void SecondArgumentNotChar()
        {
            Console.WriteLine("El segundo argumento tiene que ser un único carácter");
            EnterToExit();
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
            EnterToExit();
        }
    }
}
