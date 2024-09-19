namespace CommonValidationTest
{
    using CommonValidation.Documents.UnidadeFederativa;
    public class UFTests
    {
        [Theory(DisplayName = "Deve validar corretamente as siglas de estados")]
        [InlineData("SP", true)]
        [InlineData("RJ", true)]
        [InlineData("XX", false)] 
        [InlineData("", false)]    
        [InlineData(null, false)]  
        public void IsValid_ShouldValidateUfSiglaCorrectly(string sigla, bool expectedResult)
        {
            bool result = false;

            try
            {
                var uf = new UF(sigla);
                result = uf.IsValid();
            }
            catch (ArgumentException ex)
            {
                result = ex.Message == "UF ou Estado inválido." ? false : true;
            }

            Assert.Equal(expectedResult, result);
        }

        [Theory(DisplayName = "Deve validar corretamente os nomes dos estados")]
        [InlineData("São Paulo", true)]
        [InlineData("Rio de Janeiro", true)]
        [InlineData("Estado Inexistente", false)] 
        [InlineData("", false)]                   
        [InlineData(null, false)]                
        public void IsValid_ShouldValidateUfEstadoCorrectly(string estado, bool expectedResult)
        {
            bool result = false;

            try
            {
                var uf = new UF(estado);
                result = uf.IsValid();
            }
            catch (ArgumentException ex)
            {
                result = ex.Message == "UF ou Estado inválido." ? false : true;
            }

            Assert.Equal(expectedResult, result);
        }

        [Theory(DisplayName = "Deve retornar o nome correto do estado para a sigla")]
        [InlineData("SP", "São Paulo")]
        [InlineData("RJ", "Rio de Janeiro")]
        public void GetEstado_ShouldReturnCorrectStateForSigla(string sigla, string expectedEstado)
        {
            var uf = new UF(sigla);
            Assert.Equal(expectedEstado, uf.Estado);
        }

        [Theory(DisplayName = "Deve retornar a sigla correta para o estado")]
        [InlineData("São Paulo", "SP")]
        [InlineData("Rio de Janeiro", "RJ")]
        public void GetSigla_ShouldReturnCorrectSiglaForEstado(string estado, string expectedSigla)
        {
            var uf = new UF(estado);
            Assert.Equal(expectedSigla, uf.Sigla);
        }

        [Theory(DisplayName = "Deve lançar exceção para UF ou Estado inválido")]
        [InlineData("XX")] 
        [InlineData("Estado Inexistente")] 
        public void Constructor_ShouldThrowExceptionForInvalidUfOrEstado(string invalidUfOrEstado)
        {
            Assert.Throws<ArgumentException>(() => new UF(invalidUfOrEstado));
        }

        [Fact(DisplayName = "Deve permitir conversão implícita de UF para string")]
        public void ImplicitConversion_ShouldConvertUfToString()
        {
            var uf = new UF("SP");
            string ufString = uf;
            Assert.Equal("SP", ufString);
        }

        [Fact(DisplayName = "Deve permitir conversão implícita de string para UF")]
        public void ImplicitConversion_ShouldConvertStringToUf()
        {
            UF uf = "SP"; 
            Assert.Equal("SP", uf.Sigla);
        }
    }
}
