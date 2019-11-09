using PR.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PR.Domain.Commands.Inputs
{
    public class InsertComentarioCommandInput:ICommandInput
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string TituloRelatorio { get; set; }
        public string ImagemoRelatorio { get; set; }
        public string DescricaoRelatorio { get; set; }
        public string NomeResponsavel { get; set; }
        public string CREA_Responsavel { get; set; }
        public string EmailResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }

        public string NomeObra { get; set; }
        public string ImagemObra { get; set; }

    }
}
