namespace Common.Configuration.EnvHelpers
{
    public static class EnvRead
    {
        public static string ReadEnvironmentVariableOrDefault(string environmentVariableName, string defaultValue)
        {
            string? environmentEnv = Environment.GetEnvironmentVariable(EnvNames.ASPNETCORE_ENVIRONMENT);

            bool missingEnvironmentEnv = environmentEnv is null;
            if (missingEnvironmentEnv)
            {
                throw new Exception($"Cannot find env: {EnvNames.ASPNETCORE_ENVIRONMENT}");
            }

            string environment = environmentEnv ?? "";
            bool inProductionEnvironment = environment == "Production";

            string? environmentVariable = Environment.GetEnvironmentVariable(environmentVariableName);

            bool missingEnvironmentVariable = environmentVariable is null;
            if (missingEnvironmentVariable && inProductionEnvironment)
            {
                throw new Exception($"Cannot find env: {environmentVariableName}");
            }

            string variable = environmentVariable ?? defaultValue;

            return variable;
        }
    }
}