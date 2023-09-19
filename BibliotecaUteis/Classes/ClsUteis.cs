using BibliotecaUteis.ViewModel;
using Newtonsoft.Json;
using System.Text.Json;

namespace BibliotecaUteis.Classes
{
    public class ClsUteis
    {
        //Pastas
        public static string sPastaPadrao = @"C:\Loteca\Repos\";
        public static string sPastaTMPBI = sPastaPadrao + @"TMPLoteca\";
        public static string sPastaExporta = sPastaPadrao + @"Exportacaoes\";
        public static string sPastaLog = sPastaPadrao + @"Log\";
        public static string sPastaBackup = @"c:\Loteca\Backup\";
        public static string sPastaImagensUsuarios = sPastaPadrao + @"Imagens\Usuario\";

        //urls
        public static string sUrlGetResultados = string.Empty;

        //timers
        public static int TimeLimitePost;
        public static int TimeLimiteGet;
        public static int TimeAutoSaveDashboard;

        public static List<string> lListaPasta = new List<string>()
        {
            sPastaPadrao,
            sPastaExporta,
            sPastaTMPBI,
            sPastaLog,
            sPastaBackup,
            sPastaImagensUsuarios,
        };

        //Arquivos
        public static string sArquivoConfig = sPastaPadrao + "LotecaRepos.dll";
        public static string sArquivoConex = sPastaPadrao + "LotecaCon.dll";
        public static string sArquivoTemp = sPastaPadrao + "LotecaTmp.dll";
        public static string sArquivoLog = sPastaLog + "LotecaRepos" + DateTime.Now.ToString("yyyyMM") + ".Log";
        public static string sArquivoBackup = "Loteca_Repos_Backup_" + DateTime.Now.ToString("ddd") + ".zip";
        public static string sArquivoBDSQQLITE = sPastaPadrao + "BDLoteca.sqlite";
        //public static string sFile = sPastaPadrao + @"TextConfiguracoes.json";

        public static List<string> lListaArquivos = new List<string>()
        {
            sArquivoConfig,
            sArquivoTemp,
            sArquivoLog,
        };

        //Static
        public static string sExecucao = AppDomain.CurrentDomain.BaseDirectory.ToString();
        public static string sEstacao = Environment.MachineName.ToUpper();
        public static Version vVersaoLocal = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;


        public static ConfiguracoesViewModel CarregaConfiguracoes()
        {
            var VRetorno = new ConfiguracoesViewModel();
            if (File.Exists(sArquivoConfig))
            {
                string sTexto = File.ReadAllText(sArquivoConfig);

                var vjson = JsonConvert.DeserializeObject<ConfiguracoesViewModel>(sTexto);
                TimeLimiteGet = vjson == null ? 30000 : vjson.TimeOutGet;
                TimeLimitePost = vjson == null ? 80000 : vjson.TimeOutPost;
                TimeAutoSaveDashboard = vjson == null ? 600000 : vjson.TimeAutoSaveDashboard;
                sUrlGetResultados = vjson == null ? "https://service-indicadores-develop.azurewebsites.net/" : vjson.sUrlGetResultados;

            }
            else
            {
                var vjson = new ConfiguracoesViewModel();
                TimeLimiteGet = vjson.TimeOutGet;
                TimeLimitePost = vjson.TimeOutPost;
                TimeAutoSaveDashboard = vjson.TimeAutoSaveDashboard;
                sUrlGetResultados = vjson.sUrlGetResultados;
            }
            //Preenche Vareável para retorno
            {
                VRetorno.TimeOutGet = TimeLimiteGet;
                VRetorno.TimeOutPost = TimeLimitePost;
                VRetorno.TimeAutoSaveDashboard = TimeAutoSaveDashboard;
                VRetorno.sUrlGetResultados = sUrlGetResultados;
            }

            return VRetorno;
        }

        public static bool SalvarConfiguracoes(ConfiguracoesViewModel configuracoes)
        {
            try
            {
                var Dados = System.Text.Json.JsonSerializer.Serialize(configuracoes, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(sArquivoConfig, Dados);
                return true;
            }
            catch (Exception ex)
            {
                ClsLog.FU_Escreve_Log("SalvarConfiguracoes", ex.Message);
                return false;
            }
        }
    }
}
