using System;
using System.Globalization;

namespace Calcular_gorgeta
{
    class Calcular_gorgeta
    {
        //função responsável por receber a % de gorgeta que o cliente deseja pagar e verificar se o input está de acordo com os requisítos
        static void Gorgeta(double valor_conta)
        {
            double porcentagem_gorgeta;

            while (true)
            {
                Console.WriteLine("Porcentagem de gorjeta desejada: ");
                string entrada = Console.ReadLine();
                bool auxiliar_verificacao = true;

                if (string.IsNullOrEmpty(entrada))
                {
                    Console.WriteLine("Entrada inválida, digite novamente:");
                    continue;
                }

                for (int a = 0; a < entrada.Length; a++)
                {
                    char auxiliar = entrada[a];
                    if (!char.IsDigit(auxiliar))
                    {
                        //o caractere '%' é o único que pode estar presente mais deve obrigatoriamente estar no final(ou seja antepenúltima posição - atrás somente do caractere de escape'n\') da string
                        if (auxiliar == '%' && (a == entrada.Length - 1) && entrada.Length != 1) // essa condição (  entrada.Length != 1) é para o caso que o usuário digita apenas %
                            continue;

                        Console.WriteLine("Entrada inválida, digite novamente:");
                        auxiliar_verificacao = false;
                        break;
                    }
                }
                if (auxiliar_verificacao)
                {
                    // Remove o '%' da entrada, se presente, e converte para double
                    if (entrada[entrada.Length - 1] == '%')
                    {
                        string entradaSemPercentagem = entrada.Replace("%", "");
                        porcentagem_gorgeta = Convert.ToDouble(entradaSemPercentagem, CultureInfo.GetCultureInfo("en-US"));
                    }
                    else
                        porcentagem_gorgeta = Convert.ToDouble(entrada, CultureInfo.GetCultureInfo("en-US"));

                    if (porcentagem_gorgeta < 0)//caso no qual o input é negativo
                    {
                        Console.WriteLine("Entrada inválida, digite novamente:");
                        continue;
                    }
                    break;// quebra o while, pois todos os testes foram positivos e o input está correto
                }
            }
            // Calcula a gorjeta e o total a pagar e exibe os resultados formatados com o separador decimal como ponto
            Console.WriteLine("Valor da Gorgeta: " + ((valor_conta * porcentagem_gorgeta) / 100).ToString("C", CultureInfo.GetCultureInfo("en-US")));
            Console.WriteLine("Total a pagar: " + (valor_conta + ((valor_conta * porcentagem_gorgeta) / 100)).ToString("C", CultureInfo.GetCultureInfo("en-US")));
        }

        // Função responsável por receber o valor da conta do usuário e verificar se o input está dentro dos requisítos
        static void Valor_conta()
        {
            double valor_conta;

            while (true)
            {
                Console.WriteLine("Insira o valor da sua conta: ");
                string entrada = Console.ReadLine();

                bool quantidade_de_caracteres = false;//variável auxiliar para informar quantas vezes caracteres validos apareceram no input
                bool auxiliar_verificacao = true;//variável auxiliar na validação do input

                if (string.IsNullOrEmpty(entrada))
                {
                    Console.WriteLine("Entrada inválida, digite novamente:");
                    continue;
                }

                for (int a = 0; a < entrada.Length; a++)
                {
                    char auxiliar = entrada[a];
                    if (!char.IsDigit(auxiliar))
                    {
                        if ((auxiliar != ',' && auxiliar != '.') || quantidade_de_caracteres)
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
                    valor_conta = Convert.ToDouble(entrada, CultureInfo.GetCultureInfo("en-US"));

                    if (valor_conta >= 0)
                        break;

                    Console.WriteLine("Entrada inválida (número negativo), digite novamente:");
                }

            }
            // Chama a função Gorgeta com o valor da conta obtido
            Calcular_gorgeta.Gorgeta(valor_conta);
        }
        static void Main(string[] args)
        {
            // Inicia o programa chamando a função Valor_conta
            Calcular_gorgeta.Valor_conta();
        }
    }
}
