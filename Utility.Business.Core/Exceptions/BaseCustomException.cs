using System;
using Utility.Business.Core.Responses;

namespace Utility.Business.Core.Exceptions
{
    public class BaseCustomException : Exception, ICustomException
    {
        public virtual string Code => JsonResponseStatusCode.Error;

        public virtual string UserFriendlyMessage => "Во время выполнения операции произошла ошибка";

        public BaseCustomException()
        {
            // Override constructor to prevent usage of base constructors
        }

        public override string Message => UserFriendlyMessage;
    }
}
