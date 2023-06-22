namespace Core.Exceptions
{
    public class MABException : Exception
    {
        private string _message;
        public int Code { get; private set; }
        public new object Data { get; set; }

        public override string Message => _message;
        public MABException(int errorCode, object data) : this(errorCode)
        {
            Data = data;
        }
        public MABException(string message, int errorCode, object data) : this(errorCode)
        {
            _message = $"{_message}{Environment.NewLine}{message}";
            Data = data;
        }

        public MABException(int errorCode)
        {
            Code = errorCode;
            switch (errorCode)
            {
                case MABErrorCodes.INVALID_USERNAME_OR_PASSWORD_CODE:
                    _message = MABErrorCodes.INVALID_USERNAME_OR_PASSWORD_MESSAGE;
                    break;
                case MABErrorCodes.USER_PASSWORD_NOT_MATCHED_CODE:
                    _message = MABErrorCodes.USER_PASSWORD_NOT_MATCHED_MESSAGE;
                    break;
                case MABErrorCodes.USER_ALREADY_EXISTS_CODE:
                    _message = MABErrorCodes.USER_ALREADY_EXISTS_MESSAGE;
                    break;
                default:
                    _message = MABErrorCodes.SYS_UNKNOWN_ERROR_MESSAGE;
                    break;


            }
        }

    }
    public static class MABErrorCodes
    {
        //Auth
        public const int INVALID_USERNAME_OR_PASSWORD_CODE = 1001;
        internal const string INVALID_USERNAME_OR_PASSWORD_MESSAGE = "Invalid username or password";

        public const int USER_PASSWORD_NOT_MATCHED_CODE = 1002;
        internal const string USER_PASSWORD_NOT_MATCHED_MESSAGE = "Password is not matched";

        public const int USER_PASSWORD_IS_NULL_CODE = 1003;
        internal const string USER_PASSWORD_IS_NULL_MESSAGE = "Password is null";

        public const int USER_ALREADY_EXISTS_CODE = 1004;
        internal const string USER_ALREADY_EXISTS_MESSAGE = "User already exists";



        public const int SYS_UNKNOWN_ERROR_CODE = 5100;
        internal const string SYS_UNKNOWN_ERROR_MESSAGE = "Unknown error";
    }

}


