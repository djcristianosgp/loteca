using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUteis.Classes
{
    public  class ClsLog
    {
        public static string sArquivoLog = ClsUteis.sArquivoLog;
        public static void FU_Escreve_Log(string sFonte, string sTexto)
        {
            sTexto = sTexto.Replace("\r", " ").Replace("\n", " ");
            if (!File.Exists(sArquivoLog))
            {
                StreamWriter sArquivo = new StreamWriter(sArquivoLog);
                sArquivo.WriteLine(DateTime.Now.ToString() + "|" + sFonte + "|" + sTexto);
                sArquivo.Close();
            }
            else
            {
                StreamWriter sArquivo = File.AppendText(sArquivoLog);
                sArquivo.WriteLine(DateTime.Now.ToString() + "|" + sFonte + "|" + sTexto);
                sArquivo.Close();
            }
        }
    }
}
