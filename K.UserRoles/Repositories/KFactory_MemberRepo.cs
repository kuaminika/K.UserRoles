using KDBAbstractions.Repository.interfaces;
namespace K.UserRoles.Repositories
{
    public class KFactory_MemberRepo : KRepoFactory_Abstract
    {
        public KFactory_MemberRepo(AKDBAbstraction aKDB) : base(aKDB) { }

        public override IKRepository<KMember_interface> Create<KMember_interface>()
        {

            Repository_KMember result = new Repository_KMember(this.dbAbstraction);
            return (IKRepository<KMember_interface>)result;

        }
    }
}
