using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Business.Core.Exceptions;

namespace ForBiz.Business.Modules.Persons.Exceptions
{
    public class ConditionBaseException : BaseCustomException
    {
        public override string Code => "Сondition_Base";
        public override string UserFriendlyMessage => "Должно заполненно поле Имя и еще одно из Vk,Email,Instagram";
    }
}
