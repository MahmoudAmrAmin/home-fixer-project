namespace Project.DAL.Entities
{
    public class User:BaseEntity
    {
        public int UserId { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser Person { get; set; }
    }
}
