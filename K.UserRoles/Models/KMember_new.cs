namespace K.UserRoles.Models
{
    public struct KMember_new : KMember_interface
    {
        public KRoleInOrgn_recorded Role { get; set; }

        public KOrgn_recorded Org { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}
