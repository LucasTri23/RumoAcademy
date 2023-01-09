namespace NumerosPositivos
{
    class Exercicio
    {
        static void Main(string[] args)
        {
            int numeros;

            for (int i = 0; i < 15; i++)
            {
                Console.Write("Insira um numero: ");
                numeros = int.Parse(Console.ReadLine());

                if (numeros > 0)
                {
                    Console.WriteLine(numeros + " Positivo!");
                }

                else if (numeros < 0)
                {
                    Console.WriteLine(numeros + " Negativo!");
                }

            }

        }
    }
}
