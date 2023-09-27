namespace testapp1.ExceptionHandler
{

    /// <summary>
    /// Custom exception class that extends the base Exception class and includes
    /// additional properties for status code and error message.
    /// </summary>
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; } 

        public CustomException(StatusCodes statusCode, string errorMessage = "")
        {
            StatusCode = (int)statusCode;
            ErrorMessage = errorMessage;
        }

 
  
    }
    public enum StatusCodes
    {
        BAD_PAYLOAD = 400,
        NOT_FOUND = 404,

    }
}
