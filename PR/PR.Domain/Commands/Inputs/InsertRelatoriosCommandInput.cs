using PR.Shared.Commands;
using System;

namespace PR.Domain.Commands.Inputs
{
    public class InsertRelatoriosCommandInput : ICommandInput
    {
        public Guid ResponsavelId { get; set; }
        public Guid ObraId { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
    }
}
