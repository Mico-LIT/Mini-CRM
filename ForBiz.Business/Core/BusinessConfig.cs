namespace ForBiz.Business.Core
{
    public static class BusinessConfig
    {
        public static void ApplyMigrations()
        {
            Data.Core.Migrations.Apply();
        }
    }
}
