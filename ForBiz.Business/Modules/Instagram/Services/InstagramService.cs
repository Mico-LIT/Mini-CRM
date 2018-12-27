using ForBiz.Business.Modules.Instagram.Dto;
using ForBiz.Data.Modules.Instagram.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Business.Core.Page.Dto;
using Utility.Business.Core.Page.Requests;
using AutoMapper;
using ForBiz.Data.Modules.Instagram.Dbo;
using ForBiz.Data.Modules.Instagram.Models;

namespace ForBiz.Business.Modules.Instagram.Services
{
    public class InstagramService : IInstagramService
    {
        Lazy<IInstagramRepository> _instagramRepository;

        public InstagramService(Lazy<IInstagramRepository> instagramRepository)
        {
            _instagramRepository = instagramRepository;
        }

        public void AddPerson(InstagramDto instagram)
        {
            _instagramRepository.Value.AddPerson(Mapper.Map<InstagramDto, InstagramDbo>(instagram));
        }

        public void UpdatePerson(InstagramDto instagram)
        {
            _instagramRepository.Value.UpdatePerson(Mapper.Map<InstagramDto,InstagramDbo>(instagram));
        }

        public PageDto<InstagramDto> Get(PageRequest pageRequest)
        {
            var pageDbo = _instagramRepository.Value.Get(pageRequest.Page, pageRequest.Size);

            return new PageDto<InstagramDto>(
                Mapper.Map<IEnumerable<InstagramDbo>, IEnumerable<InstagramDto>>(pageDbo.Items).ToList()
                , pageRequest
                , pageDbo.TotalCount);
        }

        public void DeletePerson(Guid Id)
        {
            _instagramRepository.Value.DeletePerson(Id);
        }

        public PageDto<InstagramDto> Find(InstagramFindDto instagramFind, PageRequest pageRequest)
        {
            var pageDbo = _instagramRepository.Value.Find(Mapper.Map<InstagramFindDto, InstagramFind>(instagramFind), pageRequest.Page, pageRequest.Size);

            return new PageDto<InstagramDto>(
                Mapper.Map<IEnumerable<InstagramDbo>, IEnumerable<InstagramDto>>(pageDbo.Items).ToList()
                , pageRequest
                , pageDbo.TotalCount
                );
        }
    }
}
