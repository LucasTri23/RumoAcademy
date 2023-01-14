using PetShopFaunaPet.Models;
using PetShopFaunaPet.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopFaunaPet.Repositorios
{
    public class PetShopRepositorio
    {
        private readonly string _caminho = "C:\\Projetos\\Database\\produto.csv";
        private List<Clientes> ListagemClientes = new List<Clientes>();
        public PetShopRepositorio()
        {
            if (!File.Exists(_caminho))
            {
                var file = File.Create(_caminho);
                file.Close();   
            }
        }

        public void Inserir(Clientes cliente)
        {
            var indentificador = ProximoIndentificador();

            var sw = new StreamWriter(_caminho, true);
            sw.WriteLine(GerarLinhaCliente(indentificador, cliente));
            sw.Close();
        }

        public List<Clientes> Listar()
        {
            CarregarClientes();
            return ListagemClientes;
        }

        public bool SeExiste(int indentificadorCliente)
        {
            CarregarClientes();
            return ListagemClientes.Any(x => x.IdCliente == indentificadorCliente);
        }

        public void Atualizar(Clientes cliente)
        {
            CarregarClientes();

            var posicao = ListagemClientes.FindIndex(x => x.IdCliente == cliente.IdCliente);
            ListagemClientes[posicao] = cliente;
            RegravarCliente(ListagemClientes);
        }
        
        public void Desativar(int indentificarCliente)
        {
            CarregarClientes();

            var posicao = ListagemClientes.FindIndex(x => x.IdCliente == indentificarCliente);
            ListagemClientes.RemoveAt(posicao);
            RegravarCliente(ListagemClientes);
        }

        private void CarregarClientes()
        {
            ListagemClientes.Clear();
            var sr = new StreamReader(_caminho);
            while (true)
            {
                var linha = sr.ReadLine();

                if (linha == null)
                    break;

                ListagemClientes.Add(LinhaTextoParaClientes(linha));
            }
        } 

        private int ProximoIndentificador()
        {
            CarregarClientes();

            if (ListagemClientes.Count == 0)
                return 1;

            return ListagemClientes.Max(x => x.IdCliente);
        }

        private Clientes LinhaTextoParaClientes(string linha)
        {
            var colunas = linha.Split(';');

            var cliente = new Clientes();
            cliente.IdCliente = int.Parse(colunas[0]);
            cliente.Nome = colunas[1];
            cliente.CPF = colunas[2];
            cliente.DataDeNascimento = DateTime.Parse(colunas[3]);

            return cliente;
        }

        private void RegravarCliente(List<Clientes> clientes)
        {
            var sw = new StreamWriter(_caminho);

            foreach (var cliente in clientes.OrderBy(x => x.IdCliente))
            {
                sw.WriteLine(GerarLinhaCliente(cliente.IdCliente, cliente));
            }

        }

        private string GerarLinhaCliente(int indentificador, Clientes cliente)
        {
            return $"{indentificador};{cliente.Nome};{cliente.CPF};{cliente.DataDeNascimento}";
        }
    }
}
