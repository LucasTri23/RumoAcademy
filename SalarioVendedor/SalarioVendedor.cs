namespace SalarioVendedor
{
    class SalarioVendedor
    {
        static void Main(string[] args)
        {
            string nome;
            double salarioFixo, totalVendas, comissao, salarioFinal;

            Console.Write("Insira o nome do vendedor: ");
            nome = Console.ReadLine();

            Console.Write("Insira o salário fixo do vendedor: ");
            salarioFixo = double.Parse(Console.ReadLine());

            Console.Write("Insira o total de vendas efetuadas pelo vendedor no mês: ");
            totalVendas = double.Parse(Console.ReadLine());

            comissao = totalVendas * 0.15;

            salarioFinal = salarioFixo + comissao;

            Console.WriteLine("O vendedor {0} tem um salário fixo de R${1:C} e um salário final de R${2:C} no mês.", nome, salarioFixo, salarioFinal);
        }

    }
}
