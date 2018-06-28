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
                {
                    agenda[i].DiasParaOAniversario =  CalculaQuantosDiasFaltamParaAniversario(agenda[i].DataDeNascimento);
                    return agenda[i];
                    
                }
                    
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

        public Pessoa VerificaSeTemAniversarioHoje()
        {
            for (int i = 0; i < agenda.Count; i++)
            {
                if (agenda[i].DataDeNascimento.Day == DateTime.Now.Day && agenda[i].DataDeNascimento.Month == DateTime.Now.Month)
                    return agenda[i];
            }
            return null;
        }

        public int CalculaQuantosDiasFaltamParaAniversario(DateTime dataDeAniversario)
        {
            int dias = 0;
            int diferencaDeAnos = DateTime.Now.Year - dataDeAniversario.Year;

            bool maiorqMesAtual = DateTime.Now.Month < dataDeAniversario.Month;
            int diaDoAnoDoAniversario = dataDeAniversario.AddYears(diferencaDeAnos).DayOfYear;
            int diadoAnoAtual = DateTime.Now.DayOfYear;


            if (maiorqMesAtual)
                dias = diaDoAnoDoAniversario - diadoAnoAtual;
            else
            {
                int anoQueVem = diferencaDeAnos + 1;
                TimeSpan diaAniversarioProximoAno = dataDeAniversario.AddYears(anoQueVem).Subtract(DateTime.Now);
                dias = diaAniversarioProximoAno.Days;
            }
            return dias;
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
