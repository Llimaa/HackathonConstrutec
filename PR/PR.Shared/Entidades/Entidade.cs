using System;

namespace PR.Shared.Entidades
{
    public class Entidade
    {
        public Entidade()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
