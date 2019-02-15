using ForBiz.Business.Modules.Persons.Dto;
using ForBiz.Business.Modules.Persons.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utility.Business.Core.Exceptions;
using Utility.Business.Core.Responses;

namespace ForBiz.Business.Modules.Persons.Validate
{
    internal static class PersonValidate
    {
        internal static void Validate(this PersonDto person)
        {
            List<BaseCustomException> exceptions = new List<BaseCustomException>();

            if (string.IsNullOrWhiteSpace(person.Name)) exceptions.Add(new InvalidNameException());

            if (person.Instagram != null)
            if (string.IsNullOrWhiteSpace(person.Instagram.OriginalString) || !person.Instagram.IsAbsoluteUri ||
                    !(person.Instagram.Host == "www.instagram.com") || person.Instagram.Segments.Length <= 1 ||
                    string.IsNullOrWhiteSpace(person.Instagram.Segments?[1].Replace('/',' '))) exceptions.Add(new InvalidInstagramException());

            if (person.Vk != null)
            if (string.IsNullOrWhiteSpace(person.Vk.OriginalString) || !person.Vk.IsAbsoluteUri ||
                    !(person.Vk.Host == "vk.com") || person.Vk.Segments.Length <= 1 ||
                    string.IsNullOrWhiteSpace(person.Vk.Segments?[1].Replace('/', ' '))) exceptions.Add(new InvalidVkException());

            if (person.Email != null)
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(person.Email);
                if (!match.Success) exceptions.Add(new InvalidEmailException());
            }

            if (person.Instagram == null && person.Vk == null && person.Email == null) { exceptions.Add(new ConditionBaseException()); }

            if (exceptions.Count > 0)
            {
                throw new ValidationException(exceptions.Select(x => JsonResponseStatus.CreateError(x.UserFriendlyMessage, x.Code)).ToList());
            }
        }
    }
}
