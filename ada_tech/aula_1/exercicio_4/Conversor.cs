using System;
using System.Globalization;

namespace Conversor_de_Moedas
{
    class Conversor_de_Moedas
    {
        static void Main(string[] args)
        {
            Conversor_de_Moedas.input();
        }

        //função responsável por receber a entrada do usuário e realizar as validações do input
        static void input()
        {
            double valor_entrada;//variável que recebe o input

            while (true)
            {
                Console.WriteLine("insira um valor em reais.");
                string entrada = Console.ReadLine();
                bool quantidade_de_caracteres = false;//variável auxiliar para informar quantas vezes caracteres validos apareceram no input
                bool auxiliar_verificacao = true;//variável auxiliar na validação do input

                if (string.IsNullOrEmpty(entrada)) //verifica se a string é nula ou vazia
                {
                    Console.WriteLine("Valor incorreto,digite novamente: ");
                    continue;
                }

                for (int a = 0; a < entrada.Length; a++) //percorre a string entrada para verificar se é uma string válida
                {
                    char auxiliar = entrada[a];

                    if (!char.IsDigit(auxiliar))
                    {
                        if ((auxiliar != ',' && auxiliar != '.') || quantidade_de_caracteres)//caso no qual esses caracteres aparecem na primeira posição (ex: .2 ou ,2)
                        {
                            Console.WriteLine("Entrada inválida, digite novamente: ");
                            auxiliar_verificacao = false;
                            break;
                        }

                        if (auxiliar == ',' || auxiliar == '.')
                        {
                            if (a == 0)//caso no qual esses caracteres aparecem na primeira posição (ex: .2 ou ,2)
                            {
                                Console.WriteLine("Entrada inválida, digite novamente: ");
                                auxiliar_verificacao = false;
                                break;
                            }
                            quantidade_de_caracteres = true; // agora esses caracteres não podem aparecer novamente na string
                        }
                    }
                }
                
                if (auxiliar_verificacao)
                {
                    // Converte a entrada para double com o separador decimal como ponto
                    valor_entrada = Convert.ToDouble(entrada, CultureInfo.GetCultureInfo("en-US"));

                    if (valor_entrada >= 0)
                        break;

                    Console.WriteLine("Entrada inválida (número negativo), digite novamente:");
                }
            }

            Console.WriteLine("Valor convertido para dolar: " + (valor_entrada / 5.16));
            Console.WriteLine("Valor convertido para euro: " + (valor_entrada / 5.44));
        }
    }
}