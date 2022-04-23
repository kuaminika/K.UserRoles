using K.UserRoles.Models;
using KDBAbstractions.Repository.interfaces;
using System;
using System.Collections.Generic;

namespace K.UserRoles.Repositories
{



    public class Repository_KMember : IKRepository<KMember_interface>
    {
        private AKDBAbstraction dbGateway;

        public Repository_KMember(AKDBAbstraction dbGateway)
        {
            this.dbGateway = dbGateway;

        }


        public int DeleteRecord(KMember_interface victim)
        {
            throw new NotImplementedException();
        }

        public int DeleteRecordById(KMember_interface victim)
        {
            throw new NotImplementedException();
        }

        public List<KMember_interface> GetAll(int org_id = 0, string sortby = "id")
        {
            

            KQueries_Members queryHolder = dbGateway.GetQueryHolder<KQueries_Members>();
            KMember_Data queryObj = new KMember_Data();
            queryObj.OrgId = org_id;
            string query =  queryHolder.GenericSearch;// queryHolder.GenericBadPracticeJustForTestSearch(queryObj);
            List< KMember_Data> initialResults =   dbGateway.ExecuteReadTransaction(query, queryObj);


            List<KMember_interface> result = initialResults.ConvertAll(new Converter<KMember_Data, KMember_interface>(p =>  p));


            return result;

        }

        public KMember_interface GetById(int id)
        {
            throw new NotImplementedException();
        }

        public KMember_interface Record(KMember_interface newRecord)
        {
            KMember_new newMember = (KMember_new)newRecord;
            KQueries_Members queryHolder = dbGateway.GetQueryHolder<KQueries_Members>();

            string query = queryHolder.UserSearch;


            KMember_recorded result = new KMember_recorded();
            result.Email = newMember.Email;
            result.Name = newMember.Name;

            List<KMember_recorded> initialResults = dbGateway.ExecuteReadTransaction(query, result);
            bool noUserAccountExists = initialResults.Count == 0;
           
            int user_id = noUserAccountExists? addUserAccount(newMember, queryHolder):initialResults[0].Id;


            query =   queryHolder.BadPracticeInsert(newMember);
           
            int id =  dbGateway.ExecuteInsertTransaction(query, new {  user_id, org_id=  newMember.OrgId,  newMember.Name ,newMember.Email, roleInOrg_id =  newMember.Role.Id}); 

             
            result.Id = id;
           
            return result;
        }

        private int addUserAccount(KMember_new newRecord, KQueries_Members queryHolder)
        {

            string query = queryHolder.AddUserAccount;// queryHolder.BadPRacticeAddUserAccount(newRecord); // <-- used to debug
            int id = dbGateway.ExecuteInsertTransaction(query, newRecord);
            return id;

        }

        public int UpdateRecord(KMember_interface first)
        {
            throw new NotImplementedException();
        }
    }
}
