using System;

namespace Soma_entre_Intervalos
{
    class Soma_entre_Intervalos
    {
        //esse código permite os seguintes inputs: um número positivo por linha,
        //dois numeros positivos separados por espaços ou linhas(desde que esses caracteres estejam no meio dos inteiros). 
        static void Main(string[] args)
        {
            try
            {
                Soma_entre_Intervalos.Validar_input();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro nas funções estáticas.");
            }
        }
        //função responsável por validar o input do usuário e verificar se está de acordo com os requisitos do exercício
        static void Validar_input()
        {
            int num1 = 0;
            int num2 = 0;
            int quantidade_numeros = 2;//variável auxiliar para informar quantos numeros o usuário ainda deve digitar

            //loop para a leitura de dados do usuário, de modo que tal loop só irá ser quebrado quando os requisitos do problema forem atendidos
            while (true)
            {
                bool auxiliar_validacao = true; //variável auxiliar na verificação do input

                if (quantidade_numeros == 2)
                    Console.WriteLine("Escreva dois números inteiros pares: ");
                else
                    Console.WriteLine("Escreva mais um  número inteiro par: ");

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

                        if (!char.IsDigit(auxiliar))//siginifica que o valor presente não é um valor entre 0-9, porem caracteres ',' ' '. são validos com algumas restrições
                        {

                            if ((a == 0) && (auxiliar == ',' || auxiliar == ' '))//significa que os caracteres ',' ' ', estão na primeira posiçao do vetor (EX: ,2,2)
                            {
                                Console.WriteLine("Entrada inválida, digite novamente: ");
                                auxiliar_validacao = false;
                                break;
                            }

                            if ((a == entrada.Length) && (auxiliar == ',' || auxiliar == ' '))//significa que os caracteres ',' ' ', estão na última posiçao do vetor (EX: 2,2,)
                            {
                                Console.WriteLine("Entrada inválida, digite novamente: ");
                                auxiliar_validacao = false;
                                break;
                            }

                            if (auxiliar == ' ' || auxiliar == ',')//caso no qual o usuário digita algo como 2,,2 ou 2  2
                            {
                                char auxiliar2 = entrada[a + 1];
                                if (char.IsDigit(auxiliar2))
                                    continue;//significa que o valor na frente do + é um número 

                                Console.WriteLine("Entrada inválida, digite novamente: ");
                                auxiliar_validacao = false;
                                break;
                            }

                            if (auxiliar != ',' && auxiliar != ' ')//significa que o input apresenta algum caractere não válido
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
                    }

                    if (auxiliar_validacao) //significa que o input passou na primeira bateria de verificação, sendo esse um valor númerico
                    {

                        string[] partes = entrada.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if ((quantidade_numeros - partes.Length) < 0)// caso no qual o usuário digita os numeros em uma linha apenas(Ex. 2,2,3)
                        {
                            Console.WriteLine("Entrada inválida,o a quantidade de números deve ser no máximo 2 elementos; digite novamente: ");
                            continue;
                        }

                        //verificar se o input de entrada é um valor válido para um inteiro,
                        // pois um dos requisítos do problema era a entrada somente de numeros inteiros
                        for (int a = 0; a < partes.Length; a++)
                        {
                            try
                            {
                                // passa o avlor armazenado para uma variável do tipo long, 
                                //pois o valor long consegue armazenar um valor de até  9223372036854775807.
                                long numero_entrada = Convert.ToInt64(partes[a]);

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
                            for (int a = 0; a < partes.Length; a++)
                            {
                                if (quantidade_numeros == 2)
                                    num1 = Convert.ToInt32(partes[a]);
                                else
                                    num2 = Convert.ToInt32(partes[a]);

                                quantidade_numeros--;
                            }

                            if (quantidade_numeros == 0)
                                break; //números preenchidos com sucsso
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Erro, algum input inválido foi digitado, digite novamente: ");
                }
            }

            Soma_entre_Intervalos.Operacao(num1, num2);
        }
        //função responsável por realizar a operação desejada no problema
        static void Operacao(int num1, int num2)
        {
            int troca; //variável auxiliar para trocar a ordem dos números caso num1 seja maior que num2 
            int soma = 0;

            if (num1 > num2)
            {
                troca = num1;
                num1 = num2;
                num2 = troca;
            }
            //o enunciado não específicou se os numeros que delimitavam o intervalo entrariam na conta,logo minha na interpretação
            //coloquei para eles entrarem caso sejam pares
            for (int a = num1; a <= num2; a++)
            {
                if (a % 2 == 0)
                    soma = soma + a;
            }

            Console.WriteLine("A soma dos numeros pares dentro do intervalo é: " + soma);
        }
    }
}