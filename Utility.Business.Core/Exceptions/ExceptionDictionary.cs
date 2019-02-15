using System;
using System.Collections.Generic;

namespace Utility.Business.Core.Exceptions
{
    public sealed class ExceptionDictionary
    {
        private Dictionary<string, ExceptionDictionaryItem> _dictionary;

        private string _baseExceptionCode;

        public void Init(List<ICustomException> customExceptions)
        {
            var baseException = new BaseCustomException();
            _baseExceptionCode = baseException.Code;
            customExceptions.Add(baseException);
            customExceptions.Add(new IncorrectDataException());

            customExceptions.Add(new AllFieldsRequiredException());

            var dictionary = new Dictionary<string, ExceptionDictionaryItem>();
            foreach (var exception in customExceptions)
            {
                dictionary.Add(exception.Code, new ExceptionDictionaryItem
                {
                    UserFriendlyMessage = exception.UserFriendlyMessage
                });
            }
            _dictionary = dictionary;
        }

        public string GetUserFriendlyMessage(string code)
        {
            return _dictionary.ContainsKey(code)
                ? _dictionary[code].UserFriendlyMessage
                : _dictionary[_baseExceptionCode].UserFriendlyMessage;
        }

        public string GetUserFriendlyMessage(Exception exception)
        {
            return exception is ICustomException
                ? ((ICustomException)exception).UserFriendlyMessage
                : _dictionary[_baseExceptionCode].UserFriendlyMessage;
        }

        #region Singleton

        private static volatile ExceptionDictionary instance;
        private static object syncRoot = new Object();

        private ExceptionDictionary() { }

        public static ExceptionDictionary Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ExceptionDictionary();
                    }
                }

                return instance;
            }
        }

        #endregion Singleton
    }
}
