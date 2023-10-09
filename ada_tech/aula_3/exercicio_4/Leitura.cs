using System;

namespace Leitura_de_numeros
{
    class Leitura_de_numeros
    {
        static void Main(string[] args)
        {
            Leitura_de_numeros.Validar_input();
        }
        static void Validar_input()
        {
            List<double> numeros = new List<double>();
            int quantidade_A = 10;//Variáveis responsáveis por armazenar o numero de elementos presentes no vetor A
            bool auxiliar_verificação = true;

            while (auxiliar_verificação)
            {
                bool auxiliarA = true;//variável responsável por auxiliar na verificação do input

                Console.WriteLine("Digite um número ");
                string entrada = Console.ReadLine();

                if (string.IsNullOrEmpty(entrada)) // verifica se a entrada é nula ou vazia
                {
                    Console.WriteLine("Elemento inválido,digite novamente: ");
                    continue;
                }

                for (int b = 0; b < entrada.Length; b++)//percorre a string entrada, buscando verificar se ela está dentro dos requisítos
                {
                    if (quantidade_A > 0)
                    {
                        char auxiliar = entrada[b];
                        if (entrada.Length == 1 && auxiliar == '0')
                        {
                            auxiliar_verificação = false;
                            auxiliarA=false;
                            break;
                        }

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
                                Console.WriteLine("Entrada inválida, digite novamente: ");
                                auxiliarA = false;
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

                    for (int b = 0; b < partes.Length; b++)
                    {
                        numeros.Add(Convert.ToDouble(partes[b]));
                    }
                }
            }
            Leitura_de_numeros.Operacoes(numeros);
        }
        static void Operacoes(List<double> numeros)
        {
            numeros.Sort();//ordena o vetor
            double soma = 0;
            double numero_de_pares = 0;

            for (int a = 0; a < numeros.Count; a++)
            {
                soma = soma + numeros[a];

                if (numeros[a] % 2 == 0)
                    numero_de_pares++;
            }

            Console.WriteLine("Quantidade de números lidos: " + numeros.Count);
            Console.WriteLine("Média: " + (soma / numeros.Count));
            Console.WriteLine("Numero de pares: " + numero_de_pares);
        }
    }
}
