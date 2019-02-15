namespace Utility.Business.Core.Exceptions
{
    public class AllFieldsRequiredException : BaseCustomException
    {
        public override string Code => "All_Fields_Required";

        public override string UserFriendlyMessage => "Необходимо заполнить все поля";
    }
}
