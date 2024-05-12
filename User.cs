namespace UserAccount
{
    public class User
    {
        private string? _userName { get; set; }
        private string? _passwordHash { get; set; }
        private string? _email { get; set; }
        private string? _dateofbirth { get; set; }


        public User()
        { }

        public User(string? UserName, string? PasswordHash, string? Email, string? DOB)
        {
            this._userName = UserName;
            this._passwordHash = PasswordHash;
            this._email = Email;
            this._dateofbirth = DOB;

        }

        public string? UserName { get => _userName; }
        public string? PasswordHash { get => _passwordHash; }
        public string? Email { get => _email; }
        public string? DOB { get => _dateofbirth; }

        // Setters
        public void UpdateUserName(string newUserName)
        {
            this._userName = newUserName;
        }

        public void UpdateUserEmail(string newUserEmail)
        {
            this._email = newUserEmail;
        }

        public void UpdateUserPasswordHash(string newUserPasswordHash)
        {
            this._passwordHash = newUserPasswordHash;
        }

        public void UpdateUserDateOfBirth(string newUserDateOfBirth)
        {
            this._dateofbirth = newUserDateOfBirth;
        }

        // Getters
        public string? GetUserName()
        {
            return this._userName;
        }

        public string? GetUserPasswordHash()
        {
            return this._passwordHash;
        }

        public string? GetUserEmail()
        {
            return this._email;
        }

        public string? GetUserDateOfBirth()
        {
            return this._dateofbirth;
        }

        // Utility Methods
        public override string ToString()
        {
            return
                $"Username: {GetUserName()}\n" +
                $"Hash: {GetUserPasswordHash()}\n" +
                $"Email: {GetUserEmail()}\n" +
                $"DOB: {GetUserDateOfBirth()}";

        }
    }
}
