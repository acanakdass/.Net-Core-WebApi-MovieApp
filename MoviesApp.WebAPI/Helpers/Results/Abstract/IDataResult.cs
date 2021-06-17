using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.WebAPI.Helpers.Results.Abstract
{
    public interface IDataResult<out Type> : IResult
    {
        // Type başına out yazarak  type'ı liste ya da tek olarak gönderebiliriz
        public Type Data { get; } //new DataResult<Category>(ResultStatus.Success,category)
                                  //new DataResult<IList<Category>>(ResultStatus.Success,category)
        
    }
}
