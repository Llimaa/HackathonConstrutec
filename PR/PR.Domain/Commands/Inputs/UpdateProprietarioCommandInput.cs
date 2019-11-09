using PR.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PR.Domain.Commands.Inputs
{
    public class UpdateProprietarioCommandInput:ICommandInput
    {
        public Guid ProprietarioId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
    }
}
