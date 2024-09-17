namespace CommonValidation.Documents.CadastroPessoaFisica
{
    public class CPFFormattingService
    {
        private const int CPFLength = 11;

        public string ExtractNumbers(string value)
        {
            return new string(value.Where(char.IsDigit).ToArray());
        }

        public string ApplyMask(string number)
        {
            if (string.IsNullOrEmpty(number) || number.Length != CPFLength)
                return string.Empty;

            return Convert.ToUInt64(number).ToString(@"000\.000\.000\-00");
        }
    }
}
