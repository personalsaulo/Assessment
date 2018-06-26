using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Agenda
    {
        private List<Pessoa> agenda = new List<Pessoa>();

        public Agenda()
        {
            agenda = new List<Pessoa>();
        }

        public int ObterQuantidadeDePessoas()
        {
            return agenda.Count();
        }


        public void Adicionar(Pessoa pessoa)
        {
            agenda.Add(pessoa);
        }

        public void Atualizar(Pessoa pessoaComAlteracao)
        {
            for (int i = 0; i < agenda.Count; i++)
            {
                if (agenda[i].id == pessoaComAlteracao.id)
                    agenda.RemoveAt(i);
            }

            agenda.Add(pessoaComAlteracao);

            //Pessoa pessoaOriginal = null;
            //for (int i = 0; i < agenda.Count; i++)
            //{
            //    if (agenda[i].id == pessoaComAlteracao.id)
            //        pessoaOriginal = agenda[i];
            //}

            //if (pessoaOriginal == null)
            //    return;

            //agenda.Remove(pessoaOriginal);

            //agenda.Add(pessoaComAlteracao);
        }

        public void Remover(Guid id)
        {
            for (int i = 0; i < agenda.Count; i++)
            {
                if (agenda[i].id == id)
                    agenda.RemoveAt(i);
            }
        }

        public List<Pessoa> ObterTodasAsPessoas()
        {
            return agenda;
        }


        public Pessoa BuscaPorNome(string nome)
        {
            for (int i = 0; i < agenda.Count; i++)
            {
                if (agenda[i].Nome.Contains(nome))
                    return agenda[i];
            }
            return null;
        }

        public Pessoa BuscarPessoaPorData(DateTime dataNascimento)
        {
            for (int i = 0; i < agenda.Count; i++)
            {
                if (agenda[i].DataDeNascimento == dataNascimento)
                    return agenda[i];
            }
            return null;
        }


        //public List<Pessoa> BuscaPessoasPorNome(string nome)
        //{
        //    List<Pessoa> pessoasComMesmoNome = new List<Pessoa>();
        //    for (int i = 0; i < agenda.Count; i++)
        //    {
        //        if (agenda[i].Nome.Contains(nome))
        //            pessoasComMesmoNome.Add(agenda[i]);
        //    }
        //    return pessoasComMesmoNome;
        //}

    }

}
