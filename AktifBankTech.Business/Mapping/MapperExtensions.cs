using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Mapping
{
    public static class MapperExtensions
    {
        private static void IgnoreUnmappedProperties(TypeMap map, IMappingExpression expr)
        {
            foreach (string propName in map.GetUnmappedPropertyNames())
            {
                var srcPropInfo = map.SourceType.GetProperty(propName);

                if (srcPropInfo != null)
                    expr.ForSourceMember(propName, opt => opt.Ignore());

                var destPropInfo = map.DestinationType.GetProperty(propName);

                if (destPropInfo != null)
                    expr.ForMember(propName, opt => opt.Ignore());
            }
        }

        public static void IgnoreUnmapped(this IProfileExpression profile)
        {
            profile.ForAllMaps(IgnoreUnmappedProperties);
        }
    }
}
