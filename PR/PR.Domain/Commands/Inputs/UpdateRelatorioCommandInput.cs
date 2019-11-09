using PR.Shared.Commands;
using System;

namespace PR.Domain.Commands.Inputs
{
    public class UpdateRelatorioCommandInput : ICommandInput
    {
        public Guid RelarorioId { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
    }
}
