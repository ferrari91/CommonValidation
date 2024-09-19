namespace CommonValidation.Documents.UnidadeFederativa
{
    public class UFFormattingService
    {
        private static readonly Dictionary<string, string> UfMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "AC", "Acre" },
            { "AL", "Alagoas" },
            { "AM", "Amazonas" },
            { "AP", "Amapá" },
            { "BA", "Bahia" },
            { "CE", "Ceará" },
            { "DF", "Distrito Federal" },
            { "ES", "Espírito Santo" },
            { "GO", "Goiás" },
            { "MA", "Maranhão" },
            { "MG", "Minas Gerais" },
            { "MS", "Mato Grosso do Sul" },
            { "MT", "Mato Grosso" },
            { "PA", "Pará" },
            { "PB", "Paraíba" },
            { "PE", "Pernambuco" },
            { "PI", "Piauí" },
            { "PR", "Paraná" },
            { "RJ", "Rio de Janeiro" },
            { "RN", "Rio Grande do Norte" },
            { "RO", "Rondônia" },
            { "RR", "Roraima" },
            { "RS", "Rio Grande do Sul" },
            { "SC", "Santa Catarina" },
            { "SE", "Sergipe" },
            { "SP", "São Paulo" },
            { "TO", "Tocantins" }
        };

        public string ExtractSigla(string uf)
        {
            return UfMap.ContainsKey(uf.ToUpper()) ? uf.ToUpper() : string.Empty;
        }

        public string GetEstadoBySigla(string sigla)
        {
            UfMap.TryGetValue(sigla.ToUpper(), out var estado);
            return estado;
        }

        public string GetSiglaByEstado(string estado)
        {
            foreach (var pair in UfMap)
            {
                if (string.Equals(pair.Value, estado, StringComparison.OrdinalIgnoreCase))
                {
                    return pair.Key;
                }
            }

            return string.Empty;
        }

        public bool IsValidUF(string uf) =>
             UfMap.ContainsKey(uf.ToUpper());

        public bool IsValidEstado(string estado) =>
            UfMap.Values.Any(v => string.Equals(v, estado, StringComparison.OrdinalIgnoreCase));
    }
}
