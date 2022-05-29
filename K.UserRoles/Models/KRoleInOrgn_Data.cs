namespace K.UserRoles.Models
{
    public class KRoleInOrgn_DB
    {

    }

    public class KRoleInOrgn_Data : KRoleInOrgn_recorded
    {


        public KRoleInOrgn_Data()
        {
            Clean = true;
        }
        public override KOrgn_recorded Org { 
            get => new KOrgn_recorded { Id = OrgId, Name = OrgName };
            set => SetOrg(value);
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
