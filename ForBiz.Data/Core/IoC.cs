using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForBiz.Data.Modules;
using DryIoc;
using ForBiz.Data.Modules.Instagram.Repositories;

namespace ForBiz.Data.Core
{
    public static class IoC
    {
        public static void Register(IContainer container)
        {
            container.Register<IInstagramRepository, InstagramRetository>();
        }
    }
}
