namespace Simple_C__Data_Access_with_Dapper_and_SQL.Services.Utilities
{
    public static class BCryptPasswordHasher
    {
        public static string HashPassword(string password)
        {
            return BC.EnhancedHashPassword(password, BCrypt.Net.HashType.SHA512);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            return BC.EnhancedVerify(password, hashedPassword, BCrypt.Net.HashType.SHA512);
        }
    }
}
