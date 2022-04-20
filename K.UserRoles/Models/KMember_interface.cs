namespace K.UserRoles.Models
{
    public interface KMember_interface : KUser_interface
    {
        KRoleInOrgn_recorded Role {get; }
        KOrgn_recorded Org { get;  }
    }
}
