namespace Utility.Business.Core.Exceptions
{
    public interface ICustomException
    {
        string Code { get; }

        string UserFriendlyMessage { get; }
    }
}
