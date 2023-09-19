using BibliotecaUteis.Classes;
using BibliotecaUteis.ViewModel;

namespace BibliotecaUteis.Controller
{
    public class ResultadosController
    {
        public async Task<bool> InsertConsurso(resultadosviewmodel concurso)
        {
            try
            {
                var query = SqlQueryExtension.GetQuery("InserirResultados.sql")
                    .Replace("@codigoconcurso", concurso.codigoconcurso.ToString().Trim())
                    .Replace("@dataconcurso", concurso.dataconcurso.ToString().Trim())
                    .Replace("@tipojogo", concurso.tipojogo.Trim())
                    .Replace("@result01", concurso.result01.ToString().Trim())
                    .Replace("@result02", concurso.result02.ToString().Trim())
                    .Replace("@result03", concurso.result03.ToString().Trim())
                    .Replace("@result04", concurso.result04.ToString().Trim())
                    .Replace("@result05", concurso.result05.ToString().Trim())
                    .Replace("@result06", concurso.result06.ToString().Trim())
                    .Replace("@result07", concurso.result07.ToString().Trim())
                    .Replace("@result08", concurso.result08.ToString().Trim())
                    .Replace("@result09", concurso.result09.ToString().Trim())
                    .Replace("@result10", concurso.result10.ToString().Trim())
                    .Replace("@result11", concurso.result11.ToString().Trim())
                    .Replace("@result12", concurso.result12.ToString().Trim())
                    .Replace("@result13", concurso.result13.ToString().Trim())
                    .Replace("@result14", concurso.result14.ToString().Trim())
                    .Replace("@result15", concurso.result15.ToString().Trim())
                    .Replace("@result16", concurso.result16.ToString().Trim())
                    .Replace("@result17", concurso.result17.ToString().Trim())
                    .Replace("@result18", concurso.result18.ToString().Trim())
                    .Replace("@result19", concurso.result19.ToString().Trim())
                    .Replace("@result20", concurso.result20.ToString().Trim())
                    .Replace("@result21", concurso.result21.ToString().Trim())
                    .Replace("@result22", concurso.result22.ToString().Trim())
                    .Replace("@result23", concurso.result23.ToString().Trim())
                    .Replace("@result24", concurso.result24.ToString().Trim())
                    .Replace("@result25", concurso.result25.ToString().Trim())
                    .Replace("@numganhadorespricipal", concurso.numganhadorespricipal.ToString().Trim())
                    .Replace("@cidadeufprincipal", concurso.cidadeufprincipal.Trim())
                    .Replace("@rateioprincipal", concurso.rateioprincipal.Trim())
                    .Replace("@numganhadores02", concurso.numganhadores02.ToString().Trim())
                    .Replace("@rateio02", concurso.rateio02.Trim())
                    .Replace("@numganhadores03", concurso.numganhadores03.ToString().Trim())
                    .Replace("@rateio03", concurso.rateio03.Trim())
                    .Replace("@acumulado", concurso.acumulado.Trim())
                    .Replace("@arrecadacao", concurso.arrecadacao.Trim())
                    .Replace("@estimativa", concurso.estimativa.Trim())
                    .Replace("@acumuladosorteioespecial", concurso.acumuladosorteioespecial.Trim())
                    .Replace("@observacao", concurso.observacao.Trim());

                return await ExecutaSQLCadastroConcurso(query);
            }
            catch (Exception ex)
            {
                ClsLog.FU_Escreve_Log("InsertConsursoMega", ex.Message);
                return false;
            }
        }

        public async Task<bool> ExecutaSQLCadastroConcurso(string QuerieLinkAPI)
        {
            var cmd = DalHelper.DbConnection().CreateCommand();
            try
            {
                {
                    cmd.Connection.Open();
                    cmd.CommandText = QuerieLinkAPI;
                    var da = cmd.ExecuteNonQueryAsync().IsCompleted;
                    cmd.Connection.Dispose();
                    return da;

                }
            }
            catch (Exception ex)
            {
                ClsLog.FU_Escreve_Log("ExecutaSQLCadastro", ex.Message);
                return false;
            }
            finally
            {
                cmd.Connection.Dispose();
            }
            return true;
        }
    }
}

