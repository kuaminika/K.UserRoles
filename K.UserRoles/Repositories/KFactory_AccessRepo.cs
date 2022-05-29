using KDBAbstractions.Repository.interfaces;
using K.UserRoles.Models;
namespace K.UserRoles.Repositories
{
    public class KFactory_AccessRepo : KRepoFactory_Abstract
    {
        public KFactory_AccessRepo(AKDBAbstraction aKDB) : base(aKDB) { }

        public override IKRepository< IKAccess> Create< IKAccess>()
        {

            Repository_Kaccess result =new Repository_Kaccess(this.dbAbstraction);
            return (IKRepository<IKAccess>)result;
        }
    }
}
