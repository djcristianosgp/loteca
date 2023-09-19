using BibliotecaUteis.ViewModel;

namespace BibliotecaUteis.Controller
{
    public class MegaSenaController
    {
        public async Task<Tuple<int, int>> InsertConcursoMega(List<resultadosviewmodel> lista)
        {
            var insertResult = new ResultadosController();
            int contadorerro = 0, contadorcerto = 0;
            foreach (var item in lista)
            {
                if (item == null)
                    continue;
                if (!await insertResult.InsertConsurso(item))
                    contadorerro++;
                else
                    contadorcerto++;
            }
            return new Tuple<int, int>(contadorcerto, contadorerro);
        }
    }
}
