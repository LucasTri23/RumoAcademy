using System;
using System.Collections.Generic;


namespace NumerosPositivos
{
    class Exercicio
    {
        static void Main(string[] args)
        {
            // criando uma lista para guardar os numeros
            List<int> numeros = new List<int>();

            // loop pedindo os numeros, o programa encerra quando o usuario digitar 'sair'
            while (true)
            {
                Console.Write("Digite um número inteiro (ou digite 'sair' para encerrar):");
                string input = Console.ReadLine();

                if (input.ToLower() == "sair")
                {
                    break;
                }

                // adiciona os numeros dentro da variavel
                try
                {
                    int num = int.Parse(input);
                    numeros.Add(num);
                }

                // se a pessoa digitar um numero decimal ou string
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                }
            }

            //pesquisei como filtrar os numeros positivos no chatbotgpt e fiz esse filtro para numeros positivos
            List<int> numerosPositivos = numeros.Where(n => n > 0).ToList();

            if (numerosPositivos.Count > 0)
            {

                // exibindo os numeros positivos
                Console.WriteLine("Números positivos:");
                foreach (int numero in numerosPositivos)
                {
                    Console.WriteLine(numero);
                }
            }
            else
            {
                // quando nao ha numeros positivos
                Console.WriteLine("Não há números positivos.");
            }

        }
    }
}
