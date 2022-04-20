namespace K.UserRoles.Models
{
    public class KOrgn_recorded : KOrgn_interface,KRecordedModel_interface
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UId { get =>Id.ToString(); set =>Id= int.Parse(value); }
        public bool Clean { get; set; }
    }
}
