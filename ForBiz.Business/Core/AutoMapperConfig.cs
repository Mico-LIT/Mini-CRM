using AutoMapper;
using LayerData = ForBiz.Data.Modules;
using LayerBusiness = ForBiz.Business.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForBiz.Business.Core
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                #region Person
                config.CreateMap<LayerData.Persons.Dbo.PersonDbo, LayerBusiness.Persons.Dto.PersonDto>().
                ForMember(x => x.Instagram,
                          x => x.MapFrom(y => string.IsNullOrWhiteSpace(y.Instagram) ? null : string.Format("https://www.instagram.com/{0}", y.Instagram))).
                ForMember(x => x.Vk,
                          x => x.MapFrom(y => string.IsNullOrWhiteSpace(y.Vk) ? null : string.Format("https://vk.com/{0}", y.Vk)));

                config.CreateMap<LayerBusiness.Persons.Dto.PersonDto, LayerData.Persons.Dbo.PersonDbo>().
                ForMember(x => x.Instagram,
                          x => x.MapFrom(y => y.Instagram.Segments[1].Replace("/", ""))).
                ForMember(x => x.Vk,
                          x => x.MapFrom(y => y.Vk.Segments[1].Replace("/", "")));
                config.CreateMap<LayerBusiness.Persons.Dto.PersonDto, LayerData.Persons.Models.PersonFind>().
                ForMember(x => x.Instagram,
                          x => x.MapFrom(y => y.Instagram.Segments[1].Replace("/", ""))).
                ForMember(x => x.Vk,
                          x => x.MapFrom(y => y.Vk.Segments[1].Replace("/", "")));
                #endregion
            });
        }
    }
}
