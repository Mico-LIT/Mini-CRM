using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Business.Core.Exceptions;

namespace ForBiz.Business.Modules.Persons.Exceptions
{
    public class InvalidVkException : BaseCustomException
    {
        public override string Code => "Invalid_Vk";
        public override string UserFriendlyMessage => "Некорректный VK";
    }
}
