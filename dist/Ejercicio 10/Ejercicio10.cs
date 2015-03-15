using System;
using System.Text;
using System.IO;

namespace R8E10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fichero de texto a la inversa");
            Console.Write("Fichero a leer al revés: ");
            String filePath = Console.ReadLine();

            try
            {
                FileInfo fi = new FileInfo(filePath);
                if(fi.Exists)
                {
                    Console.Clear();
                    LeerAlReves(filePath);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ERROR: ");
                    Console.ResetColor();
                    Console.WriteLine("El fichero no existe");
                }
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ERROR: ");
                Console.ResetColor();
                Console.WriteLine("Error inesperado al intentar leer el fichero");
            }
            
            Console.WriteLine("\nPulse enter para salir...");
            Console.ReadLine();
        }

        static void LeerAlReves(String filePath)
        {
            StringBuilder sb = new StringBuilder();
            FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
            var c = 1;
            int b;
            b = fs.ReadByte();
            while (fs.Length - c >= 0)
            {
                fs.Position = fs.Length - c;
                sb.Append( (char) fs.ReadByte());
                c++;
            }
            fs.Close();

            Console.WriteLine(sb.ToString());
        }
    }
}
