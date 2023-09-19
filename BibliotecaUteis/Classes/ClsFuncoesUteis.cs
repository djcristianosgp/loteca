using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUteis.Classes
{
    public class ClsFuncoesUteis
    {
        //Pasta
        public void VerificaPastas()
        {
            var vPastas = ClsUteis.lListaPasta;
            for (int iContador = 0; iContador < vPastas.Count; iContador++)
            {
                if (vPastas[iContador] != String.Empty)
                {
                    if (!Directory.Exists(vPastas[iContador])) Directory.CreateDirectory(vPastas[iContador]);
                }
            }
        }

        //Arquivos
        public void VerificaArquivos()
        {
            var vArquivos = ClsUteis.lListaArquivos;
            for (int iContador = 0; iContador < vArquivos.Count; iContador++)
            {
                if (vArquivos[iContador] != String.Empty)
                {
                    if (!File.Exists(vArquivos[iContador])) File.Create(vArquivos[iContador]);
                }
            }
        }

        public void sEscreveArquivoTMP()
        {
            try
            {
                string sDadosArquivo = File.ReadAllText(ClsUteis.sArquivoTemp.Trim());
                if (sDadosArquivo != ClsUteis.sExecucao && !ClsUteis.sExecucao.ToLower().Contains(@"service\desktop\construtor_devexpress"))
                {
                    if (Directory.Exists(sDadosArquivo)) Directory.Delete(sDadosArquivo, true);
                    File.WriteAllText(ClsUteis.sArquivoTemp, ClsUteis.sExecucao.Trim());
                }
            }
            catch (Exception ex)
            {
                ClsLog.FU_Escreve_Log("sEscreveArquivoTMP", ex.Message);
            }
        }

        public static List<T> ConverterParaLista<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row => {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception)
                        { }
                    }
                }
                return objT;
            }).ToList();
        }
    }
}
