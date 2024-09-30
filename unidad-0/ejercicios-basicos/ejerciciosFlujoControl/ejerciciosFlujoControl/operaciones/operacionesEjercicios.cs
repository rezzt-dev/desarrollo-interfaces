using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ejerciciosFlujoControl.operaciones
{
  internal class operacionesEjercicios
  {
    // Escribe un programa que imprima “PASS” si la variable entera “mark” es mayor o igual a 50; o imprime “FAIL” en otro caso.
    public static void ejercicio1(int mark)
    {
      if (mark >= 50)
      {
        Console.WriteLine("PASS");
      } else
      {
        Console.WriteLine("FAIL");
      }
    }
    // Escribe un programa que imprima “Número Impar” si la variable entera “numero” es impar o par si la variable es par.
    public static void ejercicio2(int numero)
    {
      if ((numero % 2) == 0)
      {
        Console.WriteLine("Numero Par");
      } else
      {
        Console.WriteLine("Numero Impar");
      }
    }

    // Escribe un programa que calcule la suma de 1,2,3,…, a un número especificado como cota superior ( por ejemplo . 100).
    // Además  calcula y muestra la media.
    public static void ejercicio3(int numero)
    {
      int resultado = 0;
      int contador = 0;

      for (int i = 1; i < numero; i++)
      {
        resultado += i;
        contador++;
      }

      double media = (double)resultado / contador;

      Console.WriteLine($"La suma de los números del 1 al {numero} es: {resultado}");
      Console.WriteLine($"La media es: {media:F2}");
    }

    public static void ejercicio3mod1(int numero) 
    {
      int resultado = 0;
      int numeroSum = 1;
      int contador = 0;

      do
      {
          resultado += numeroSum;
          contador++;
          numeroSum++;
      } while (numeroSum <= numero);

      double media = (double)resultado / contador;
      Console.WriteLine($"La suma de los números del 1 al {numero} es: {resultado}");
      Console.WriteLine($"La media es: {media:F2}");
    }

    public static void ejercicio3mod2 (int numero)
    {
      int resultado = 0;
      int contador = 0;

      for (int i = 1;i < numero;i++)
      {
        if (i%2 == 0)
        {
          resultado += i;
          contador++;
        }
      }

      double media = (double) resultado / contador;
      Console.WriteLine($"La suma de los números del 1 al {numero} es: {resultado}");
      Console.WriteLine($"La media es: {media:F2}");
    }

    public static void ejercicio3mod3 (int numero)
    {
      int resultado = 0;
      int contador = 0;

      for (int i = 1; i < numero;i++)
      {
        if ((i%7) == 0)
        {
          resultado += i;
          contador++;
        }
      }

      double media = (double)resultado / contador;
      Console.WriteLine($"La suma de los números del 1 al {numero} es: {resultado}");
      Console.WriteLine($"La media es: {media:F2}");
    }

    public static void ejercicio3mod4 (int numero)
    {
      int resultado = 0;
      int contador = 0;

      for (int i = 1; i < numero ; i++)
      {
        resultado += (i * i);
        contador++;
      }

      double media = (double) resultado / contador;
      Console.WriteLine($"La suma de los números del 1 al {numero} es: {resultado}");
      Console.WriteLine($"La media es: {media:F2}");
    }

    // Escribe un programa que calculo la suma de las series armónicas, como se muestra en la figura de abajo, donde n=50000.
    // El programa podrá cualquier la suma de izquierda a derecha como también de derecha a izquierda. Obten la diferencia
    // entre las dos sumas y explica la diferencia de qué suma es más precisa?.
    public static void ejercicio4 (int numero)
    {
      double izquierdaDerecha = sumaIzquierdaDerecha(numero);
      double derechaIzquierda = sumaDerechaIzquierda(numero);

      double diferencia = Math.Abs(izquierdaDerecha - derechaIzquierda);

      Console.WriteLine($"Suma de izquierda a derecha: {izquierdaDerecha}");
      Console.WriteLine($"Suma de derecha a izquierda: {derechaIzquierda}");
      Console.WriteLine($"Diferencia: {diferencia}");
    }

    private static double sumaIzquierdaDerecha (int numero)
    {
      double resultado = 0;

      for (int i = 1;i <= numero ; i++)
      {
        resultado += (1.0 / i);
      }

      return resultado;
    }

    private static double sumaDerechaIzquierda(int numero)
    {
      double resultado = 0;

      for (int i = numero; i >= 1 ; i--)
      {
        resultado += (1.0 / i);
      }

      return resultado;
    }

   // Escribe un programa que calcule el valor de π, usando las siguientes series de expansión. Puedes decidir el criterio
   // de terminación a usar  ( como el número de términos usados o la magnitud de un término adicional). Es esta serie adaptable
   // para el cálculo de π?
    public static void ejercicio5 ()
    {
      int numTerminos = 1000000;

      double pi = calcularPi(numTerminos);
      Console.WriteLine($"Aproximación de π: {pi}");
      Console.WriteLine($"Valor real de π:   {Math.PI}");
      Console.WriteLine($"Diferencia:        {Math.Abs(pi - Math.PI)}");
    }

    private static double calcularPi (int numTerminos)
    {
      double resultado = 0;

      for (int i = 1; i <= numTerminos ; i++)
      {
        int marca = (i%2 == 0 ? 1 : -1);
        resultado += (marca / (2.0 * i +1 ));
      }

      return 4 * resultado;
    }
   // números Tribonacci son un secuencia de números T(n) similar a los números Fibonacci, excepto que un número es formado
   // añadiendo los tres números previos. Por ejemplo , T(n)=T(n-1)+T(n-2)+T(n-3), T(1)=T(2)=1, y T(3)=2. Escribe un programa
   // que calcule los primeros veinte números Tribonacci.
    public static void ejercicio6 (int numero)
    {
      int numeroMax = numero;
      long[] lista = new long[numeroMax];

      lista[0] = 1;
      lista[1] = 1;
      lista[2] = 2;

      for (int i = 3; i <= numeroMax; i++)
      {
        lista[i] = lista[i - 1] + lista[i - 2] + lista[i - 3];
      }

      Console.WriteLine("Los primeros 20 números de la secuencia Tribonacci son:");
      for (int i = 0; i < numeroMax; i++)
      {
        Console.WriteLine($"T({i + 1}) = {lista[i]}");
      }     
    }

   // Escribe un programa que muestre multiplicación la tabla del 1 al 9 como se muestra usando dos bucles anidados.
    public static void ejercicio7 ()
    {
      for (int i = 1; i <= 9; i++)
      {
        Console.Write($"{i} |");
        for (int j = 1; j <= 9; j++)
        {
          Console.Write($"{i * j, 4}");
        }
        Console.WriteLine();
      }
    }

    public static void ejercicio7mod1 ()
    {
      for (int i = 1; i <= 81; i++)
      {
        if ((i - 1) % 9 == 0)
        {
          // Inicio de una nueva fila
          Console.Write($"{(i - 1) / 9 + 1} |");
        }

        Console.Write($"{i,4}");

        if (i % 9 == 0)
        {
          // Fin de la fila
          Console.WriteLine();
        }
      }
    }
  }
}
