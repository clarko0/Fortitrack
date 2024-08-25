using Common.Configuration.EnvHelpers;

namespace Common.Configuration.DatabaseCredentials;
public class MySqlCredentialProvider
{
    public string Host { get; set; }
    public string Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Database { get; set; }

    public string ConnectionString
    {
        get
        {
            return $"server={Host};userid={Username};pwd={Password};port={Port};database={Database}";
        }
    }

    public MySqlCredentialProvider(string database)
    {
        Host = EnvRead.ReadEnvironmentVariableOrDefault(EnvNames.MYSQL_HOST, "localhost");
        Port = EnvRead.ReadEnvironmentVariableOrDefault(EnvNames.MYSQL_PORT, "3307");
        Username = EnvRead.ReadEnvironmentVariableOrDefault(EnvNames.MYSQL_USERNAME, "root");
        Password = EnvRead.ReadEnvironmentVariableOrDefault(EnvNames.MYSQL_PASSWORD, "password");
        Database = database;
    }

    public MySqlCredentialProvider(string location, string port, string username, string password, string database)
    {
        Host = location;
        Port = port;
        Username = username;
        Password = password;
        Database = database;
    }


}