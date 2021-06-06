using AktifBankTech.Business.Commons.Models.DepositModels;
using AktifBankTech.Business.Mapping;
using AktifBankTech.Data.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Engines
{
    public class BusinessEngineBase
    {
        protected IMapper Mapper;
        public BusinessEngineBase()
        {
            var mapperConfig = new MapperConfiguration(
                configuration =>
                {
                    configuration.IgnoreUnmapped();
                    configuration.ForAllMaps((map, exp) => exp.MaxDepth(1));
                });

            mapperConfig.AssertConfigurationIsValid();
            Mapper = mapperConfig.CreateMapper();
        }
    }
}
