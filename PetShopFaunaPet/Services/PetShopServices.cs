using PetShopFaunaPet.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
                Console.WriteLine("3. Atualizar Cliente");
                Console.WriteLine("4. Remover Cliente");
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
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                        Remover();
                        break;
                    default:
                        Console.Write("Selecione uma opção valida!");
                        break;
                }
            }
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
            if (Console.ReadLine() == "N")
                cliente = cliente.Where(x => x.DataDeNascimento.Month == DateTime.Now.Month == true).ToList();
            Console.Clear();

            foreach(var c in cliente)
            {
                Console.WriteLine($"Indentificador => {c.IdCliente};Nome =>{c.Nome};CPF =>{c.CPF}; DataDeNascimento => {c.DataDeNascimento}");
            }

            Console.WriteLine("Para sair da listagem aperte qualquer tecla!");
            Console.ReadKey();
        }

        private void Atualizar()
        {
            var identificador = PerguntarId("atualizar");
            if (!identificador.HasValue)
                return;

            var cliente = ColetarDadosCliente();
            if (cliente is null)
                return;

            cliente.IdCliente = identificador.Value;
            _repositorio.Atualizar(cliente);
        }

        private void Remover()
        {
            var indentificador = PerguntarId("desativar");
            if (indentificador.HasValue)
                return;
            _repositorio.Desativar(indentificador.Value);
        }

        private Clientes? ColetarDadosCliente()
        {
            Console.WriteLine("Qual o nome do cliente que você deseja cadastrar? ");
            var nomeCliente = Console.ReadLine();
            if (!Utility.Validacoes.ValidarTamanhoTexto(nomeCliente, 3, 80));
            {
                Console.WriteLine("O nome do cliente pode ter no minimo 3 letras e no maximo 80");
                Console.ReadKey();
                return null;
            }

            Console.WriteLine($"Qual o CPF do cliente {nomeCliente}");
            var cpf = Console.ReadLine();

            Console.WriteLine($"Qual a data de nascimento do cliente {nomeCliente}");
            var data = Console.ReadLine();

            if (!Utility.Validacoes.ValidarSeDataBrasileiraEIdade(data))
            {
                Console.WriteLine("O cliente tem que ter entre 16 e 120 anos de idade!");
                Console.ReadKey();
                return null;
            }

            DateTime dataNascimento = DateTime.ParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return new Clientes()
            {
                Nome = nomeCliente,
                CPF = cpf,
                DataDeNascimento = dataNascimento
            };
        }


        private int? PerguntarId(string nomeAcao)
        {
            Console.WriteLine($"Por favor digite o id do cliente para {nomeAcao}?");
            string indentificadorString = Console.ReadLine();

            if(int.TryParse(indentificadorString, out int id))
            {
                return id;
            }
            else
            {
                Console.WriteLine("O id informado não é valido");
                Console.ReadKey();
                return null;
            }

            var idInformado = Convert.ToInt32(indentificadorString);
            if (!_repositorio.SeExiste(idInformado))
            {
                Console.WriteLine("Este cliente não existe, tente novamente!");
                Console.ReadKey();
                return null;
            }
            else
            {
                return idInformado;
            }

        }
    }
}
