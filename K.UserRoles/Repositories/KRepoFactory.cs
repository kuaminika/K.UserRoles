using K.UserRoles.Models;
using KDBAbstractions.Repository;
using KDBAbstractions.Repository.interfaces;

namespace K.UserRoles.Repositories
{
    public class KRepoFactory
    {


        public static KRepoFactory New(IKRepoConfig kRepoConfig)
        {

            string connString = kRepoConfig.GetConnectionString("default");
            AKDBAbstraction dbAbstraction = new KMysql_KDBAbstraction(connString);
            var result = new KRepoFactory(dbAbstraction);
            return result;

        }
        AKDBAbstraction dbAbstraction;


        public IKRepository<KMember_interface> CreateKMemberRepository
        {
            get
            {

                IKRepository < KMember_interface >  result =  new KMemberRepository(this.dbAbstraction);
                return result;

            }
        }

        public KRepoFactory(AKDBAbstraction dbAbstraction)
        {
            this.dbAbstraction = dbAbstraction;
        }

    }
}
