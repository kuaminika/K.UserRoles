namespace K.UserRoles.Models
{
    public class KMember_new : KMember_interface
    {
        public KMember_new()
        {
            Role = new KRoleInOrgn_recorded() { Id = 0 };
        }

        public KRoleInOrgn_recorded Role { get; set; } 

        public KOrgn_recorded Org { get; set; }


        public int OrgId { get => Org.Id; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
