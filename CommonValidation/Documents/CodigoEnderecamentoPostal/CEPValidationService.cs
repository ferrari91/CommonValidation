namespace CommonValidation.Documents.CodigoEnderecamentoPostal
{
    public class CEPValidationService
    {
        public bool IsValid(string cep)
        {
            var formattingService = new CEPFormattingService();

            if (string.IsNullOrEmpty(cep))
                return false;

            return formattingService.IsValidCEP(cep);
        }
    }
}
