using ForBiz.Business.Modules.Persons.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Business.Core.Exceptions;

namespace ForBiz.Business.Core
{
    public static class ExceptionConfig
    {
        public static void Init()
        {
            ExceptionDictionary.Instance.Init(new List<ICustomException>
            {
                new InvalidEmailException()
            });
        }
    }

}
