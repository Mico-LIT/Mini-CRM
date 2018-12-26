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
                #region Instagram
                config.CreateMap<LayerData.Instagram.Dbo.InstagramDbo, LayerBusiness.Instagram.Dto.InstagramDto>();
                #endregion
            });
        }
    }
}
