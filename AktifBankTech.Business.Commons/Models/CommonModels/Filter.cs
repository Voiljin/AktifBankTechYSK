using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Commons.Models.CommonModels
{
    public sealed class Filter<T>
    {
        private static readonly Filter<T> instance = new Filter<T>();
        private Filter() { }
        public static Filter<T> Instance
        {
            get
            {
                return instance;
            }
        }

        public RequestToken<T> Parameter(RequestToken<T> filterParameter)
        {
            return filterParameter;
        }
    }
}
