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
    public class TestKMemberRepo
    {
        IKRepository<KMember_interface> kMemberRepository; 

        [SetUp]
        public void Setup()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();

             IKRepoConfig kRepoConfig =  KRepoConfig.New(configuration);


             KRepoFactory kRepoFactory = KRepoFactory.New(kRepoConfig); 
             kMemberRepository = kRepoFactory.CreateKMemberRepository;


        }

        [Test]
        public void TestFetchingAllMembers()
        {
            try
            {
                kMemberRepository.GetAll();
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

                List<KMember_interface> allMembers = kMemberRepository.GetAll(org.Id);
                int countBefore = allMembers.Count;

                int row_id = countBefore + 1;

                KMember_new newMember = new KMember_new() { Email = $"test{row_id}@{GetType().FullName}", Name = $"Test{row_id}", Org = org };

                kMemberRepository.Record(newMember);
                allMembers = kMemberRepository.GetAll(org.Id);

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