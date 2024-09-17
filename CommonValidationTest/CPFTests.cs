namespace CommonValidationTest
{
    using CommonValidation.Documents.CadastroPessoaFisica;
    using Xunit;

    public class CPFTests
    {
        [Theory(DisplayName = "CPF - Deve remover a máscara ao criar CPF")]
        [InlineData("123.456.789-09", "12345678909")]
        [InlineData("12345678909", "12345678909")]
        [InlineData("000.000.000-00", "00000000000")]
        public void CPF_Creation_ShouldRemoveMask(string input, string expected)
        {
            var cpf = new CPF(input);
            Assert.Equal(expected, cpf.ToString());
        }

        [Theory(DisplayName = "CPF - Deve retornar a validade correta do CPF")]
        [InlineData("446.563.120-02", true)]
        [InlineData("12345678909", true)]
        [InlineData("00000000000", false)]
        [InlineData("111.111.111-11", false)]
        public void CPF_Validation_ShouldReturnCorrectValidity(string input, bool expectedValidity)
        {
            var cpf = new CPF(input);
            Assert.Equal(expectedValidity, cpf.IsValid());
        }

        [Fact(DisplayName = "CPF - Deve aplicar a máscara corretamente")]
        public void CPF_Formatting_ShouldApplyMask()
        {
            var cpf = new CPF("12345678909");
            var formattedCpf = cpf.Format();
            Assert.Equal("123.456.789-09", formattedCpf);
        }

        [Fact(DisplayName = "CPF - Deve retornar vazio para CPF inválido")]
        public void CPF_Formatting_ShouldReturnEmptyForInvalidCPF()
        {
            var cpf = new CPF("123");
            var formattedCpf = cpf.Format();
            Assert.Equal(string.Empty, formattedCpf);
        }

        [Fact(DisplayName = "CPF - Conversão implícita para string deve retornar o número")]
        public void CPF_ImplicitConversion_ToString_ShouldReturnNumber()
        {
            var cpf = new CPF("12345678909");
            string cpfString = cpf;
            Assert.Equal("12345678909", cpfString);
        }

        [Fact(DisplayName = "CPF - Conversão implícita de string deve criar CPF")]
        public void CPF_ImplicitConversion_FromString_ShouldCreateCPF()
        {
            CPF cpf = "12345678909";
            Assert.Equal("12345678909", cpf.ToString());
        }

        [Fact(DisplayName = "CPF - Igualdade deve retornar verdadeiro para números iguais")]
        public void CPF_Equality_ShouldReturnTrueForEqualNumbers()
        {
            var cpf1 = new CPF("12345678909");
            var cpf2 = new CPF("123.456.789-09");
            Assert.True(cpf1.Equals(cpf2));
        }

        [Fact(DisplayName = "CPF - Igualdade deve retornar falso para números diferentes")]
        public void CPF_Equality_ShouldReturnFalseForDifferentNumbers()
        {
            var cpf1 = new CPF("12345678909");
            var cpf2 = new CPF("98765432100");
            Assert.False(cpf1.Equals(cpf2));
        }
    }
}
