using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Business.Core.Page.Dto;
using Utility.Business.Core.Page.Requests;
using AutoMapper;
using ForBiz.Data.Modules.Persons.Repositories;
using ForBiz.Business.Modules.Persons.Dto;
using ForBiz.Data.Modules.Persons.Models;
using ForBiz.Business.Modules.Persons.Validate;
using ForBiz.Data.Modules.Persons.Dbo;
using Utility.Business.Core.Exceptions;

namespace ForBiz.Business.Modules.Persons.Services
{
    public class PersonService : IPersonService
    {
        Lazy<IPersonRepository> _personRepository;

        public PersonService(Lazy<IPersonRepository> personRepository)
        {
            _personRepository = personRepository;
        }

        public void AddPerson(PersonDto person)
        {
            person.Validate();

            var resultFind = _personRepository.Value.Find(Mapper.Map<PersonDto, PersonFind>(person));

            if (resultFind.Count == 0)
                _personRepository.Value.AddPerson(Mapper.Map<PersonDto, PersonDbo>(person));
            else
                throw new PersonFoundException();
        }

        public void UpdatePerson(PersonDto person)
        {
            person.Validate();
            _personRepository.Value.UpdatePerson(Mapper.Map<PersonDto, PersonDbo>(person));
        }

        public PageDto<PersonDto> Get(PageRequest pageRequest)
        {
            var pageDbo = _personRepository.Value.Get(pageRequest.Page, pageRequest.Size);

            return new PageDto<PersonDto>(
                Mapper.Map<IEnumerable<PersonDbo>, IEnumerable<PersonDto>>(pageDbo.Items).ToList()
                , pageRequest
                , pageDbo.TotalCount);
        }

        public void DeletePerson(Guid personId)
        {
            _personRepository.Value.DeletePerson(personId);
        }

        public PageDto<PersonDto> Find(PersonFindDto personFind, PageRequest pageRequest)
        {
            var pageDbo = _personRepository.Value.Find(Mapper.Map<PersonFindDto, PersonFind>(personFind), pageRequest.Page, pageRequest.Size);

            return new PageDto<PersonDto>(
                Mapper.Map<IEnumerable<PersonDbo>, IEnumerable<PersonDto>>(pageDbo.Items).ToList()
                , pageRequest
                , pageDbo.TotalCount
                );
        }

        public void SendPerson(Guid personId)
        {
            _personRepository.Value.SendPerson(personId);
        }
    }
}
