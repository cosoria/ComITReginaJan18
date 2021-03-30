namespace Domain
{
    public class ApplicationUserRole : Entity
    {
        public static readonly ApplicationUserRole Admin = new ApplicationUserRole(1, "Admin");
        public static readonly ApplicationUserRole User = new ApplicationUserRole(2, "User");
        public static readonly ApplicationUserRole Transformer = new ApplicationUserRole(3, "Transformer");

        public string Role { get; private set; }

        public ApplicationUserRole() 
        {
        }

        public ApplicationUserRole(string role) : this(0, role)
        {
            Role = role;
        }

        public ApplicationUserRole(int id, string role) : base(id)
        {
            Role = role;
        }
    }
}