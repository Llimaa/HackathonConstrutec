using Microsoft.Extensions.Configuration;
using PR.Infra.Infra;

namespace PR.API.Context
{
    public class MSSQLDBConfiguration : IDBConfiguration
    {
        private IConfiguration _configuration;

        public MSSQLDBConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString => _configuration.GetConnectionString("PRREASY");
    }
}
