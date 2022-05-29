namespace K.UserRoles.Models
{
    public class KAccess_new : IKAccess
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
