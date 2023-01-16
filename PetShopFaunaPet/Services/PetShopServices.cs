using PetShopFaunaPet.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetShopFaunaPet.Services
{
    internal class PetShopServices
    {
        private readonly Repositorios.PetShopRepositorio _repositorio;

        public PetShopServices()
        {
            _repositorio = new Repositorios.PetShopRepositorio();
        }

        public void Perguntar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("O que você deseja fazer ?");
                Console.WriteLine("1. Listar Clientes");
                Console.WriteLine("2. Cadastrar Cliente");
                var resposta = Console.ReadLine();
                Console.Clear();

                switch (resposta)
                {
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Cadastrar();
                        break;
                    default:
                        Console.Write("Selecione uma opção valida!");
                        break;
                }
            }
        }

        public void AdicionarMascaraCPF(string cpf)
        {
            
        }

        private void Cadastrar()
        {
            var cliente = ColetarDadosCliente();
            if (cliente is null)
                return;

            _repositorio.Inserir(cliente);

            Console.WriteLine($"{cliente.Nome} cadastrado com sucesso!");
            Console.WriteLine($"Aperte uma tecla para prosseguir!");
            Console.ReadKey();
        }

        private void Listar()
        {
            var cliente = _repositorio.Listar();
            Console.WriteLine("Deseja também listar os aniversariantes do mês? S/N");
            if (Console.ReadLine() == "S")
                cliente = cliente.Where(x => x.DataDeNascimento.Month == DateTime.Now.Month == true).ToList();
            Console.Clear();

            foreach(var c in cliente)
            {
                Console.WriteLine($"Nome => {c.Nome} ;CPF => {c.CPF}; DataDeNascimento => {c.DataDeNascimento}");
            }

            Console.WriteLine("Para sair da listagem aperte qualquer tecla!");
            Console.ReadKey();
        }

        private Clientes? ColetarDadosCliente()
        {
            Console.WriteLine("Qual o nome do cliente que você deseja cadastrar? ");
            var nomeCliente = Console.ReadLine();
            if (!Utility.Validacoes.ValidarTamanhoTexto(nomeCliente, 3, 80))
            {
                Console.WriteLine("O nome do cliente pode ter no minimo 3 letras e no maximo 80");
                Console.ReadKey();
                return null;
            }

            Console.WriteLine($"Qual o CPF do {nomeCliente}?");
            var cpf = (Console.ReadLine());

            //tentei mascarar e nao consegui
            if (!Utility.Validacoes.ValidarTamanhoTexto(cpf, 11, 11) || !Regex.IsMatch(cpf, @"^[0-9]+$"))
            {
                Console.WriteLine("CPF invalido!");
                Console.ReadKey();
                return null;
            }

            

            Console.WriteLine($"Qual a data de nascimento do {nomeCliente}?");
            var data = Console.ReadLine();

            if (!Utility.Validacoes.ValidarSeDataBrasileiraEIdade(data))
            {
                Console.WriteLine("O cliente tem que ter entre 16 e 120 anos de idade!");
                Console.ReadKey();
                return null;
            }

            DateTime dataNascimento = DateTime.ParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            // tentei colocar a validação de cpf mas nao entendi muito


            /*int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            if (!cpf.EndsWith(digito))
                return false;
            cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");*/



            return new Clientes()
            {
                Nome = nomeCliente,
                CPF = cpf,
                DataDeNascimento = dataNascimento
            };
        }
    }
}
