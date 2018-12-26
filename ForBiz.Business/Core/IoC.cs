namespace ForBiz.Business.Core
{
    using DryIoc;
    using ForBiz.Business.Modules.Instagram.Services;

    public static class IoC
    {
        public static void Register(IContainer container)
        {
            Data.Core.IoC.Register(container);

            container.Register<IInstagramService, InstagramService>();
        }
    }
}
