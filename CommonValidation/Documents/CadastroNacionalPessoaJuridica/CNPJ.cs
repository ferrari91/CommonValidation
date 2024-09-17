namespace CommonValidation.Documents.CadastroNacionalPessoaJuridica
{
    public class CNPJ
    {
        public string Number { get; private set; }

        public CNPJ(string cnpj)
        {
            Number = new CNPJFormattingService().RemoveMask(cnpj);
        }

        public static implicit operator string(CNPJ cnpj) => cnpj.Number;

        public static implicit operator CNPJ(string cnpj) => new CNPJ(cnpj ?? string.Empty);
        public override string ToString() => WithoutMask();

        public string WithMask() => new CNPJFormattingService().FormatWithMask(Number);

        public string WithoutMask() => Number;

        public bool IsValid() => new CNPJValidator(Number).IsValid();

        public bool Equals(CNPJ cnpj) => Number == cnpj.WithoutMask();
    }
}
