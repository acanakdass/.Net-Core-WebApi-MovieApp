
using MoviesApp.WebAPI.Helpers.Results.Abstract;
using MoviesApp.WebAPI.Helpers.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.WebAPI.Helpers.Results.Concrete
{
    public class DataResult<Type> : IDataResult<Type>
    {
        public DataResult(ResultStatus resultStatus,Type data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus,string message, Type data)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus,string message, Type data,Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
            Exception = exception;
        }


        public Type Data { get; }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
