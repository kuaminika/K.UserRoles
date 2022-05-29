using K.UserRoles.Models;
using System;

namespace K.UserRoles.Repositories
{
    internal class KQueries_RoleInOrg
    {
        public string Search { get => @"select rio.id           Id
                                             , rio.orgn_id      OrgId
                                             , o.name           OrgName
                                             , r.name          `Name`
                                             , rio.description `Desrciption` 
                                          FROM KRole r 
                                    INNER join KRoleInOrg rio on r.id = rio.role_id
                                    INNER JOIN KOrgn o on rio.orgn_id = o.id
                                         WHERE (r.name = @Name or (r.name<> @Name and @Name = '')) 
                                           AND (rio.id = @Id   or (rio.id<>@Id and @Id = 0))
                                           AND (rio.orgn_id = @OrgId or (rio.orgn_id <> @OrgId and @OrgId =0))"; }

        internal string  SearchBadPractice(KRoleInOrgn_Data qObj)
        {
            return $@"select rio.id           Id
                                             , rio.orgn_id      OrgId
                                             , o.name           OrgName
                                             , r.name          `Name`
                                             , rio.description `Desrciption` 
                                          FROM KRole r 
                                    INNER join KRoleInOrg rio on r.id = rio.role_id
                                    INNER JOIN KOrgn o on rio.orgn_id = o.id
                                         WHERE (r.name = '{qObj.Name}' or (r.name<>  '{qObj.Name}' and  '{qObj.Name}' = '')) 
                                           AND (rio.id = {qObj.Id}   or (rio.id<>{qObj.Id}  and{qObj.Id}  = 0))
                                           AND (rio.orgn_id = {qObj.OrgId}  or (rio.orgn_id <>  {qObj.OrgId}  and  {qObj.OrgId}  =0))";
        }
    }
}