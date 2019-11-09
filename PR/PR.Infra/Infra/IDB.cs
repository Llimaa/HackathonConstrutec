using System;
using System.Data;

namespace PR.Infra.Infra
{
    public interface IDB : IDisposable
    {
        IDbConnection GetCon();
    }
}
