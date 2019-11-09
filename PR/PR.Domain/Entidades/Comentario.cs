namespace PR.Domain.Entidades
{
    public class Comentario
    {
        public Comentario()
        {

        }

        public Comentario(Relatorio relatorio, Responsavel autor, string titulo, string descricao)
        {
            Relatorio = relatorio;
            Autor = autor;
            Descricao = descricao;
            Titulo = titulo;
        }

        public Relatorio Relatorio { get; set; }
        public Responsavel Autor { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public void Update(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }
    }
}
