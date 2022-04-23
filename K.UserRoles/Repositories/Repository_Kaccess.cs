using K.UserRoles.Models;
using KDBAbstractions.Repository.interfaces;
using System;
using System.Collections.Generic;

namespace K.UserRoles.Repositories
{
    public class Repository_Kaccess : IKRepository<IKAccess>
    {
        private AKDBAbstraction dbGateway;
        private KQueries_Access queryHolder;

        public Repository_Kaccess(AKDBAbstraction dbAbstraction)
        {
            this.dbGateway = dbAbstraction;
            queryHolder =    this.dbGateway.GetQueryHolder<KQueries_Access>();
        }

        public int DeleteRecord(IKAccess victim)
        {
            throw new NotImplementedException();
        }

        public int DeleteRecordById(IKAccess victim)
        {
            throw new NotImplementedException();
        }

        public List<IKAccess> GetAll(int org_id = 0, string sortby = "id")
        {
           string query =  queryHolder.GetAllQuery;

            List<KAccess_recorded> rawRecords = dbGateway.ExecuteReadTransaction (query, new KAccess_recorded());
            List<IKAccess> result = rawRecords.ConvertAll(new Converter<KAccess_recorded, IKAccess>(p => p));

            return result;
        }

        public IKAccess GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IKAccess Record(IKAccess newRecord)
        {
            KAccess_recorded newAccess = (KAccess_recorded)newRecord;
            string insertQeury = queryHolder.InsertQuery;
           newAccess.Id =  dbGateway.ExecuteInsertTransaction(insertQeury, newAccess);

            return newAccess;
        }

        public int UpdateRecord(IKAccess first)
        {
            throw new NotImplementedException();
        }
    }
}
