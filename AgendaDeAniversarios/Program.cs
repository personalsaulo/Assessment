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
            const string caminhoArquivo = @"C:\Users\saulo\source\repos\Assessment\Agenda.txt";
            Pessoa pessoa = agenda.VerificaSeTemAniversarioHoje();

            if (pessoa != null)
                Console.WriteLine("Hoje é aniversário de :" + pessoa.Nome + ", " + pessoa.Sobrenome + ", " + pessoa.DataDeNascimento);

            do
            {
                
                Console.WriteLine("1 - Adicionar Pessoa");
                Console.WriteLine("2 - Remover Pessoa"); 
                Console.WriteLine("3 - Obter Pessoa");
                Console.WriteLine("4 - Atualizar Pessoa");
                Console.WriteLine("5 - Buscar Pessoas");
                Console.WriteLine("6 - Carregar Agenda de arquivos");
                Console.WriteLine("7 - Gravar agenda em arquivo");
                Console.WriteLine("8 - Abrir o arquivo em notepad");
                Console.WriteLine("9 - Sair");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        AdicionarPessoa(agenda);
                        break;
                    case 2:
                        RemoverPessoas(agenda);
                        break;
                    case 3:
                        AtualizarPessoa(agenda);
                        break;
                    case 4:
                        ObterPessoas(agenda);
                        break;
                    case 5:
                        BuscarPessoaPorNome(agenda);
                        break;
                    case 6:
                        agenda = agendaRepositorio.ObterAgendaDeArquivo(caminhoArquivo);
                        Console.WriteLine("Agenda Carregada com sucesso");
                        break;
                    case 7:
                        agendaRepositorio.GravarAgendaEmArquivo(agenda, caminhoArquivo);
                        break;
                    case 8:
                        Console.Clear();
                        System.Diagnostics.Process.Start(caminhoArquivo);
                        Console.WriteLine("Arquivo texto aberto");
                        break;
                    default:
                        break;
                }





            } while (opcao <=8);

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

        static void RemoverPessoas(Agenda agenda)
        {
            Console.WriteLine("Digite o nome da pessoa: ");
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
            Console.WriteLine("Preparando para remover");
            agenda.Remover(pessoa.id);
        }


        static void AtualizarPessoa(Agenda agenda)
        {
            Pessoa pessoa = BuscarPessoaPorNome(agenda);

            if(pessoa != null)
            {
                Console.WriteLine("Pessoa encontrada");
                Console.WriteLine( "Nome Atual: " + pessoa.Nome +", Escreva o novo nome:");
                pessoa.Nome = Console.ReadLine();
                Console.WriteLine("Sobrenome Atual: " + pessoa.Sobrenome + ", Escreva o novo SobreNome:");
                pessoa.Sobrenome = Console.ReadLine();
                Console.WriteLine("Nome Atual: " + pessoa.DataDeNascimento + ", Escreva o novo nome:");
                pessoa.DataDeNascimento = DateTime.Parse(Console.ReadLine());
                agenda.Atualizar(pessoa);
            }

            Console.WriteLine("Nome não encontrado");
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

        public static Pessoa BuscarPessoaPorNome(Agenda agenda)
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
            Console.WriteLine("Faltam, " + pessoa.DiasParaOAniversario + " dias para o aniversario");

            return pessoa;
        }
    }
}
