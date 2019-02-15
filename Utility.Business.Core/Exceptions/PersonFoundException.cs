using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Business.Core.Exceptions
{
    public class PersonFoundException : BaseCustomException
    {
        public override string Code => "Person_Found";
        public override string UserFriendlyMessage => "В системе данный человек существует";
    }
}
