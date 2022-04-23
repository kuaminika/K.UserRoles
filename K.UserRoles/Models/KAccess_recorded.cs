namespace K.UserRoles.Models
{
    public class KAccess_recorded: IKAccess
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
