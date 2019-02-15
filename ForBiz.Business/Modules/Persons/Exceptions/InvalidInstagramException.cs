using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Business.Core.Exceptions;

namespace ForBiz.Business.Modules.Persons.Exceptions
{
    public class InvalidInstagramException : BaseCustomException
    {
        public override string Code => "Invalid_Instagraml";
        public override string UserFriendlyMessage => "Некорректный Instagram";
    }
}
