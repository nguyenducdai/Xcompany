using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Data;
using Portal.Areas.CPortal.Models;
using AutoMapper;

namespace Portal.Infractstructure.Mapping
{
    public static class AutoMappingConfigration
    {
        public static void Configration()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Menus, MenuViewModel>();
                cfg.CreateMap<Categories, CategoryViewModel>();
            });
        }
    }
}
