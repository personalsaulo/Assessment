using Modelo;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeAniversarios
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            Agenda agenda = new Agenda();
            AgendaRepositorio agendaRepositorio = new AgendaRepositorio();
            const string caminhoArquivo = @"";
            do
            {
                Console.WriteLine("1 - Adicionar Pessoa");
                Console.WriteLine("2 - Obter Pessoas");
                Console.WriteLine("3 - Buscar Pessoas");
                Console.WriteLine("4 - Carregar Agenda de arquivos");
                Console.WriteLine("5 - Gravar agenda em arquivo");
                Console.WriteLine("6 - Sair");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        AdicionarPessoa(agenda);
                        break;
                    case 2:
                        ObterPessoas(agenda);
                        break;
                    case 3:
                        BuscarPessoaPorNome(agenda);
                        break;
                    case 4:
                        agenda = agendaRepositorio.ObterAgendaDeArquivo(caminhoArquivo);
                        Console.WriteLine("Agenda Carregada com sucesso");
                        break;
                    case 5:
                        agendaRepositorio.GravarAgendaEmArquivo(agenda, caminhoArquivo);
                        
                    default:
                        break;
                }





            } while (opcao != 6);

        }

        static void AdicionarPessoa(Agenda agenda)
        {
            Console.WriteLine("Digite o nome da pessoa: ");
            string nome = Console.ReadLine();


            Console.WriteLine("Digite o nascimento da pessoa(dd/mm/aaaa:");
            DateTime nascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //crio objeto pessoa
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = nome;
            pessoa.DataDeNascimento = nascimento;
            pessoa.id = Guid.NewGuid();

            agenda.Adicionar(pessoa);
        }

        public static void ObterPessoas(Agenda agenda)
        {
            List<Pessoa> pessoas = agenda.ObterTodasAsPessoas();
            for (int i = 0; i < pessoas.Count; i++)
            {
                Console.WriteLine(pessoas[i].id);
                Console.WriteLine(pessoas[i].Nome);
                Console.WriteLine(pessoas[i].Sobrenome);
                Console.WriteLine(pessoas[i].DataDeNascimento);
                Console.WriteLine();
            }
        }

        public static void BuscarPessoaPorNome(Agenda agenda)
        {

            Console.WriteLine("Digite o  nome da pessoa");
            string nome = Console.ReadLine();
            Pessoa pessoa = agenda.BuscaPorNome(nome);
            if (pessoa == null)
            {
                Console.WriteLine("Pessoa não encontrada");
            }

            Console.WriteLine("Pessoa encontrada");
            Console.WriteLine(pessoa.Nome);
            Console.WriteLine(pessoa.Sobrenome);
            Console.WriteLine(pessoa.DataDeNascimento);
            Console.WriteLine();
        }
    }
}
