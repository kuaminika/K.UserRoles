namespace K.UserRoles.Models
{
    public class KRoleInOrgn_Data : KRoleInOrgn_recorded
    {

        public KRoleInOrgn_Data(KOrgn_recorded org)
        {
            OrgId = org.Id;
            OrgName = org.Name;
        }

        public int OrgId { get; set; }
        public string OrgName { get; set; }

        public void SetOrg(KOrgn_recorded org)
        {
            OrgId = org.Id;
            OrgName = org.Name;
        }



    }
}
