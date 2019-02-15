using ForBiz.Business.Modules.Persons.Dto;
using System;
using Utility.Business.Core.Page.Dto;
using Utility.Business.Core.Page.Requests;

namespace ForBiz.Business.Modules.Persons.Services
{
    public interface IPersonService
    {
        void AddPerson(PersonDto person);
        void UpdatePerson(PersonDto person);
        void DeletePerson(Guid personId);
        void SendPerson(Guid personId);
        PageDto<PersonDto> Find(PersonFindDto personFind, PageRequest pageRequest);
        PageDto<PersonDto> Get(PageRequest pageRequest);
    }
}