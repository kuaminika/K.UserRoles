namespace K.UserRoles.Models
{
    public class KMember_Data : KMember_recorded
    {
        public int OrgId { get; set; }
        public int RoleInOrgId { get; set; }
        public string RoleInOrgName { get; set; }
        public string RoleInOrgDesc { get; set; }
        public string OrgName { get; set; }

     
        public override KRoleInOrgn_recorded Role { get => new KRoleInOrgn_recorded { Name = RoleInOrgName, Description = RoleInOrgDesc, Id = RoleInOrgId, }; }
     
        public override KOrgn_recorded Org { get => new KOrgn_recorded { Id = OrgId, Name = OrgName }; }
    
    }
}
