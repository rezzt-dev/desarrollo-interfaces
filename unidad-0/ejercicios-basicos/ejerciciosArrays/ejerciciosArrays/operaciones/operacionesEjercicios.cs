using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ejerciciosArrays.operaciones
{
    internal class operacionesEjercicios
    {
        public static void ejercicio13 ()
        {
            Console.WriteLine("Introduce un numero de estudiantes: ");
            int numEstudiantes = int.Parse(Console.ReadLine());

            int[] listaNotas = new int[numEstudiantes];
            int sumaNotas = 0;
            int notaTemp;
            for (int i = 0; i < numEstudiantes; i++)
            {
                Console.WriteLine("Introduce la nota del estudiante ${0}", (i + 1));
                notaTemp = int.Parse(Console.ReadLine());

                if ((notaTemp > 100) || (notaTemp < 0))
                {
                    Console.WriteLine("Nota no valida.");
                    i--;
                } else
                {
                    listaNotas[i] = sumaNotas;
                    sumaNotas += notaTemp;
                }
            }

            double media = (double) sumaNotas / numEstudiantes;

            Console.WriteLine("La media es " + media); 
        }

        public static void ejercicio14 ()
        {
            string[] binarioEquivalente =
            {
                "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111",
                "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111"
            };

            Console.WriteLine("Introduce una cadena hexadecimal: ");
            string cadenaHexadecimal = Console.ReadLine().ToLower();

            string cadenaBinaria = "";

            foreach (char c in cadenaHexadecimal)
            {
                int valorDecimal;
                if (char.IsDigit(c))
                {
                    valorDecimal = c - '0';
                } else if (c >= 'a' && c <= 'f') {
                    valorDecimal = c - 'a' + 10;
                } else
                {
                    Console.WriteLine("Error! Formato no correcto");
                    return;
                }

                cadenaBinaria += binarioEquivalente[valorDecimal] + "";
            }

            Console.WriteLine($"La cadena binaria equivalente para \"{cadenaHexadecimal}\" es {cadenaBinaria.Trim()}.");
        }
    }
}
