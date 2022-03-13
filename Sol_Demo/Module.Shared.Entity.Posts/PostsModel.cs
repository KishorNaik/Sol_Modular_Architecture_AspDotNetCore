using Framework.Entity;

namespace Module.Shared.Entity.Posts
{
    public class PostsModel : BaseEntity
    {
        public Guid? PostIdentity { get; set; }

        public string? Post { get; set; }

        public Guid? UserIdentity { get; set; }
    }
}