using ForBiz.Business.Modules.Instagram.Dto;
using System;
using Utility.Business.Core.Page.Dto;
using Utility.Business.Core.Page.Requests;

namespace ForBiz.Business.Modules.Instagram.Services
{
    public interface IInstagramService
    {
        void AddPerson(InstagramDto instagram);
        void UpdatePerson(InstagramDto instagram);
        void DeletePerson(Guid Id);
        PageDto<InstagramDto> Find(InstagramFindDto instagramFind, PageRequest pageRequest);
        PageDto<InstagramDto> Get(PageRequest pageRequest);
    }
}