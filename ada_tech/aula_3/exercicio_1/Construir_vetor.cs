using System;
using System.Collections.Generic;

namespace Vetores
{
    class Vetores
    {
        static void Main(string[] args)
        {
            {
                Vetores.Validar_input();
            }
        }
        //função responsável por receber o input, validar esse input, e realizar as operações desejadas no exercício
        static void Validar_input()
        {
            List<double> vetorA = new List<double>();
            List<double> vetorB = new List<double>();
            List<double> vetorC = new List<double>();
            //Variáveis responsáveis por armazenar o numero de elementos presentes nos vetores A e B(em cada inserção eu decremento)
            int quantidade_A = 10;
            int quantidade_B = 10;

            while (true)
            {
                //variáveis responsáveis por auxiliar na verificação dos input
                bool auxiliarA = false;
                bool auxiliarB = false;

                if (quantidade_A > 0)
                {
                    Console.WriteLine("Digite os elementos do vetor A, você deve digitar mais " + quantidade_A);
                    auxiliarA = true;
                }
                else if (quantidade_B > 0)
                {
                    Console.WriteLine("Digite os elementos do vetor B, você deve digitar mais " + quantidade_B);
                    auxiliarB = true;
                }

                string entrada = Console.ReadLine();

                if (string.IsNullOrEmpty(entrada)) // verifica se a entrada é nula ou vazia
                {
                    Console.WriteLine("Elemento inválido,digite novamente: ");
                    continue;
                }

                for (int b = 0; b < entrada.Length; b++)//percorre a string entrada, buscando verificar se ela está dentro dos requisítos
                {
                    if (quantidade_A > 0) //significa que a leitura de dados está no vetorA
                    {
                        char auxiliar = entrada[b];
                        if (!char.IsDigit(auxiliar))//siginifica que o valor presente não é um valor entre 0-9, porem caracteres ',' ' '. são validos com algumas restrições
                        {

                            if ((b == 0) && (auxiliar == ',' || auxiliar == ' '))//significa que os caracteres ',' ' ', estão na primeira posiçao do vetor
                            {
                                Console.WriteLine("Entrada inválida, digite novamente: ");
                                auxiliarA = false;
                                break;
                            }

                            if (auxiliar != ',' && auxiliar != ' ')
                            {
                                if (auxiliar == '-' && ((b + 1) < entrada.Length))//verificar numeros negativos
                                {
                                    char auxiliar2 = entrada[b + 1];
                                    if (char.IsDigit(auxiliar2))
                                        continue;//significa que o valor na frente do - é um número 
                                }
                                Console.WriteLine("Entrada inválida, digite novamente: ");
                                auxiliarA = false;
                                break;
                            }
                        }
                    }
                    else//significa que a leitura de dados está no vetorB
                    {
                        char auxiliar = entrada[b];
                        if (!char.IsDigit(auxiliar))//siginifica que o valor presente não é um valor entre 0-9, porem caracteres ',' ' '. são validos com algumas restrições
                        {
                            if ((b == 0) && (auxiliar == ',' || auxiliar == ' '))//significa que os caracteres ',' ' ', estão na primeira posiçao do vetor
                            {
                                Console.WriteLine("Entrada inválida, digite novamente: ");
                                auxiliarB = false;
                                break;
                            }
                            if (auxiliar != ',' && auxiliar != ' ')
                            {
                                if (auxiliar == '-' && ((b + 1) < entrada.Length))//verificar numeros negativos
                                {
                                    char auxiliar2 = entrada[b + 1];
                                    if (char.IsDigit(auxiliar2))
                                        continue;//significa que o valor na frente do - é um número 
                                }

                                Console.WriteLine("Entrada inválida, digite novamente: ");
                                auxiliarB = false;
                                break;
                            }
                        }
                    }
                }
                if (auxiliarA)
                {
                    // Define os caracteres de delimitação (',' e ' ')
                    char[] delimitadores = { ',', ' ' };

                    // Divide a string em partes usando os delimitadores
                    string[] partes = entrada.Split(delimitadores, StringSplitOptions.RemoveEmptyEntries);
                    if ((quantidade_A - partes.Length) < 0)
                    {
                        Console.WriteLine("Entrada inválida,o vetor A deve ter no máximo 10 elementos; digite novamente: ");
                        continue;
                    }

                    quantidade_A = quantidade_A - partes.Length;

                    for (int b = 0; b < partes.Length; b++)
                    {
                        vetorA.Add(Convert.ToDouble(partes[b]));
                    }

                    continue;
                }

                if (auxiliarB)
                {
                    // Define os caracteres de delimitação (',' e ' ')
                    char[] delimitadores = { ',', ' ' };

                    // Divide a string em partes usando os delimitadores
                    string[] partes = entrada.Split(delimitadores, StringSplitOptions.RemoveEmptyEntries);
                    if ((quantidade_B - partes.Length) < 0)
                    {
                        Console.WriteLine("Entrada inválida,o vetor B deve ter no máximo 10 elementos; digite novamente: ");
                        continue;
                    }
                    
                    quantidade_B = quantidade_B - partes.Length;

                    for (int b = 0; b < partes.Length; b++)
                    {
                        vetorB.Add(Convert.ToDouble(partes[b]));
                    }

                    if (quantidade_B == 0)
                        break;//ambos os vetores foram preenchidos
                }
            }
            //preenchendo o vetor C
            for (int a = 0; a < 10; a++)
            {
                vetorC.Add(vetorA[a] + vetorB[a]);
            }
            //printando 0 vetor C
            Console.WriteLine("Vetor C: ");
            for (int a = 0; a < 10; a++)
            {
                Console.WriteLine(vetorC[a] + " ");
            }
        }
    }
}