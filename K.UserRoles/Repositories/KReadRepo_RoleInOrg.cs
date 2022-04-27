using K.UserRoles.Models;
using KDBAbstractions.Repository.interfaces;
using System;
using System.Collections.Generic;

namespace K.UserRoles.Repositories
{
    public class KReadRepo_RoleInOrg : IKReadRepo<KRoleInOrgn_interface>
    {
        internal AKDBAbstraction dbAbstraction { get; }
        internal KQueries_RoleInOrg queryHolder { get; }
        public KReadRepo_RoleInOrg(AKDBAbstraction dbAbstraction)
        {
            this.dbAbstraction = dbAbstraction;
            this.queryHolder = dbAbstraction.GetQueryHolder<KQueries_RoleInOrg>();
        }
        KRoleInOrgn_Data ensureType (KRoleInOrgn_interface queryObj)
        {
            if ((queryObj as KRoleInOrgn_Data) != null) return (KRoleInOrgn_Data)queryObj;

            KRoleInOrgn_Data result = new KRoleInOrgn_Data
            { 
                Clean= true,
                Description = queryObj.Description,
                Name = queryObj.Name,
                Org = queryObj.Org            
            };

            return result;

        }
        public List<KRoleInOrgn_interface> Get(KRoleInOrgn_interface queryObj)
        {
            string queryStr = queryHolder.Search;

            var qObj = ensureType(queryObj);
            //queryStr = queryHolder.SearchBadPractice(qObj);
            List<KRoleInOrgn_Data> rawRecords =  dbAbstraction.ExecuteReadTransaction(queryStr, qObj);

            List<KRoleInOrgn_interface> result = rawRecords.ConvertAll(new Converter<KRoleInOrgn_Data, KRoleInOrgn_interface>(p => p));
            return result;
        }
    }
} 