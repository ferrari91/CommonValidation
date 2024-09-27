namespace CommonValidation.Documents.CodigoEnderecamentoPostal
{
    public class CEPFormattingService
    {
        public string FormatCEP(string cep)
        {
            var cleanedCep = new string(cep.Where(char.IsDigit).ToArray());

            if (cleanedCep.Length == 8)
            {
                return cleanedCep.Insert(5, "-"); 
            }

            return string.Empty;
        }

        public bool IsValidCEP(string cep)
        {
            var cleanedCep = new string(cep.Where(char.IsDigit).ToArray());

            return cleanedCep.Length == 8;
        }
    }
}
