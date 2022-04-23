using KDBAbstractions.Repository.interfaces;

namespace K.UserRoles.Repositories
{
    public class KFactory_RoleInOrgRepo : KRepoFactory_Abstract
    {
        public KFactory_RoleInOrgRepo(AKDBAbstraction aKDB) : base(aKDB) { }

        public override IKReadRepo<KRoleInOrgn_interface> CreateReadRepo<KRoleInOrgn_interface>()
        {
            KReadRepo_RoleInOrg reault = new KReadRepo_RoleInOrg(dbAbstraction);
            return (IKReadRepo<KRoleInOrgn_interface>)reault;
        }
        public override IKRepository<KRoleInOrgn_interface> Create<KRoleInOrgn_interface>()
        {
            KReadRepo_RoleInOrg miniRepo = new KReadRepo_RoleInOrg(dbAbstraction);
            Repository_RoleInOrg result = new Repository_RoleInOrg(miniRepo);
            return (IKRepository<KRoleInOrgn_interface>)result;

        }
    }
} 