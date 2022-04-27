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

            List<KAccess_recorded> rawRecords = dbGateway.ExecuteReadTransaction (query, new KAccess_recorded() { OrgId =org_id});
            List<IKAccess> result = rawRecords.ConvertAll(new Converter<KAccess_recorded, IKAccess>(p => p));

            return result;
        }

        public IKAccess GetById(int id)
        {
            string query = queryHolder.GetAllQuery;

            List<KAccess_recorded> rawRecords = dbGateway.ExecuteReadTransaction(query, new KAccess_recorded() { Id = id});

            if (rawRecords.Count == 0)
                return new KAccess_recorded { Id = 0, Name = "Not found", Description = "No access found" };


            List<IKAccess> result = rawRecords.ConvertAll(new Converter<KAccess_recorded, IKAccess>(p => p));

            return result[0];
        }

        /// <summary>
        /// This will add access to an existing role. 
        /// </summary>
        /// <param name="newRecord"></param>
        /// <returns></returns>
        public IKAccess Record(IKAccess newRecord)
        {

            KAccess_recorded newAccess = ensureType(newRecord);

            string genericAccessQuery = @"SELECT 
                                           `k`.`name`             `Name`
                                         , `k`.`description`      `Description`
                                         , `k`.`id`               `GenericAccesId`
                                        from KAccess k where `name`= @Name and `description`= @Description";

            var rawList = dbGateway.ExecuteReadTransaction(genericAccessQuery, newAccess);
            if (rawList.Count == 0)
            {
                string insertGenericAccessQuery = "INSERT INTO `KAccess` (  `name`, `description`) VALUES ( @Name, @Description)";
                newAccess.GenericAccesId = dbGateway.ExecuteInsertTransaction(insertGenericAccessQuery, newAccess);

            }
            else
                newAccess.GenericAccesId = rawList[0].GenericAccesId;
           

            string insertQeury = queryHolder.InsertQuery;
            newAccess.Id =  dbGateway.ExecuteInsertTransaction(insertQeury, newAccess);

            return newAccess;
        }

        KAccess_recorded ensureType(IKAccess a)
        {
            if (a as KAccess_recorded != null) return (KAccess_recorded)a;

            var result = new KAccess_recorded { Description = a.Description, Name = a.Name };
            return result;
        }


        public int UpdateRecord(IKAccess first)
        {
            KAccess_recorded victim = ensureType(first);
            string updateQuery = queryHolder.UpdateQuery;
            int affectedRows = dbGateway.ExecuteWriteTransaction(updateQuery, victim);
            return affectedRows;
        }
    }
}
