namespace CommonValidationTest
{
    using CommonValidation.Documents.CadastroNacionalPessoaJuridica;
    using FluentAssertions;
    using Xunit;

    public class CNPJTests
    {
        [Fact]
        public void TestarCNPJValido()
        {
            CNPJValidator validator = new CNPJValidator("12.345.678/0001-95");
            var isValid = validator.IsValid();
            isValid.Should().BeTrue();
        }

        [Fact]
        public void TestarCNPJInvalido()
        {
            CNPJValidator validator = new CNPJValidator("00.000.000/0000-00");
            var isValid = validator.IsValid();
            isValid.Should().BeFalse();
        }

        [Theory(DisplayName = "Deve criar CNPJ sem máscara corretamente")]
        [InlineData("12.345.678/0001-95", "12345678000195")]
        [InlineData("00.000.000/0000-00", "00000000000000")]
        public void DeveCriarCNPJSemMascara(string cnpjComMascara, string cnpjEsperado)
        {
            var cnpj = new CNPJ(cnpjComMascara);

            cnpj.WithoutMask().Should().Be(cnpjEsperado);
        }

        [Theory(DisplayName = "Deve formatar CNPJ com máscara corretamente")]
        [InlineData("12345678000195", "12.345.678/0001-95")]
        [InlineData("00000000000000", "00.000.000/0000-00")]
        public void DeveFormatarCNPJComMascara(string cnpjSemMascara, string cnpjEsperadoComMascara)
        {
            var cnpj = new CNPJ(cnpjSemMascara);

            cnpj.WithMask().Should().Be(cnpjEsperadoComMascara);
        }

        [Theory(DisplayName = "Deve validar CNPJ corretamente")]
        [InlineData("02.597.220/0001-70", true)]
        [InlineData("00.000.000/0000-00", false)]
        public void DeveValidarCNPJCorretamente(string cnpj, bool resultadoEsperado)
        {
            var cnpjObj = new CNPJ(cnpj);

            cnpjObj.IsValid().Should().Be(resultadoEsperado);
        }

        [Fact(DisplayName = "Deve comparar dois CNPJs corretamente")]
        public void DeveCompararDoisCNPJsCorretamente()
        {
            var cnpj1 = new CNPJ("12.345.678/0001-95");
            var cnpj2 = new CNPJ("12345678000195");

            cnpj1.Equals(cnpj2).Should().BeTrue();
        }

        [Fact(DisplayName = "Conversão implícita de CNPJ para string deve retornar o número sem máscara")]
        public void ConversaoImplicitaCNPJParaString()
        {
            CNPJ cnpj = new CNPJ("12.345.678/0001-95");

            string cnpjString = cnpj;

            cnpjString.Should().Be("12345678000195");
        }

        [Fact(DisplayName = "Conversão implícita de string para CNPJ deve criar instância corretamente")]
        public void ConversaoImplicitaStringParaCNPJ()
        {
            string cnpjString = "12.345.678/0001-95";

            CNPJ cnpj = cnpjString;

            cnpj.WithoutMask().Should().Be("12345678000195");
        }
    }
}
