namespace Utility.Business.Core.Exceptions
{
    public class IncorrectDataException : BaseCustomException
    {
        public override string Code => "Incorrect_Data";

        public override string UserFriendlyMessage => "Некорректные данные";
    }
}
