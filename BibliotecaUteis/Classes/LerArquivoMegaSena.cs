using BibliotecaUteis.Controller;
using BibliotecaUteis.ViewModel;

namespace BibliotecaUteis.Classes
{
    public class LerArquivoMegaSena
    {
        public async Task<string> LerArquivoCSVMega(string arquivocsv)
        {
            string linha = string.Empty;
            string retorno = string.Empty;
            int contagem = 0;
            try
            {
                if (!File.Exists(arquivocsv))
                    return null;
                var lista = new List<resultadosviewmodel>();
                using (var reader = new StreamReader(arquivocsv))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (line.Contains("Concurso"))
                            continue;
                        linha = line;
                        contagem++;
                        var resultado = new resultadosviewmodel();
                        var values = line.Split('¥');

                        if (values.Count() < 20)
                            continue;

                        resultado.codigoconcurso = String.IsNullOrEmpty(values[0].Trim()) ? 0 : Convert.ToInt32(values[0].Trim());
                        resultado.dataconcurso = String.IsNullOrEmpty(values[1].Trim()) ? DateTime.Now : Convert.ToDateTime(values[1].Trim());
                        resultado.tipojogo = "MEGASENA";
                        resultado.result01 = String.IsNullOrEmpty(values[2].Trim()) ? 0 : Convert.ToInt32(values[2].Trim());
                        resultado.result02 = String.IsNullOrEmpty(values[3].Trim()) ? 0 : Convert.ToInt32(values[3].Trim());
                        resultado.result03 = String.IsNullOrEmpty(values[4].Trim()) ? 0 : Convert.ToInt32(values[4].Trim());
                        resultado.result04 = String.IsNullOrEmpty(values[5].Trim()) ? 0 : Convert.ToInt32(values[5].Trim());
                        resultado.result05 = String.IsNullOrEmpty(values[6].Trim()) ? 0 : Convert.ToInt32(values[6].Trim());
                        resultado.result06 = String.IsNullOrEmpty(values[7].Trim()) ? 0 : Convert.ToInt32(values[7].Trim());
                        resultado.numganhadorespricipal = String.IsNullOrEmpty(values[8].Trim()) ? 0 : Convert.ToInt32(values[8].Trim());
                        resultado.cidadeufprincipal = String.IsNullOrEmpty(values[9].Trim()) ? "" : values[9].Trim();
                        resultado.rateioprincipal = String.IsNullOrEmpty(values[10].Trim()) ? "0" : values[10].Trim();
                        resultado.numganhadores02 = String.IsNullOrEmpty(values[11].Trim()) ? 0 : Convert.ToInt32(values[11].Trim());
                        resultado.rateio02 = String.IsNullOrEmpty(values[12].Trim()) ? "0" : values[12].Trim();
                        resultado.numganhadores03 = String.IsNullOrEmpty(values[13].Trim()) ? 0 : Convert.ToInt32(values[13].Trim());
                        resultado.rateio03 = String.IsNullOrEmpty(values[14].Trim()) ? "0" : values[14].Trim();
                        resultado.acumulado = String.IsNullOrEmpty(values[15].Trim()) ? "0" : values[15].Trim();
                        resultado.arrecadacao = String.IsNullOrEmpty(values[16].Trim()) ? "0" : values[16].Trim();
                        resultado.estimativa = String.IsNullOrEmpty(values[17].Trim()) ? "0" : values[17].Trim();
                        resultado.acumuladosorteioespecial = String.IsNullOrEmpty(values[18].Trim()) ? "0" : values[18].Trim();
                        resultado.observacao = String.IsNullOrEmpty(values[19].Trim()) ? "" : values[19].Trim();

                        lista.Add(resultado);
                    }
                }
                if (lista.Count > 0)
                {
                    MegaSenaController megaSenaController = new MegaSenaController();
                    var ret = await megaSenaController.InsertConcursoMega(lista);
                    if (ret.Item1 > 0)
                        retorno = $"{ret.Item1} Registros inseridos com sucesso!!";
                    if (ret.Item2 > 0)
                        if (String.IsNullOrEmpty(retorno))
                            retorno = $"{ret.Item1} Registros inseridos com ERRO!!";
                        else
                            retorno = $"\r\n{ret.Item1} Registros inseridos com ERRO!!";
                }
                return retorno;
            }
            catch (Exception ex)
            {
                ClsLog.FU_Escreve_Log("LerArquivoCSVMega", ex.Message + $"|{contagem}|{linha}");
                return retorno + "\r\n" + ex.Message;
            }
        }
    }
}
