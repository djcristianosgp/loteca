using System.Data;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUteis.Classes
{
    public class DalHelper
    {
        public DalHelper()
        {
            CriarBancoSQLite();
            CriarTabelaSQlite();
        }

        public static SQLiteConnection DbConnection()
        {
            SQLiteConnection sqliteConnection = new SQLiteConnection(@$"Data Source={ClsUteis.sArquivoBDSQQLITE}; Version=3;journal mode=WAL;concurrency-max-threads=1;");
            try
            {
                //sqliteConnection.Open();
            }
            catch (Exception ex)
            {
                ClsLog.FU_Escreve_Log("CriarBancoSQLite", ex.Message);
            }
            return sqliteConnection;
        }

        public static void CriarBancoSQLite()
        {
            if (File.Exists(ClsUteis.sArquivoBDSQQLITE))
                return;
            try
            {
                SQLiteConnection.CreateFile(@$"{ClsUteis.sArquivoBDSQQLITE}");
            }
            catch (Exception ex)
            {
                ClsLog.FU_Escreve_Log("CriarBancoSQLite", ex.Message);
            }
        }

        public static void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.Connection.Open();
                    cmd.CommandText = SqlQueryExtension.GetQuery("TabelaResultados.sql");
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = SqlQueryExtension.GetQuery("TabelaJogosDisponiveis.sql");
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = SqlQueryExtension.GetQuery("TabelaMeusJogos.sql");
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ClsLog.FU_Escreve_Log("CriarTabelaSQlite", ex.Message);
            }
        }
    }
}
