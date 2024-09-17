# Validador de CPF e CNPJ ( CommonValidation )

Este projeto implementa classes para validação de **CPF** e **CNPJ**, utilizando o cálculo dos **Dígitos Verificadores (DV)** de acordo com as regras estabelecidas pela Receita Federal do Brasil. Ele inclui a validação de números de CPF e CNPJ, remoção de máscaras e formatação de resultados.

## Índice
- [Instalação](#instalação)
- [Uso](#uso)
  - [Validação de CPF](#validação-de-cpf)
  - [Validação de CNPJ](#validação-de-cnpj)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Testes](#testes)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Instalação

Para utilizar este projeto, você precisará ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado.

Clone o repositório:
```bash
git clone https://github.com/ferrari91/CommonValidation.git
cd CommonValidation
```

## Uso

### Validação de CPF

A classe `CPFValidator` é responsável pela validação de CPFs, considerando as regras de cálculo dos dois dígitos verificadores (módulo 11). A formatação de CPFs com ou sem máscara também é suportada.

Exemplo de uso:

```csharp
using System;

public class Program
{
    public static void Main()
    {
        var cpf = "123.456.789-09";
        CPFValidator cpfValidator = new CPFValidator(cpf);

        if (cpfValidator.IsValid())
        {
            Console.WriteLine("CPF válido.");
        }
        else
        {
            Console.WriteLine("CPF inválido.");
        }
    }
}
```

### Validação de CNPJ

A classe `CNPJValidator` é usada para validar CNPJs de acordo com as regras de cálculo dos dígitos verificadores (módulo 11). A classe também remove e aplica máscaras adequadas ao CNPJ.

Exemplo de uso:

```csharp
using System;

public class Program
{
    public static void Main()
    {
        var cnpj = "12.345.678/0001-95";
        CNPJValidator cnpjValidator = new CNPJValidator(cnpj);

        if (cnpjValidator.IsValid())
        {
            Console.WriteLine("CNPJ válido.");
        }
        else
        {
            Console.WriteLine("CNPJ inválido.");
        }
    }
}
```

## Estrutura do Projeto

O projeto está estruturado da seguinte maneira:

```
/src
    /ValidadorDeDocumentos
        - CPFValidator.cs        # Implementação da validação de CPF
        - CNPJValidator.cs       # Implementação da validação de CNPJ
        - CheckDigitCalculator.cs  # Calculadora de dígitos verificadores para CPF e CNPJ
    /Tests
        - CPFTests.cs            # Testes unitários para CPF
        - CNPJTests.cs           # Testes unitários para CNPJ
```

### Classes Principais:
- **CPFValidator**: Classe que realiza a validação de CPF, incluindo a remoção de máscara e cálculo dos dígitos verificadores.
- **CNPJValidator**: Classe que realiza a validação de CNPJ com base no módulo 11, incluindo a formatação e cálculo dos dígitos verificadores.
- **CheckDigitCalculator**: Classe auxiliar usada para calcular dígitos verificadores de CPF e CNPJ.

## Testes

Para rodar os testes unitários, utilize o comando:

```bash
dotnet test
```

Os testes verificam a funcionalidade completa das classes de validação de CPF e CNPJ, incluindo casos de CPFs e CNPJs válidos e inválidos.

Exemplo de teste para CPF:

```csharp
[Test]
public void TestarCPFValido()
{
    CPFValidator validator = new CPFValidator("123.456.789-09");
    Assert.IsTrue(validator.IsValid());
}
```

Exemplo de teste para CNPJ:

```csharp
[Test]
public void TestarCNPJValido()
{
    CNPJValidator validator = new CNPJValidator("12.345.678/0001-95");
    Assert.IsTrue(validator.IsValid());
}
```
