using System.Text;
using Common.Configuration.DatabaseCredentials;
using Common.Configuration.EnvHelpers;
using Microsoft.IdentityModel.Tokens;

namespace Common.Configuration
{
    public class Settings
    {
        public MySqlCredentialProvider ExerciseDatabaseCredentials { get; set; }

        public string Environment { get; set; }

        public bool InProductionEnvironment { get { return Environment == EnvironmentTypes.PRODUCTION; } }
        public bool InDevelopmentEnvironment { get { return Environment == EnvironmentTypes.DEVELOPMENT; } }
        public bool InStagingEnvironment { get { return Environment == EnvironmentTypes.STAGING; } }
        public bool InMigrationEnvironment { get { return Environment == EnvironmentTypes.MIGRATING; } }

        public Settings()
        {
            Environment = EnvRead.ReadEnvironmentVariableOrDefault(EnvNames.ASPNETCORE_ENVIRONMENT, EnvironmentTypes.DEVELOPMENT);

            ExerciseDatabaseCredentials = new MySqlCredentialProvider("fortitrack_exercises");
        }
    }
}