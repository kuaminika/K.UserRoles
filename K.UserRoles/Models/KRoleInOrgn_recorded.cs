namespace K.UserRoles.Models
{
    public class KRoleInOrgn_recorded : KRoleInOrgn_interface, KRecordedModel_interface
    {
     
        public int Id { get; set; }
        public string UId { get => Id.ToString(); set => Id = int.Parse(value); }
        public KOrgn_recorded Org { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Clean { get; set; }
    }

}
