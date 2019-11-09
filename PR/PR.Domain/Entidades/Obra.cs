using PR.Domain.Enuns;
using PR.Domain.ObjetosValor;
using PR.Shared.Entidades;
using System;
using System.Collections.Generic;

namespace PR.Domain.Entidades
{
    public class Obra : Entidade
    {
        public Obra()
        {
            Responsaveis = new List<Responsavel>();
            Relatorios = new List<Relatorio>();
        }

        public Obra(string nome, Endereco endereco, Proprietario proprietario, DateTime dataInicio, DateTime dataFinal)
        {
            Nome = nome;
            EStatusObra = EStatusObra.Iniciado;
            Responsaveis = new List<Responsavel>();
            Endereco = endereco;
            Proprietario = proprietario;
            DataInicio = dataInicio;
            DataFinal = dataFinal;
        }

        public string Nome { get; set; }
        public string Imagem { get; set; }
        public EStatusObra EStatusObra { get; set; }
        public Endereco Endereco { get; set; }
        public Proprietario Proprietario { get; set; }
        public Responsavel Residente { get; set; }
        public Responsavel Fiscal1 { get; set; }
        public Responsavel Fiscal2 { get; set; }
        public List<Responsavel> Responsaveis { get; set; }
        public List<Relatorio> Relatorios { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }

        public void InfomacaoOpcional(string imagem, Responsavel residente, Responsavel fiscal1, Responsavel fiscal2)
        {
            Imagem = imagem;
            Residente = residente;
            Fiscal1 = fiscal1;
            Fiscal2 = fiscal2;
        }
        public void Update(string nome, string imagem, DateTime dataFinal)
        {
            Nome = nome;
            Imagem = imagem;
            DataFinal = dataFinal;
            Responsaveis = new List<Responsavel>();
            Relatorios = new List<Relatorio>();
        }
        public void AdicionarRelatorio(Relatorio relatorio)
        {
            Relatorios.Add(relatorio);
        }
        public void AdicionarResponsavel(Responsavel responsavel)
        {
            Responsaveis.Add(responsavel);
        }
        public void UpdateStatus(EStatusObra eStatusObra)
        {
            EStatusObra = eStatusObra;
        }
    }
}
