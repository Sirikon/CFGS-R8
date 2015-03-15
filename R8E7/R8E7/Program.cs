using System;
using System.Text;
using System.IO;

namespace R8E7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Concatenar ficheros de texto");
            Console.WriteLine("Pásame dos ficheros y al final del primero añadiré el segundo");
            Console.Write("Fichero 1: ");
            String filePath1 = Console.ReadLine();
            Console.Write("Fichero 2: ");
            String filePath2 = Console.ReadLine();
            
            try
            {
                FileInfo fi1 = new FileInfo(filePath1);
                FileInfo fi2 = new FileInfo(filePath2);
                if(!fi1.Exists)
                {
                    FileNotExists(filePath1);
                    return;
                }
                if(!fi2.Exists)
                {
                    FileNotExists(filePath2);
                    return;
                }
            }
            catch(Exception e)
            {
                UnexpectedError();
                return;
            }

            try
            {
                ConcatenaFicheros(filePath1, filePath2);
            }
            catch(Exception e)
            {
                UnexpectedError();
            }
        }

        static void FileNotExists(String filename)
        {
            Console.WriteLine("El fichero '{0}' no existe", filename);
            EnterToExit();
        }

        static void UnexpectedError()
        {
            Console.WriteLine("Sucedió un error inesperado");
            EnterToExit();
        }

        static void EnterToExit()
        {
            Console.WriteLine("Pulse enter para salir...");
            Console.ReadLine();
        }

        static void ConcatenaFicheros(String filePath1, String filePath2)
        {
            StringBuilder result = new StringBuilder();
            FileStream f1, f2;
            f1 = File.Open(filePath1, FileMode.Open, FileAccess.Write, FileShare.None);
            f2 = File.Open(filePath2, FileMode.Open, FileAccess.Read, FileShare.None);

            f1.Position = f1.Length;
            int b;
            b = f2.ReadByte();
            while (b != -1)
            {
                f1.WriteByte((byte)b);
                b = f2.ReadByte();
            }
            f1.Close();
            f2.Close();

            Console.WriteLine("\nHecho!\n");
            EnterToExit();
        }
    }
}
