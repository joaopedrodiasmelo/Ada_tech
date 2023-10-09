using System;

namespace Calculadora
{
    class Calculadora
    {
        //função responsável por realizar as operações básicas 
        static void operacoes(double num1, double num2)
        {
            Console.WriteLine("Adição :" + (num1 + num2));
            Console.WriteLine("Subtração :" + (num1 - num2));
            Console.WriteLine("Multiplicação :" + (num1 * num2));

            if (num2 != 0)
                Console.WriteLine("Divisão :" + (num1 / num2));
            else
                Console.WriteLine("Operação inválida - divisão por 0");
        }
        //função responsável por validar o input de acordo com os requisítos desejados
        static void validacao()
        {
            double[] numeros = new double[2]; //armazena os valores do input

            for (int a = 0; a < 2; a++)
            {
                bool auxiliar = true;
                string entrada = Console.ReadLine();

                //quando o input é vazio 
                if (string.IsNullOrEmpty(entrada))
                {
                    Console.WriteLine("Entrada inválida. Digite um número.");
                    a--; // Volte ao índice anterior para repetir a entrada inválida
                    continue;
                }

                //verificar se todos os char presentes na string são digitos válidos
                for (int b = 0; b < entrada.Length; b++)
                {
                    char verifica = entrada[b];
                    if (!char.IsDigit(verifica))
                    {
                        Console.WriteLine("Entrada inválida. Digite um número.");
                        a--;
                        auxiliar = false;
                        break;
                    }
                }
                if (auxiliar)
                    numeros[a] = Convert.ToDouble(entrada);
            }

            Calculadora.operacoes(numeros[0], numeros[1]);
        }
        static void Main(string[] args)
        {
            Calculadora.validacao();
        }
    }
}