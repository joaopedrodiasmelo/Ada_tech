using System;

namespace Calcular_idade
{

    class Calcular_idade
    {
        //função responsável por validar o input do usuário
        static void Validacao()
        {
            double[] datas = new double[2]; //variável responsável por armazenar o ano atual e a data de nascimento

            for (int a = 0; a < 2; a++)
            {
                if (a == 0)
                    Console.WriteLine("Insira o ano atual: ");
                else
                    Console.WriteLine("Insira sua data de nascimento: ");


                bool auxiliar = true;//variável auxiliar na verificação do input
                string entrada = Console.ReadLine();

                if (string.IsNullOrEmpty(entrada))
                { //verificar se a string é nula 
                    Console.WriteLine("Entrada inválida, digite novamente:");
                    a--;
                    continue;
                }

                for (int b = 0; b < entrada.Length; b++) //percorre a string de entrada para verificar se é um input válido
                {
                    char auxiliar2 = entrada[b];
                    if (!char.IsDigit(auxiliar2))
                    {
                        Console.WriteLine("Entrada inválida, digite novamente:");
                        a--;
                        auxiliar = false;
                        break;
                    }
                }
                if (auxiliar)
                {
                    double teste_num_negativo = Convert.ToDouble(entrada); //verificar se o input é negativo ou não
                    if (teste_num_negativo >= 0) //valor válido
                    {
                        datas[a] = teste_num_negativo;
                        continue;
                    }
                    Console.WriteLine("Entrada inválida (número negativo), digite novamente:");
                    a--;
                }
            }

            if (datas[1] > datas[0]) // caso no qual o ano de nascimento e maior que o ano atual
            {
                Console.WriteLine("Entrada inválida (ano de nascimento e maior que o ano atual)");
                return;
            }

            Console.WriteLine("Idade atual(em anos): " + (datas[0] - datas[1]));
        }
        static void Main(string[] args)
        {
            Calcular_idade.Validacao();
        }
    }

}