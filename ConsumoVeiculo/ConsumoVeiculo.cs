using System;

namespace ConsumoVeiculo
{
    class ConsumoVeiculo
    {
        static void Main(string[] args)
        {
            // Declaração de variáveis
            double kmPercorridos, litrosConsumidos, consumo, distanciaMaxima;

            Console.Write("Insira a quantidade de quilômetros percorridos: ");
            kmPercorridos = double.Parse(Console.ReadLine());

            Console.Write("Insira a quantidade de litros consumidos: ");
            litrosConsumidos = double.Parse(Console.ReadLine());

            consumo = litrosConsumidos / kmPercorridos;

            Console.WriteLine("O consumo do veículo é de {0:F2} litros por quilômetro.", consumo);

            Console.Write("Insira a capacidade do tanque de combustível: ");
            double capacidadeTanque = double.Parse(Console.ReadLine());

            distanciaMaxima = capacidadeTanque / consumo;

            Console.WriteLine("A distância máxima que o veículo pode percorrer com um abastecimento é de {0:F2} quilômetros.", distanciaMaxima);
        }

    }
}
