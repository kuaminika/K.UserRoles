using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using K.UserRoles.Repositories;
using K.UserRoles.Models;
using KDBAbstractions.Repository.interfaces;
using System.Collections.Generic;
using System;

namespace K.UserRoles.Test
{
    public class TestMemberAccessRepo
    {

        IKRepository<IKAccess> repo;
        [SetUp]
        public void SetUp()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json")
                 .Build();

            IKRepoConfig kRepoConfig = KRepoConfig.New(configuration);


            var kRepoFactory = KRepoFactories.Get<KFactory_AccessRepo>(kRepoConfig);
            repo = kRepoFactory.Create<IKAccess>();
        }

        [Test]
        public void TestFetchingAllAccess()
        {
            try
            {
                List<IKAccess> kAccesses = repo.GetAll();
            }
            catch (Exception ex)
            {

                string err = ex.Message;
                if (ex.InnerException != null)
                    err = $@"{err}
                                {ex.InnerException.Message}";



                Assert.Fail(err);
            }
            
        }

    }
}