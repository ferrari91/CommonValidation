namespace CommonValidation.Documents.CadastroNacionalPessoaJuridica
{
    public class CNPJFormattingService
    {
        private const int CNPJLength = 14;

        public string FormatWithMask(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj) || cnpj.Length != CNPJLength) return string.Empty;
            return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
        }

        public string RemoveMask(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj)) return string.Empty;
            return new string(cnpj.Where(char.IsDigit).ToArray());
        }

        public bool IsValidLength(string cnpj)
        {
            string unmaskedCnpj = RemoveMask(cnpj);
            return unmaskedCnpj.Length == CNPJLength;
        }
    }
}
