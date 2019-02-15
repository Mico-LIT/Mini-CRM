using ForBiz.Data.Modules.Persons.Dbo;
using ForBiz.Data.Modules.Persons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Data.Core.Page.Dbo;

namespace ForBiz.Data.Modules.Persons.Repositories
{
    public interface IPersonRepository
    {
        void AddPerson(PersonDbo person);
        void UpdatePerson(PersonDbo person);
        void DeletePerson(Guid personId);
        void SendPerson(Guid personId);
        PageDbo<PersonDbo> Find(PersonFind personFind, int page, int size);
        List<PersonDbo> Find(PersonFind personFind);
        PageDbo<PersonDbo> Get(int page, int size);
    }
}
