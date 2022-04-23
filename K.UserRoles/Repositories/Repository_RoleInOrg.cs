using K.UserRoles.Models;
using KDBAbstractions.Repository.interfaces;
using System;
using System.Collections.Generic;

namespace K.UserRoles.Repositories
{
    public class Repository_RoleInOrg : IKRepository<KRoleInOrgn_interface>
    {
        private AKDBAbstraction dbGateway;
        private KQueries_RoleInOrg queryHolder;
        private KReadRepo_RoleInOrg searcher;

        public Repository_RoleInOrg(KReadRepo_RoleInOrg searcher)
        {
            this.dbGateway = searcher.dbAbstraction;
            this.queryHolder = searcher.queryHolder;
            this.searcher = searcher;

        }

        public int DeleteRecord(KRoleInOrgn_interface victim)
        {
            throw new NotImplementedException();
        }

        public int DeleteRecordById(KRoleInOrgn_interface victim)
        {
            throw new NotImplementedException();
        }

        public List<KRoleInOrgn_interface> GetAll(int org_id = 0, string sortby = "id")
        {
          var query =  new KRoleInOrgn_recorded();
            query.Org.Id = org_id;
            var result = searcher.Get(query);
            return result;
        }

        public KRoleInOrgn_interface GetById(int id)
        {
            throw new NotImplementedException();
        }

        public KRoleInOrgn_interface Record(KRoleInOrgn_interface newRecord)
        {
            throw new NotImplementedException();
        }

        public int UpdateRecord(KRoleInOrgn_interface first)
        {
            throw new NotImplementedException();
        }
    }
}
