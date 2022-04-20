namespace K.UserRoles.Models
{
    public interface KRoleInOrgn_interface : KRole
    {
        KOrgn_recorded Org { get; }
    }

}
