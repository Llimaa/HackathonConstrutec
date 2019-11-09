namespace PR.Domain.ObjetosValor
{
    public class Endereco
    {
        public Endereco()
        {

        }
        public Endereco(string rua, string bairro, string numero)
        {
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
        }

        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }

        public string EnderecoCompleto => $"{Rua}, {Numero} - {Bairro}";

        public void Update(string rua, string bairro, string numero)
        {
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
        }
    }
}
