namespace CommonValidation.Documents.CodigoEnderecamentoPostal
{
    public class CEP
    {
        public string Codigo { get; private set; }

        public CEP(string cep)
        {
            if (!string.IsNullOrEmpty(cep))
            {
                var formattingService = new CEPFormattingService();
                if (formattingService.IsValidCEP(cep))
                {
                    Codigo = formattingService.FormatCEP(cep);
                    return;
                }
            }

            throw new ArgumentException("CEP inválido.");
        }

        public static implicit operator string(CEP cep) => cep.Codigo;

        public static implicit operator CEP(string cep) => new CEP(cep ?? string.Empty);
        public override string ToString() => Codigo;

        public bool IsValid() => new CEPValidationService().IsValid(Codigo);
    }
}
