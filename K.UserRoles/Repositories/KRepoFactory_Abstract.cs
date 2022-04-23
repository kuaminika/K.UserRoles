using KDBAbstractions.Repository.interfaces;

namespace K.UserRoles.Repositories
{
    public abstract class KRepoFactory_Abstract
    {
        protected readonly AKDBAbstraction dbAbstraction;
        public KRepoFactory_Abstract(AKDBAbstraction dbAbstraction)
        {
            this.dbAbstraction = dbAbstraction;
        }
        public abstract IKRepository<T> Create<T>();
    }
}
