namespace CommonValidation.Documents.CadastroNacionalPessoaJuridica
{
    using CommonValidation.Useful;

    public class CNPJValidator
    {
        private const int CNPJLength = 14;
        private readonly string rawCNPJ;

        public CNPJValidator(string cnpj)
        {
            rawCNPJ = new CNPJFormattingService().RemoveMask(cnpj);
        }

        public bool IsValid()
        {
            if (!HasValidLength() || HasRepeatedDigits()) return false;
            return HasValidCheckDigits();
        }

        private bool HasValidLength() => rawCNPJ.Length == CNPJLength;

        private bool HasRepeatedDigits()
        {
            string[] invalidNumbers =
            {
            "00000000000000", "11111111111111", "22222222222222", "33333333333333",
            "44444444444444", "55555555555555", "66666666666666", "77777777777777",
            "88888888888888", "99999999999999"
        };
            return invalidNumbers.Contains(rawCNPJ);
        }

        private bool HasValidCheckDigits()
        {
            var number = rawCNPJ.Substring(0, CNPJLength - 2);

            var digitVerifier = new CheckDigitCalculator(number)
                .WithMultipliers(5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2)  
                .ReplaceWith("0", 10, 11);  

            var firstDigit = digitVerifier.Calculate();
            digitVerifier.AddDigit(firstDigit);  

            digitVerifier.WithMultipliers(6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2);

            var secondDigit = digitVerifier.Calculate();

            return string.Concat(firstDigit, secondDigit) == rawCNPJ.Substring(CNPJLength - 2, 2);
        }
    }
}
