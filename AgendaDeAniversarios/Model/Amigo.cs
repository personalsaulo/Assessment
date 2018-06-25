using System;
using System.IO;
using System.Linq;


namespace AgendaDeAniversarios.Model
{
    public class Amigo
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataDeAniversario { get; set; }


        public void CadastrarAniversarios(Amigo amigo)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\saulo\Desktop\Teste.txt"))
            {
                writer.Write(amigo.Nome);
                writer.WriteLine(amigo.Sobrenome);
                writer.WriteLine(amigo.DataDeAniversario);
            }
        }

        public void VerificaSeTemAniversarioHoje()
        {
            //var valores = File.ReadAllLines(@"C: \Users\saulo\Desktop\Teste.txt").Contains(DateTime.Now.ToString("dd MM"));
            var valores = File.ReadAllLines(@"C: \Users\saulo\Desktop\Teste.txt").Where(l => l.Contains(DateTime.Now.ToString("dd MM")));

            foreach (var item in valores)
            {
                Console.WriteLine(item);
            }

            //DateTime dataASerVerificada = Convert.ToDateTime(valores[1]);
            //if (dataASerVerificada.ToString("dd MM") == DateTime.Now.ToString("dd MM"))
            //{

                //string linha;
                //using (StreamReader reader = new StreamReader(@"C: \Users\saulo\Desktop\Teste.txt"))
                //{
                //    while ((linha = reader.ReadLine()) != null)
                //        Console.WriteLine(linha);

                //}
            //}
        }

        public static void ApagarRegistroDeAniversario()
        {
            string[] linhas = File.ReadAllLines(@"C: \Users\saulo\Desktop\Teste.txt");
            //string []arquivo = 


            using (StreamWriter arquivo = new StreamWriter(@"C:\Users\saulo\Desktop\Teste.txt"))
            {
                foreach (string linha in linhas)
                {
                    if (!linha.Contains("Lio"))
                    {
                        arquivo.WriteLine(linha);
                    }

                }
            }

        }

        public static void AtualizarInformacoes()
        {
            string texto = File.ReadAllText(@"C: \Users\saulo\Desktop\Teste.txt");
            texto = texto.Replace("24", "25");
            File.WriteAllText(@"C: \Users\saulo\Desktop\Teste.txt", texto);
        }

        public static void BuscaPessoa(string nome)
        {
            int opcao;
            var valores = File.ReadAllLines(@"C: \Users\saulo\Desktop\Teste.txt");
            for (int i = 0; i < valores.Length; i++)
            {
                if (valores[i].Nome.Contains(nome))
                {
                    Console.WriteLine(i + " - Nome Completo: " + valores[i].Nome + " " + valores[i].Sobrenome);
                }

            }
            opcao = int.Parse(Console.ReadLine());

            for (int i = 0; i < valores.Length; i++)
            {
                if (i == opcao)
                {
                    int dias = CalculaQuantosDiasFaltamParaAniversario(valores[i].DataAniversario);
                    Console.WriteLine(i + " - Nome Completo: " + valores[i].Nome + " " + valores[i].Sobrenome + "\n" + "Faltam: " + dias + " dias para esse aniversário.");
                }
            }

        }

        private static int CalculaQuantosDiasFaltamParaAniversario(DateTime dataDeAniversario)
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
    }
}
