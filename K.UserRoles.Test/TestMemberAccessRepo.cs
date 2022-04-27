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
        IKReadRepo<KRoleInOrgn_interface> roleRepo;
        [SetUp]
        public void SetUp()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json")
                 .Build();

            IKRepoConfig kRepoConfig = KRepoConfig.New(configuration);


            var kRepoFactory = KRepoFactories.Get<KFactory_AccessRepo>(kRepoConfig);
            var kRoleRepoFactory = KRepoFactories.Get<KFactory_RoleInOrgRepo>(kRepoConfig);
            repo = kRepoFactory.Create<IKAccess>();

            roleRepo = kRoleRepoFactory.CreateReadRepo<KRoleInOrgn_interface>();
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

        [Test]
        public void TestAddingMember()
        {
            KRoleInOrgn_recorded defaultRoleInDB = new KRoleInOrgn_recorded { Id = 0 };

            KAccess_new access = new KAccess_new { RoleId = defaultRoleInDB.Id, Name = "fakeAccess", Description = "this is just to test so its fake" };

            var all = repo.GetAll();
            int countBefore = all.Count;
            repo.Record(access);
            all = repo.GetAll();
            int countAfter = all.Count;
            Assert.Greater(countAfter, countBefore);


        }

    }
}