using PR.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PR.Domain.Entidades
{
    public class Relatorio : Entidade
    {
        public Relatorio()
        {
            Comentarios = new List<Comentario>();
        }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public DateTime DataRelatorio { get; set; }
    }
}
