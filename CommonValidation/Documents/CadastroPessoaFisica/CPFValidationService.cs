using CommonValidation.Useful;

namespace CommonValidation.Documents.CadastroPessoaFisica
{
    public class CPFValidationService
    {
        private const int CPFLength = 11;

        public bool IsValid(string cpf)
        {
            var cleanCpf = new CPFFormattingService().ExtractNumbers(cpf);

            if (cleanCpf.Length != CPFLength || HasRepeatedDigits(cleanCpf))
                return false;

            return HasValidCheckDigits(cleanCpf);
        }

        private bool HasRepeatedDigits(string cpf)
        {
            var invalidNumbers = new[]
            {
            "00000000000", "11111111111", "22222222222",
            "33333333333", "44444444444", "55555555555",
            "66666666666", "77777777777", "88888888888", "99999999999"
        };
            return invalidNumbers.Contains(cpf);
        }

        private bool HasValidCheckDigits(string cpf)
        {
            var number = cpf.Substring(0, CPFLength - 2);

            var verifier = new CheckDigitCalculator(number)
                                .WithMultipliers(10, 2)
                                .ReplaceWith("0", 10, 11);

            var firstDigit = verifier.Calculate();
            verifier.AddDigit(firstDigit);

            verifier.WithMultipliers(11, 2);
            var secondDigit = verifier.Calculate();

            return string.Concat(firstDigit, secondDigit) == cpf.Substring(CPFLength - 2, 2);
        }
    }
}
