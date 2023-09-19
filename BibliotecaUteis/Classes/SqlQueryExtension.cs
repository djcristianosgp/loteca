namespace BibliotecaUteis.Classes
{
    public static class SqlQueryExtension
    {
        public static string GetQuery(string queryName)
        {
            try
            {
                var textQuery = string.Empty;
                var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.FullName.Contains("BibliotecaUteis"));
                var name = assembly.GetManifestResourceNames().FirstOrDefault(x => x.EndsWith(queryName));
                //var names = assembly.GetManifestResourceNames();

                using var stream = assembly.GetManifestResourceStream(name);
                using var reader = new StreamReader(stream);
                textQuery = reader.ReadToEnd();

                return textQuery;
            }
            catch (Exception)
            {
                throw new Exception($"Não foi possível carregar o arquivo: {queryName}");
            }
        }
    }
}
