using NUnit.Framework;
using K.UserRoles;
using Microsoft.Extensions.Configuration;
using K.UserRoles.Repositories;
using K.UserRoles.Models;
using KDBAbstractions.Repository.interfaces;
using KDBAbstractions.Repository;
using System.Collections.Generic;

namespace K.UserRoles.Test
{

    public class TestRoleInOrgRepo
    {

        IKRepository<KRoleInOrgn_interface> repo;

        [SetUp]
        public void Setup()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();

            IKRepoConfig kRepoConfig = KRepoConfig.New(configuration);


            KRepoFactory_Abstract kRepoFactory = KRepoFactories.Get<KFactory_RoleInOrgRepo>(kRepoConfig);
            repo = kRepoFactory.Create<KRoleInOrgn_interface>();
        }

        [Test]
        public void TestFetchAllRoles()
        {
            repo.GetAll();
        }

    }
    public class TestKMemberRepo
    {
        IKRepository<KMember_interface> repo; 

        [SetUp]
        public void Setup()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();

             IKRepoConfig kRepoConfig =  KRepoConfig.New(configuration);


            KRepoFactory_Abstract kRepoFactory = KRepoFactories.Get<KFactory_MemberRepo>(kRepoConfig);
            repo = kRepoFactory.Create<KMember_interface>();


        }

        [Test]
        public void TestFetchingAllMembers()
        {
            try
            {
                repo.GetAll();
            }
            catch (System.Exception ex)
            {

                string err = ex.Message;
                if (ex.InnerException != null)
                    err = $@"{err}
                                {ex.InnerException.Message}";



                Assert.Fail(err);

            }
        }


        [Test]
        public void TestAddingMemberInOrg()
        {
            try
            {
                KOrgn_recorded org = new KOrgn_recorded();
                org.Id = 2;
                org.Name = "Test";

                List<KMember_interface> allMembers = repo.GetAll(org.Id);
                int countBefore = allMembers.Count;

                int row_id = countBefore + 1;

                KMember_new newMember = new KMember_new() { Email = $"test{row_id}@{GetType().FullName}", Name = $"Test{row_id}", Org = org };

                repo.Record(newMember);
                allMembers = repo.GetAll(org.Id);

                int countAfter = allMembers.Count;

                Assert.Greater(countAfter, countBefore, $" {countAfter}>{countBefore}");
            }
            catch (System.Exception ex)
            {

                string err =  ex.Message;
                if (ex.InnerException != null)
                    err = $@"{err}
                                {ex.InnerException.Message}";

                Assert.Fail(err);
            }
        
        }
    }
}