using Simple_C__Data_Access_with_Dapper_and_SQL.Services.Utilities;

namespace Simple_C__Data_Access_with_Dapper_and_SQL.Models
{
    public class Customer
    {
        private Customer () { }
        internal Customer(Guid id, string firstName, string lastName, string email, string password, DateTime DateOfBirth)

        {
            id = Guid.NewGuid();
            firstName = firstName;
            lastName = lastName;
            email = email;
            DateOfBirth = DateOfBirth;
        }

        public Guid Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set;}
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public bool ConfirmPassword(string password)
        {
            var isPasswordConfirmed = Password is not null && BCryptPasswordHasher.VerifyHashedPassword(Password, password);

            return isPasswordConfirmed;
        }

        public bool ChangePassword(string password)
        {
            var isPasswordConfirmed = Password is not null && BCryptPasswordHasher.VerifyHashedPassword(Password, password);

            return isPasswordConfirmed;
        }
    }
}
