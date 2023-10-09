using System;

namespace Numeros_inteiros
{
    class Numeros_inteiros
    {
        static void Main(string[] args)
        {
            Numeros_inteiros.Validar_input();
        }
        static void Validar_input()
        {
            List<double> numeros = new List<double>();
            int quantidade_A = 10;//Variáveis responsáveis por armazenar o numero de elementos presentes no vetor A

            while (true)
            {
                bool auxiliarA = false;//variável responsável por auxiliar na verificação do input

                if (quantidade_A > 0)
                {
                    Console.WriteLine("Digite os elementos do vetor A, você deve digitar mais " + quantidade_A);
                    auxiliarA = true;
                }

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

                    if ((quantidade_A - partes.Length) < 0)
                    {
                        Console.WriteLine("Entrada inválida,o vetor A deve ter no máximo 10 elementos; digite novamente: ");
                        continue;
                    }

                    quantidade_A = quantidade_A - partes.Length;

                    for (int b = 0; b < partes.Length; b++)
                    {
                        numeros.Add(Convert.ToDouble(partes[b]));
                    }
                    if (quantidade_A == 0)
                        break;//vetor totalmente preenchido
                }
            }
            Numeros_inteiros.Operacoes(numeros);
        }
        static void Operacoes(List<double> numeros)
        {
            numeros.Sort();//ordena o vetor
            double soma = 0;

            for (int a = 0; a < numeros.Count; a++)
                soma = soma + numeros[a];

            Console.WriteLine("Menor numero: " + numeros[0]);
            Console.WriteLine("Média: " + (soma / numeros.Count));
            Console.WriteLine("Soma: " + soma);
        }
    }
}