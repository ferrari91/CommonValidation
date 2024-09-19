namespace CommonValidation.Documents.UnidadeFederativa
{
    public class UF
    {
        public string Sigla { get; private set; }
        public string Estado { get; private set; }

        public UF(string uf)
        {
            if (!string.IsNullOrEmpty(uf))
            {
                var formattingService = new UFFormattingService();
                if (formattingService.IsValidUF(uf))
                {
                    Sigla = formattingService.ExtractSigla(uf);
                    Estado = formattingService.GetEstadoBySigla(Sigla);
                    return;
                }
                else if (formattingService.IsValidEstado(uf))
                {
                    Estado = uf;
                    Sigla = formattingService.GetSiglaByEstado(uf);
                    return;
                }
            }

            throw new ArgumentException("UF ou Estado inválido.");
        }

        public static implicit operator string(UF uf) => uf.Sigla;

        public static implicit operator UF(string uf) => new UF(uf ?? string.Empty);
        public override string ToString() => Sigla;

        public bool IsValid() => new UFValidationService().IsValid(Sigla);
    }
}
