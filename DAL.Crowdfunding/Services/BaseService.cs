using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace DAL.Crowdfunding.Services
{
    public class BaseService
    {
        private readonly IConfiguration _config;

        public BaseService(IConfiguration config)
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
            _config = config;
        }

        protected string _ConnectionString { get => _config.GetConnectionString("localDb"); }

        protected string _InvariantName { get => _config.GetSection("InvariantName").GetSection("localDb").Value; }
    }
}