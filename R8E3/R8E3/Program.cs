using System;
using System.IO;

namespace R8E3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Error: Tiene que indicar dos rutas de ficheros");
                Help();
                return;
            }
            try
            {
                Clonar(args[0], args[1]);
            }
            catch (FileNotFoundException err)
            {
                Console.WriteLine("Error: No se pudo encontrar el fichero " + err.FileName);
            }
            catch
            {
                Console.WriteLine("Error: Sucedió un error inesperado, compruebe los argumentos");
                Help();
            }
        }

        static void Help()
        {
            Console.Write("Uso: Ejercicio3.exe <fichero1> <fichero2>");
        }

        static void Clonar(string path1, string path2)
        {
            FileStream f1, f2;
            f1 = File.Open(path1, FileMode.Open, FileAccess.Read, FileShare.None);
            f2 = File.Open(path2, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

            int b;
            b = f1.ReadByte();
            while (b != -1)
            {
                f2.WriteByte((byte)b);
                b = f1.ReadByte();
            }

            f1.Close();
            f2.Close();
        }
    }
}