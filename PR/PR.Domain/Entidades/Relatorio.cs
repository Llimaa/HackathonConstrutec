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

        public Relatorio(string titulo, string imagem, string descricao, Responsavel responsavel, Obra obra)
        {
            Titulo = titulo;
            Imagem = imagem;
            Descricao = descricao;
            Responsavel = responsavel;
            Obra = obra;
            DataRelatorio = DateTime.Now;
        }

        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public Responsavel Responsavel { get; set; }
        public Obra Obra { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public DateTime DataRelatorio { get; set; }

        public void AddComentarios(Comentario comentario)
        {
            Comentarios.Add(comentario);
        }
        public void Update(string titulo, string imagem, string descricao)
        {
            Titulo = titulo;
            Imagem = imagem;
            Descricao = descricao;
        }
    }
}
