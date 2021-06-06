using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Commons.Models.CommonModels
{
    public class RequestToken<T>
    {
        public T Filter { get; set; }
    }
}
