using Modelo;
using System;
using System.Collections.Generic;


namespace Persistencia
{
   public class AgendaRepositorio
    {
        public void GravarAgendaEmArquivo(Agenda agenda, string caminhoArquivo)
        {
            //crio e substituo o arquivo
            var arquivo = new System.IO.StreamWriter(caminhoArquivo);

            //obtenho a lista de pessoas da agenda
            List<Pessoa> pessoasdaAgenda = agenda.ObterTodasAsPessoas();

            //escrevo no arquivo
            for (int i = 0; i < pessoasdaAgenda.Count; i++)
            {
                arquivo.WriteLine(pessoasdaAgenda[i].id);
                arquivo.WriteLine(pessoasdaAgenda[i].Nome);
                arquivo.WriteLine(pessoasdaAgenda[i].Sobrenome);
                arquivo.WriteLine(pessoasdaAgenda[i].DataDeNascimento);
            }

            //fecho o arquivo
            arquivo.Close();
        }

        public Agenda ObterAgendaDeArquivo(string caminhoDoArquivo)
        {
            //agenda q será retornada
            Agenda agenda = new Agenda();

            var arquivo = new System.IO.StreamReader(caminhoDoArquivo);
            while (!arquivo.EndOfStream)
            {
                Pessoa pessoa = new Pessoa();
                pessoa.id = Guid.Parse(arquivo.ReadLine());
                pessoa.Nome = arquivo.ReadLine();
                pessoa.DataDeNascimento = DateTime.Parse(arquivo.ReadLine());
                agenda.Adicionar(pessoa);
            }
            arquivo.Close();

            return agenda
        }
    }
}
