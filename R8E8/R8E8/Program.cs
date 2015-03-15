using System;
using System.Text;
using System.IO;

namespace R8E8
{
    class Program
    {
        static String[] alumnos = {
            "Carlos Fernández Llamas",
            "Jose Enrique Bravo Gómez",
            "Sergio Álvarez García",
            "Álvaro Perez Peñalver"
        };

        static void Main(string[] args)
        {
            Boolean salir = false;
            String option;

            while(!salir)
            {
                Console.Clear();
                Console.WriteLine("    Gestor de alumnos\n");
                Console.WriteLine("    [0] Crear fichero de alumnos");
                Console.WriteLine("    [1] Listar fichero de alumnos");
                Console.WriteLine("    [x] Salir");
                Console.WriteLine();
                Console.Write("    ¿Qué desea hacer?: ");
                option = Console.ReadLine();

                if (option == "0")
                {
                    CrearFichero(AskPath());
                    EnterToContinue();
                }
                else if (option == "1")
                {
                    ListarFichero(AskPath());
                    EnterToContinue();
                }
                else if (option.ToLower() == "x")
                {
                    salir = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opción inválida");
                    EnterToContinue();
                }
            }
        }

        static void EnterToContinue()
        {
            Console.WriteLine("Pulse enter para continuar...");
            Console.ReadLine();
        }

        static String AskPath()
        {
            Console.Clear();
            Console.Write("Especifique la ruta del fichero: ");
            return Console.ReadLine();
        }

        static void CrearFichero(string fi)
        {
            Console.Clear();
            StringBuilder result = new StringBuilder();
            foreach(String alumno in alumnos)
            {
                result.Append(alumno+"\n");
            }
            try
            {
                File.WriteAllText(fi, result.ToString(), Encoding.UTF8);
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: Error inesperado escribiendo el archivo");
                return;
            }

            Console.WriteLine("Fichero creado con éxito");
        }

        static void ListarFichero(string fi)
        {
            Console.Clear();
            String textcontent;
            try
            {
                textcontent = File.ReadAllText(fi);
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: Error inesperado leyendo el archivo");
                return;
            }

            Console.WriteLine(textcontent);
        }
    }
}
