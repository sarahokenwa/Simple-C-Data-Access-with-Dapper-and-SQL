namespace Simple_C__Data_Access_with_Dapper_and_SQL.Exceptions
{
    public class PasswordHashingException : Exception
    {
        public PasswordHashingException(string message, Exception innerException) : base(message, innerException) { }
    }
}
