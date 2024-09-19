namespace CommonValidation.Documents.UnidadeFederativa
{
    public class UFValidationService
    {
        public bool IsValid(string uf)
        {
            var formattingService = new UFFormattingService();

            if (string.IsNullOrEmpty(uf))
                return false;

            return formattingService.IsValidUF(uf) || formattingService.IsValidEstado(uf);
        }
    }
}
