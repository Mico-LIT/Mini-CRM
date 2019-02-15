namespace ForBiz.Business.Core
{
    using DryIoc;
    using ForBiz.Business.Modules.Persons.Services;

    public static class IoC
    {
        public static void Register(IContainer container)
        {
            Data.Core.IoC.Register(container);
            container.Register<IPersonService, PersonService>();
        }
    }
}
