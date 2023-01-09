namespace MediaAlunos
{
    class NotasAlunos
    {
        static void Main(string[] args)
        {
            int numAlunos;
            double nota, somaNotas = 0, media;

            Console.Write("Insira o número de alunos na turma: ");
            numAlunos = int.Parse(Console.ReadLine());

            for (int i = 0; i < numAlunos; i++)
            {
                Console.Write("Insira a nota do aluno {0}: ", i + 1);
                nota = double.Parse(Console.ReadLine());
                somaNotas += nota;
            }

            media = somaNotas / numAlunos;

            Console.WriteLine("A média da turma é: {0:F2}", media);
        }
    }
}
