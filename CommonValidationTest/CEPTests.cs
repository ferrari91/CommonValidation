namespace CommonValidationTest
{
    using CommonValidation.Documents.CodigoEnderecamentoPostal;

    public class CEPTests
    {
        [Theory(DisplayName = "Deve validar corretamente os formatos de CEP")]
        [InlineData("12345-678", true)]
        [InlineData("12345678", true)]
        [InlineData("1234-567", false)]
        [InlineData("abcd-efgh", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void IsValid_ShouldValidateCepFormatCorrectly(string cep, bool expectedResult)
        {
            bool result = false;

            try
            {
                var cepInstance = new CEP(cep);
                result = cepInstance.IsValid();
            }
            catch (ArgumentException ex)
            {
                result = ex.Message == "CEP inválido." ? false : true;
            }

            Assert.Equal(expectedResult, result);
        }

        [Theory(DisplayName = "Deve formatar corretamente o CEP")]
        [InlineData("12345678", "12345-678")]
        [InlineData("12345-678", "12345-678")]
        public void FormatCep_ShouldReturnCorrectFormattedCep(string inputCep, string expectedFormattedCep)
        {
            var cepInstance = new CEP(inputCep);
            Assert.Equal(expectedFormattedCep, cepInstance.ToString());
        }

        [Theory(DisplayName = "Deve lançar exceção para CEP inválido")]
        [InlineData("1234-567")]
        [InlineData("abcd-efgh")]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_ShouldThrowExceptionForInvalidCep(string invalidCep)
        {
            Assert.Throws<ArgumentException>(() => new CEP(invalidCep));
        }

        [Fact(DisplayName = "Deve permitir conversão implícita de CEP para string")]
        public void ImplicitConversion_ShouldConvertCepToString()
        {
            var cep = new CEP("12345-678");
            string cepString = cep;
            Assert.Equal("12345-678", cepString);
        }

        [Fact(DisplayName = "Deve permitir conversão implícita de string para CEP")]
        public void ImplicitConversion_ShouldConvertStringToCep()
        {
            CEP cep = "12345-678";
            Assert.Equal("12345-678", cep.Codigo);
        }
    }
}
