namespace PR.Domain.Entidades
{
    public class Comentario
    {
        public Comentario()
        {

        }

        public Comentario(Relatorio relatorio, string autor, string descricao)
        {
            Relatorio = relatorio;
            Autor = autor;
            Descricao = descricao;
        }

        public Relatorio Relatorio { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
    }
}
