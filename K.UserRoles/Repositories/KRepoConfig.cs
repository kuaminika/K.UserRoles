using Microsoft.Extensions.Configuration;
using System;
using System.Text;

namespace K.UserRoles.Repositories
{
    public interface IKRepoConfig
    {
        string GetConnectionString(string connStringType);
    }

    public class KRepoConfig:IKRepoConfig
    {
        private IConfiguration configuration;

        public static IKRepoConfig New( IConfiguration configuration)
        {
            var result = new KRepoConfig(configuration);
            return result;
        }

        public string GetConnectionString(string connStringType)
        {
          string result = configuration.GetConnectionString(connStringType);
            return result;
        }

        private KRepoConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}
