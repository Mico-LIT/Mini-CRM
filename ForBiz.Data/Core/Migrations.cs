namespace ForBiz.Data.Core
{
    using DbUp;
    using DbUp.ScriptProviders;
    using System;
    using System.Configuration;
    using System.Reflection;

    public static class Migrations
    {
        public static void Apply()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            EnsureDatabase.For.SqlDatabase(connectionString);

            var scriptProvider = new EmbeddedScriptProvider(Assembly.GetExecutingAssembly(), s =>
                s.EndsWith(".sql", StringComparison.InvariantCultureIgnoreCase) &&
                !s.EndsWith("_Rollback.sql", StringComparison.InvariantCultureIgnoreCase));

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScripts(scriptProvider)
                    .Build();

            var result = upgrader.PerformUpgrade();
            if (!result.Successful)
                throw result.Error;
        }

        // TODO. Add rollback method

    }
}
