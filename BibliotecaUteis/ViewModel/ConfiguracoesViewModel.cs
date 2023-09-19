using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUteis.ViewModel
{
    public class ConfiguracoesViewModel
    {        public int TimeOutGet { get; set; } = 30000;
        public int TimeOutPost { get; set; } = 80000;
        public int TimeAutoSaveDashboard { get; set; } = 600000;
        public string sUrlGetResultados { get; set; } = "https://service-indicadores-develop.azurewebsites.net/";
    }
}
