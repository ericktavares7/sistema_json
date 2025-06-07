using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;

namespace Cadastro;

public class Pessoa
{
    public string nome { get; set; }
    public int idade { get; set; }
    public string profissao { get; set; }
    public string status { get; set; }
    public string cpf { get; set; }
}
public class Program
{
    public static void Main(string[] args)
    {
        List<Pessoa> pessoas = new List<Pessoa>();


        while (true)
        {
            Console.WriteLine("========MENU PRINCIPAL========\n");
            Console.WriteLine("1 - Cadastrar pessoa");
            Console.WriteLine("2 - Listar pessoas cadastradas");
            Console.WriteLine("3- Procurar pessoas por CPF");
            Console.WriteLine("4 - Sair\n");
            string opcao = Console.ReadLine();
             
            switch (opcao)
            {
                case "1":
                    Pessoa novaPessoa = IniciarCadastro(pessoas);
                    if (novaPessoa != null)
                        pessoas.Add(novaPessoa); // Adiciona a nova pessoa à lista
                    break;
                case "2":
                    Console.WriteLine("\n========Lista de pessoas cadastradas==========");
                    foreach (var p in pessoas)
                    {
                        Console.WriteLine($"\nNome: {p.nome}, Idade: {p.idade}, CPF: {p.cpf}, Profissão: {p.profissao}, Status: {p.status}");
                    }
                    break;
                case "3":
                    Console.WriteLine("\n========Procurar pessoa por CPF==========");
                    string cpfProcurado = Console.ReadLine();
                    var pessoaEncontrada = pessoas.FirstOrDefault(p => p.cpf == cpfProcurado);
                    if (pessoaEncontrada != null)
                    {
                        Console.WriteLine($"\nPessoa encontrada: Nome: {pessoaEncontrada.nome}, Idade: {pessoaEncontrada.idade}, CPF: {pessoaEncontrada.cpf}, Profissão: {pessoaEncontrada.profissao}, Status: {pessoaEncontrada.status}");
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma pessoa encontrada com esse CPF.");
                    }

                    break;

                case "4":
                    Console.WriteLine("Saindo do programa...");
                    return;
                    break;



            }

            Console.WriteLine("Deseja voltar ao menu? (s/n)");
            string continuar = Console.ReadLine();
            if (continuar.ToLower() != "s")
                break;
            Console.Clear();
        }

    }

    static Pessoa IniciarCadastro(List<Pessoa> pessoas)
    {
        string nome = "";
        int idade = 0;
        string profissao = "";
        string cpf = "";

        Console.WriteLine("========Cadastro de nome e Profissão=======\n");

        // Nome
        while (true)
        {
            Console.Write("\nDigite seu nome: ");
            nome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nome))
                break;

            Console.WriteLine("Nome inválido. Por favor, digite um nome válido, digite novamente.\n");
        }

        // CPF
        while (true)
        {
            Console.Write("\nDigite seu CPF (somente números): ");
            cpf = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(cpf))
            {
                Console.WriteLine("CPF inválido. Por favor, digite um CPF válido (somente números).");
                continue;
            }
            if (pessoas.Any(p => p.cpf == cpf))
            {
                Console.WriteLine("CPF já cadastrado. Cadastro Cancelado");
                return null;
            }
            break;

        }

        // Idade
        while (true)
        {
            Console.WriteLine("\nDigite sua idade: ");
            bool idadeValida = int.TryParse(Console.ReadLine(), out idade);
            if (idadeValida)
                break;
            Console.WriteLine("Idade inválida. Por favor, digite um número novamente.");
        }

        // Profissão
        while (true)
        {
            Console.WriteLine("\nDigite sua profissão: ");
            profissao = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(profissao))
                break;

            Console.WriteLine("Profissão inválida. Por favor, digite uma profissão válida.");
        }

        string status = idade >= 18
            ? "Apto para contratações."
            : "Menor de idade - contratação não permitida.";

        Console.WriteLine("\n======= Resultado do Cadastro =======");
        Console.WriteLine($"\nNOME: [{nome}]");
        Console.WriteLine($"IDADE: [{idade}]");
        Console.WriteLine($"CPF: [{cpf}]");
        Console.WriteLine($"PROFISSÃO: [{profissao}]");
        Console.WriteLine($"STATUS: [{status}]");

        return new Pessoa
        {
            nome = nome,
            idade = idade,
            profissao = profissao,
            status = status,
            cpf = cpf // Adicionado o CPF corretamente
        };
    }
}