using K.UserRoles.Models;

namespace K.UserRoles.Repositories
{
    public class KQueries_Members
    {
        public string GenericSearch
        { get=> @"SELECT
                      m.id                 `Id`,
                      u.name               `Name`,
                      u.email              `Email`,
                      m.orgn_id  			`OrgId`,
                      m.roleInOrgn_id 		`RoleInOrgId`,
                      rio.name 				`RoleInOrgName`,
                      rio.description 		`RoleInOrgDesc`,
                      o.name 			    `OrgName`
                    FROM KUser u 
                    INNER JOIN KMember m on u.id = m.user_id
                    INNER JOIN KOrgn o on o.id = m.orgn_id 
                    LEFT JOIN ( SELECT 
                                ri.description,
                                ri.role_id,
                                r.name  ,
                                ri.id
                               FROM  KRoleInOrg ri 
                               INNER JOIN  KRole r on r.id = ri.role_id 
                               Where ((ri.role_id = @RoleInOrgId ) or ( ri.role_id <>  @RoleInOrgId and  @RoleInOrgId= 0))
                                ) rio on rio.id = m.roleInOrgn_id"; }

        internal string UserSearch
        {
            get => @"SELECT 
                      u.id                 `Id`,
                      u.name               `Name`,
                      u.email              `Email`
                       FROM `KUser` `u`
                      WHERE `u`.`Email` = @Email

                    ";
        }

        internal string BadPRacticeAddUserAccount(KMember_new newRecord)
        {
         string reslt = $@" INSERT INTO `KUser` (`email`,`name`) VALUES ('{newRecord.Email}','{newRecord.Name}')";

            return reslt;
        }

        public string AddUserAccount { get=> @" INSERT INTO `KUser` (`email`,`name`) VALUES (@Email,@Name)"; }

        internal string BadPracticeInsert(KMember_new newMember)
        {
            string result = $@"
                            --  select @roleInOrg_id := id from KRoleInOrg where id=  {newMember.Role.Id};
                            --  select @user_id = id from KUser `u` where `u`.`email`= '{newMember.Email}';
                             -- select @org_id = {newMember.Org.Id};
                             -- INSERT IGNORE INTO `KUser` (`name`,`email`) VALUES ('{newMember.Name}','{newMember.Email}');
                             -- select @user_id = id from KUser `u` where `u`.`email`= '{newMember.Email}';

                              INSERT INTO `KMember` (  `user_id`, `orgn_id`, `roleInOrgn_id`) VALUES ( @user_id,  @org_id, @roleInOrg_id)

                    ";

            return result;
        }

        public string GenericBadPracticeJustForTestSearch(KMember_Data query)
        {
           string result = $@"SELECT
                      m.id                 `Id`,
                      u.name               `Name`,
                      u.email              `Email`,
                      m.orgn_id  			`OrgId`,
                      m.roleInOrgn_id 		`RoleInOrgId`,
                      rio.name 				`RoleInOrgName`,
                      rio.description 		`RoleInOrgDesc`,
                      o.name 			    `OrgName`
                    FROM KUser u 
                    INNER JOIN KMember m on u.id = m.user_id
                    INNER JOIN KOrgn o on o.id = m.orgn_id 
                    LEFT JOIN ( SELECT 
                                ri.description,
                                ri.role_id,
                                r.name  ,
                                ri.id 
                               FROM  KRoleInOrg ri 
                               INNER JOIN  KRole r on r.id = ri.role_id
                               Where ((ri.role_id = {query.RoleInOrgId}  ) or ( ri.role_id <> {query.RoleInOrgId} and {query.RoleInOrgId}= 0))
                                ) rio on rio.id = m.roleInOrgn_id
                   WHERE ( m.id = {query.Id} or (m.id <> {query.Id} and {query.Id}= 0)";

            return result;
        }
    }
}
