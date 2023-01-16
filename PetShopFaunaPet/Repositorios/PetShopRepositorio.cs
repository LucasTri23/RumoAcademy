using PetShopFaunaPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopFaunaPet.Repositorios
{
    public class PetShopRepositorio
    {
        private readonly string _caminho = "C:\\Projetos\\DataBase\\clientes.csv";
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
            var sw = new StreamWriter(_caminho, true);
            sw.WriteLine(GerarLinhaCliente(cliente));
            sw.Close();
        }

        public List<Clientes> Listar()
        {
            CarregarClientes();
            return ListagemClientes;
        }

        public bool SeExiste(string indentificadorCliente)
        {
            CarregarClientes();
            return ListagemClientes.Any(x => x.CPF == indentificadorCliente);
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

            sr.Close();
        } 

        private Clientes LinhaTextoParaClientes(string linha)
        {
            var colunas = linha.Split(';');

            var cliente = new Clientes();
            cliente.Nome = colunas[0];
            cliente.CPF = (colunas[1]);
            cliente.DataDeNascimento = DateTime.Parse(colunas[2]);

            return cliente;
        }

        private string GerarLinhaCliente(Clientes cliente)
        {
            return $"{cliente.Nome};{cliente.CPF};{cliente.DataDeNascimento}";
        }
    }
}
