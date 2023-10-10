using System;

namespace Sequencia_Fibonacci
{
    class Sequencia_Fibonacci
    {
        //o usuário deve digitar um valor inteiro de no máximo 2147483647, pois é o maior valor suportado por um int.
        // coloquei essa limitação, pois o cálculo da sequencia de fibonacci para valores maiores que esse levariam um poder de processamento muito grande
        static void Main(string[] args)
        {
            try
            {
                Sequencia_Fibonacci.Validar_input();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //função responsável por validar o input do usuário e verificar se está de acordo com os requisitos do exercício
        static void Validar_input()
        {
            int num1 = 0;
            //loop para a leitura de dados do usuário, de modo que tal loop só irá ser quebrado quando os requisitos do problema forem atendidos
            while (true)
            {
                bool auxiliar_validacao = true; //variável auxiliar na verificação do input

                Console.WriteLine("Escreva um número inteiros par: ");

                try
                {
                    string entrada = Console.ReadLine();

                    if (string.IsNullOrEmpty(entrada)) //verifica se o input passado é nulo ou vazio
                    {
                        Console.WriteLine("Entrada inválida, digite novamente: ");
                        continue;
                    }

                    for (int a = 0; a < entrada.Length; a++) //percorre a string passada como parametro para verificar se é um input válido
                    {
                        char auxiliar = entrada[a];

                        if (!char.IsDigit(auxiliar))//siginifica que o valor presente não é um valor entre 0-9
                        {
                            if (auxiliar == '+' && ((a + 1) < entrada.Length))//verificar input do usuário como por exemplo +4, indicando ser um número positivo
                            {
                                char auxiliar2 = entrada[a + 1];
                                if (char.IsDigit(auxiliar2))
                                    continue;//significa que o valor na frente do + é um número 
                            }
                            Console.WriteLine("Entrada inválida, digite novamente: ");
                            auxiliar_validacao = false;
                            break;
                        }
                    }

                    if (auxiliar_validacao) //significa que o input passou na primeira bateria de verificação, sendo esse um valor númerico
                    {
                        //verificar se o input de entrada é um valor válido para um inteiro,
                        // pois um dos requisítos do problema era a entrada somente de numeros inteiros
                        for (int a = 0; a < entrada.Length; a++)
                        {
                            try
                            {
                                // passa o valor armazenado para uma variável do tipo long, 
                                //pois o valor long consegue armazenar um valor de até  9223372036854775807.
                                long numero_entrada = Convert.ToInt64(entrada);

                                if (numero_entrada > 2147483647) //significa que o input passado é maior que o valor suportado por um inteiro na arquitetura atual.
                                {
                                    Console.WriteLine("Numero passado ultrapassa o tamanho de um int, digite novamente:");
                                    auxiliar_validacao = false;
                                    break;
                                }
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("O número digitado é muito grande para ser convertido em um long.");
                                auxiliar_validacao = false;
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("A entrada não é um número válido.");
                                auxiliar_validacao = false;
                                break;
                            }
                        }

                        if (auxiliar_validacao)//chegado a esse ponto a entrada digitada pelo usuário é válida
                        {
                            num1 = Convert.ToInt32(entrada);
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Erro, algum input inválido foi digitado, digite novamente: ");
                }
            }

            Sequencia_Fibonacci.Fibonacci(num1, 0, 1);
        }

        //função responsável por realizar o calculo de fibonacci de maneira recursiva
        static void Fibonacci(int parametro_N, int num1, int num2)
        {
            if (parametro_N == 0)
                return; //condição de parada da recursão
            else
            {
                if (num1 == 0 && num2 == 1)
                {
                    Console.WriteLine(num1);
                    Console.WriteLine(num2);
                    parametro_N = parametro_N - 2;
                }
                Console.WriteLine(num1 + num2);
                Fibonacci(parametro_N - 1, num2, num1 + num2); //chama a função novamente de forma recursiva
            }
        }
    }
}