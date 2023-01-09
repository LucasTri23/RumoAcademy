namespace IdadesExercicio
{
    class Idades
    {
        static void Main(string[] args)
        {
            string nome;
            int idade, maisVelho = 0;
            string nomeMaisVelho = "";

            for (int i = 0; i < 10; i++)
            {
                Console.Write("Insira o nome da pessoa {0}: ", i + 1);
                nome = Console.ReadLine();

                Console.Write("Insira a idade da pessoa {0}: ", i + 1);
                idade = int.Parse(Console.ReadLine());

                if (idade > maisVelho)
                {
                    maisVelho = idade;
                    nomeMaisVelho = nome;
                }
            }

            Console.WriteLine("A pessoa mais velha é {0} com {1} anos de idade.", nomeMaisVelho, maisVelho);
        }
    }
}
