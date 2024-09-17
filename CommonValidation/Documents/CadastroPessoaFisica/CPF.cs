namespace CommonValidation.Documents.CadastroPessoaFisica
{
    public class CPF
    {
        public string Number { get; private set; }

        public CPF(string cpf)
        {
            Number = new CPFFormattingService().ExtractNumbers(cpf);
        }

        public static implicit operator string(CPF cpf) => cpf.Number;

        public static implicit operator CPF(string cpf) => new CPF(cpf ?? string.Empty);

        public override string ToString() => Number;

        public string Format() => new CPFFormattingService().ApplyMask(Number);

        public bool IsValid() => new CPFValidationService().IsValid(Number);

        public bool Equals(CPF other) => Number == other.Number;
    }
}
