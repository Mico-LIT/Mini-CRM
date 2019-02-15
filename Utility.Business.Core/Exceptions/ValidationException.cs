using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Business.Core.Responses;

namespace Utility.Business.Core.Exceptions
{
    public class ValidationException : BaseCustomException
    {
        public ValidationException(List<JsonResponseStatus> responseStatuses)
        {
            Filds = responseStatuses;
        }

        public override string Code => "Validation";
        public override string UserFriendlyMessage => "Некорректные поля";
        public List<JsonResponseStatus> Filds { get; set; }
    }
}
