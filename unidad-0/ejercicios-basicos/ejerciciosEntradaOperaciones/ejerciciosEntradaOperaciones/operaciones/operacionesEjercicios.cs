using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ejerciciosEntradaOperaciones.operaciones
{
    internal class operacionesEjercicios
    {
        public static void ejercicio9 ()
        {
            Console.WriteLine("Introduce una cadena String: ");
            String cadenaInput = Console.ReadLine();

            String cadenaOutput = new string(cadenaInput.Reverse().ToArray());
            Console.WriteLine(cadenaOutput);
        }

        public static void ejercicio10()
        {
            Console.WriteLine("Introduce una cadena para ver si es un palindromo: ");
            String cadenaInput = Console.ReadLine().ToLower();

            String cadenaReversa = new string(cadenaInput.Reverse().ToArray());
            if (cadenaInput.Equals(cadenaReversa))
            {
                Console.WriteLine("La palabra ${0} es palindromo", cadenaInput);
            } else
            {
                Console.WriteLine("La palabra ${0} no es palindromo", cadenaInput);
            }
        }
        
        public static void ejercicio10mod1 ()
        {
            Console.WriteLine("Introduce una cadena para ver si es un palindromo: ");
            String cadenaInput = Console.ReadLine().ToLower();

            String cadenaLimpia = Regex.Replace(cadenaInput, @"[^a-z0-9]", "");
            String cadenaReversa = new string(cadenaLimpia.Reverse().ToArray());

            if (cadenaInput.Equals(cadenaReversa))
            {
                Console.WriteLine("La palabra ${0} es palindromo", cadenaInput);
            }
            else
            {
                Console.WriteLine("La palabra ${0} no es palindromo", cadenaInput);
            }
        }

        public static void ejercicio11 ()
        {
            Console.WriteLine("Introduce una cadena en binario:");
            string cadenaBinaria = Console.ReadLine();

            if (esBinario(cadenaBinaria))
            {
                int numeroDecimal = Convert.ToInt32(cadenaBinaria);
                Console.WriteLine($"El equivalente al número decimal para el binario \"{cadenaBinaria}\" es {numeroDecimal}.");
            } else
            {
                Console.WriteLine($"Error: el valor binario \"{cadenaBinaria}\" es erróneo.");
            }
        }

        private static bool esBinario(string cadenaInput)
        {
            foreach (char c in cadenaInput)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }

        public static void ejercicio12 ()
        {
            Console.WriteLine("Introduce una cadena en hexadecimal: ");
            string cadenaHexadecimal = Console.ReadLine();

            try
            {
                int numeroDecimal = Convert.ToInt32(cadenaHexadecimal, 16);
                Console.WriteLine($"El equivalente decimal para el número hexadecimal \"{cadenaHexadecimal}\" es {numeroDecimal}.");
            } catch (FormatException)
            {
                Console.WriteLine($"Error: cadena hexadecimal inválida \"{cadenaHexadecimal}\".");
            }
        }
    }
}
