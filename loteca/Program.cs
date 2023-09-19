using BibliotecaUteis.Classes;
using loteca.View;

namespace loteca
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            new ClsFuncoesUteis().VerificaPastas();
            new ClsFuncoesUteis().VerificaArquivos();
            new ClsFuncoesUteis().sEscreveArquivoTMP();
            new DalHelper();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}