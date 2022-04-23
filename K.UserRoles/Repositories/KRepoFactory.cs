using K.UserRoles.Models;
using KDBAbstractions.Repository;
using KDBAbstractions.Repository.interfaces;
using System;

namespace K.UserRoles.Repositories
{


    public class KRepoFactories
    {


        public static KRepoFactory_Abstract Get<T>(IKRepoConfig kRepoConfig)
        {

            string connString = kRepoConfig.GetConnectionString("default");
            

            AKDBAbstraction dbAbstraction = new KMysql_KDBAbstraction(connString);
            var result = Activator.CreateInstance(typeof(T), dbAbstraction); // new KRepoFactory(dbAbstraction);
            return (KRepoFactory_Abstract)result;

        }

    }
}
