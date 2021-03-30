namespace Domain
{
    public class ApplicationUser : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Language { get; private set; }
        public virtual ApplicationUserRole Role { get; private set; }

        protected ApplicationUser()
        {
        }

        public ApplicationUser(int id, string firstName, string lastName, string email, string password) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public ApplicationUser(string firstName, string lastName, string email, string password) 
            : this(0, firstName, lastName, email, password)
        {
        }

        public void SetLanguage(string language)
        {
            Language = language;
        }

        public void SetRole(ApplicationUserRole role)
        {
            Role = role;
        }

        public override string ToString()
        {
            if (this.Role == null)
            {
                return $"{Id}:{FirstName} {LastName} | Role: null";
            }
            else
            {
                return $"{Id}:{FirstName} {LastName} | Role: {Role.Role}";
            }
            
        }

        public void ChangeName(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public void ChangePassword(string password)
        {
            this.Password = password;
        }

        public void ChangeEmail(string email)
        {
            this.Email = email;
        }
    }
}