using System;

namespace Numero_aleatorio
{
    class Numero_aleatorio
    {
        static void Main(string[] args)
        {
            try
            {
                int numero_aleatorio = Numero_aleatorio.Gerar_numero();

                if (numero_aleatorio == 0)
                    Console.WriteLine("Erro na geração do numero aleatório");

                Numero_aleatorio.Dicas_usuário(numero_aleatorio, 1, 100);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //função responsável por validar o input do usuário e verificar se está de acordo com os requisitos do exercício
        static int Validar_input()
        {
            int num1 = 0;
            //loop para a leitura de dados do usuário, de modo que tal loop só irá ser quebrado quando os requisitos do problema forem atendidos
            while (true)
            {
                bool auxiliar_validacao = true; //variável auxiliar na verificação do input

                Console.WriteLine("Tente acertar o  umero aleátorio gerado entre 1 e 100, digite seu chute: ");

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
                                    Console.WriteLine("Numero passado ultrapassa o limite de 1 a 100, digite novamente:");
                                    auxiliar_validacao = false;
                                    break;
                                }
                            }
                            catch (OverflowException) //caso no qual o usuário digita um valo muito grande para quebrar o programa
                            {
                                Console.WriteLine("O número digitado é muito grande , ultrapassa o valor de 1 a 100.");
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
                            if (num1 > 100 || num1 < 1)
                            {
                                Console.WriteLine("A entrada não é um número válido.digite um valor entre 1 e 100");
                                continue;
                            }

                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Erro, algum input inválido foi digitado, digite novamente: ");
                }
            }

            return num1;
        }

        //função responsável por gerar dicas para o usuário
        static void Dicas_usuário(int num_sorteado, int comeco, int final)
        {

            int numero_usuario = Numero_aleatorio.Validar_input();
            if (comeco == final)
            {
                Console.WriteLine("Voce utilizou todas as suas dicas, desculpe tente novamente.");
                return;
            }
            if (num_sorteado == numero_usuario)
            {
                Console.WriteLine("Parabens você acertou o número");
                return;
            }
            else
            {
                if (num_sorteado > ((comeco + final) / 2))
                {
                    Console.WriteLine("\n" + "O numero aleátorio sorteado é maior que " + ((comeco + final) / 2) + " e menor que" + final);
                    Dicas_usuário(num_sorteado, (comeco + final) / 2, final);
                }
                else
                {
                    Console.WriteLine("\n" + "O numero aleátorio sorteado é maior que " + comeco + " e menor que " + ((comeco + final) / 2));
                    Dicas_usuário(num_sorteado, comeco, (comeco + final) / 2);
                }
            }
        }

        //função responsável por gerar o número aleátorio para o usuário
        static int Gerar_numero()
        {
            int numeroAleatorio;

            try
            {
                // Tente criar uma instância da classe Random
                Random random = new Random();

                // Gere um número aleatório entre 1 e 100
                numeroAleatorio = random.Next(1, 101);
            }
            catch (Exception ex)
            {
                // Lidere com exceções se a instância Random não puder ser criada
                Console.WriteLine("Ocorreu um erro ao gerar o número aleatório: " + ex.Message);
                return 0;
            }

            return numeroAleatorio;
        }

    }
}