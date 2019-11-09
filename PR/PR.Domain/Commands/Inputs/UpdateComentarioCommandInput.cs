using PR.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PR.Domain.Commands.Inputs
{
    public class UpdateComentarioCommandInput:ICommandInput
    {
        public Guid ComentarioId { get; set; }
        public Guid ObraId { get; set; }
        public Guid ResponsavelId { get; set; }
        public Guid ProprietarioId { get; set; }
        public Guid RelatorioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
