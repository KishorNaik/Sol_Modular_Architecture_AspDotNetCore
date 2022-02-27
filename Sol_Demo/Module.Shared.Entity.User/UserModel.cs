using Framework.Entity;

namespace Module.Shared.Entity.User
{
    public class UserModel : BaseEntity
    {
        public Guid? UserIdentity { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string HashPassword { get; set; }

        public string Salt { get; set; }
    }
}