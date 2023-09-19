using BibliotecaUteis.Classes;
using BibliotecaUteis.ViewModel;

namespace loteca.View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ler();
        }

        public async void ler()
        {
            LerArquivoMegaSena lerArquivoMegaSena = new LerArquivoMegaSena();
            var teste =  await lerArquivoMegaSena.LerArquivoCSVMega(@"C:\Users\djcri\Downloads\Mega-Sena.csv");
            MessageBox.Show(teste);
        }
    }
}
