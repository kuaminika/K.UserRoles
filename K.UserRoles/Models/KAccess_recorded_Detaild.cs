namespace K.UserRoles.Models
{
    public class KAccess_recorded_Detaild: KAccess_recorded
    { 
        public KRoleInOrgn_recorded Roleinfo { 
                get => new KRoleInOrgn_recorded
                {
                    Id = this.RoleId,
                    Name = this.RoleName,
                    Description = this.RoleDescription
                };

                set {
                    RoleId = value.Id;
                    RoleName = value.Name;
                    RoleDescription = value.Description;            
                }
        }
        public string RoleName { get; private set; }
        public string RoleDescription { get; private set; }
    }
}
