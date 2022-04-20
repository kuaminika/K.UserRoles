namespace K.UserRoles.Models
{
    public class KMember_recorded : KMember_interface, KRecordedModel_interface
    {
        public KMember_recorded()
        { Clean = true; }
        public virtual KRoleInOrgn_recorded Role { get;  }

        public virtual KOrgn_recorded Org { get;   }

        public int Id { get; set; }
        public string UId { get => Id.ToString(); set => Id = int.Parse(value); }
        public  string Name { get; set; }
        public  string Email { get; set; }
        public bool Clean { get; set; }
    }
}
