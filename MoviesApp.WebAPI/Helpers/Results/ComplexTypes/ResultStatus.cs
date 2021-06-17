using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.WebAPI.Helpers.Results.ComplexTypes
{
    public enum ResultStatus
    {
        Success=0,
        Error=1,
        Warning=2, //ResultStatus.Warning
        Info=3
    }
}
