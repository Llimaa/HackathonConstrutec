using PR.Shared.Commands;
using System;

namespace PR.Domain.Commands.Inputs
{
    public class UpdateObraCommandInput : ICommandInput
    {
        public Guid ObraId { get; set; }
        public string[] creas { get; set; }
        public string ResidenteCrea { get; set; }
        public string Fiscal1Crea { get; set; }
        public string Fiscal2Crea { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public DateTime DataEncerramento { get; set; }
    }
}
