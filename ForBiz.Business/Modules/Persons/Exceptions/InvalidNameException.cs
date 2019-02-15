using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Business.Core.Exceptions;

namespace ForBiz.Business.Modules.Persons.Exceptions
{
    public class InvalidNameException : BaseCustomException
    {
        public override string Code => "Invalid_Name";
        public override string UserFriendlyMessage => "Некорректное Имя";
    }
}
