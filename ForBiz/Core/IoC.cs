namespace ForBiz.Core
{
    using DryIoc;
    using DryIoc.Mvc;

    internal static class IoC
    {
        internal static void Register()
        {
            var conteiner = new Container();
            Business.Core.IoC.Register(conteiner);
            conteiner.WithMvc();
        }
    }
}