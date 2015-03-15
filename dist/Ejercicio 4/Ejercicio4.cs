using System;
using System.IO;

namespace R8E4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Error: Tiene que indicar dos rutas de ficheros y un caracter para eliminar");
                Help();
                return;
            }
            try
            {
                ClonarConFiltro(args[0], args[1], args[2]);
            }
            catch (FileNotFoundException err)
            {
                Console.WriteLine("Error: No se pudo encontrar el fichero " + err.FileName);
            }
            catch (InvalidDataException err)
            {
                Console.WriteLine("Error: El carácter para eliminar en la copia no es válido");
            }
            catch
            {
                Console.WriteLine("Error: Sucedió un error inesperado, compruebe los argumentos");
                Help();
            }
        }

        static void Help()
        {
            Console.WriteLine("Uso: Ejercicio4.exe <fichero1> <fichero2> <caracter>");
        }

        static void ClonarConFiltro(string path1, string path2, string charDelete)
        {
            FileStream f1, f2;
            f1 = File.Open(path1, FileMode.Open, FileAccess.Read, FileShare.None);
            f2 = File.Open(path2, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

            if (charDelete.Length != 1)
            {
                throw new InvalidDataException();
            }

            int separationMayus = (int)'a' - (int)'A';

            char c = charDelete.ToLower()[0];

            int b;
            b = f1.ReadByte();
            while (b != -1)
            {
                if (c != b && c != b + separationMayus)
                {
                    f2.WriteByte((byte)b);
                }
                b = f1.ReadByte();
            }

            f1.Close();
            f2.Close();
        }
    }
}
