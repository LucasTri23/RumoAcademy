using System;

namespace LucroExercicio4
{
    class LucrosSoma
    {
        static void Main(string[] args)
        {
            string nomeProduto;
            int quantidade, precoCompra, precoVenda;
            double lucroTotal = 0;

            do
            {
                Console.Write("Insira o nome do produto (digite 'sair' para parar): ");
                nomeProduto = Console.ReadLine();

                if (nomeProduto == "sair")
                {
                    break;
                }

                Console.Write("Insira a quantidade vendida: ");
                quantidade = int.Parse(Console.ReadLine());

                Console.Write("Insira o preço de compra: ");
                precoCompra = int.Parse(Console.ReadLine());

                Console.Write("Insira o preço de venda: ");
                precoVenda = int.Parse(Console.ReadLine());

                // Calcular o lucro e adicionar ao lucro total
                double lucro = (precoVenda - precoCompra) * quantidade;
                lucroTotal += lucro;

                // usei o do while porque pesquisei e mesmo que que a condição seja falsa o programa vai rodar já com o while nao acontece isso
                // depende das condições. Por exemplo, você poderia usar um loop "do while" para criar um menu de opções para o usuário
                // e continuar solicitando a entrada do usuário até que ele digite uma opção válida.

            } while (true);

            Console.WriteLine("O lucro total é: {0:F2}", lucroTotal);
        }
    }
}
