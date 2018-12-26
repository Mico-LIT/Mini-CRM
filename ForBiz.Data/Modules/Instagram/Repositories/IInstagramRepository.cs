using ForBiz.Data.Modules.Instagram.Dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Data.Core.Page.Dbo;

namespace ForBiz.Data.Modules.Instagram.Repositories
{
    public interface IInstagramRepository
    {
        void AddPerson(InstagramDbo instagram);
        void UpdatePerson(InstagramDbo instagram);
        void DeletePerson(Guid Id);
        PageDbo<InstagramDbo> Find(InstagramFind instagramFind);
        PageDbo<InstagramDbo> Get(int page, int size);
    }
}
