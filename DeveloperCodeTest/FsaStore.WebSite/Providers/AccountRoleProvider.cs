using System;
using System.Web.Mvc;
using System.Web.Security;
using FsaStore.Core.Abstracts;
using FsaStore.Core.Models;

namespace FsaStore.WebSite.Providers
{
    public class AccountRoleProvider : RoleProvider
    {
        private string _applicationName;

        public AccountRoleProvider()
        {
            // Refer -- http://stackoverflow.com/questions/6519720/using-ninject-with-a-custom-role-provider-in-an-mvc3-app
            AccountRepository = DependencyResolver.Current.GetService<IRepository<Account>>();
            RoleRepository = DependencyResolver.Current.GetService<IRepository<Role>>();
            AccountProfileRepository = DependencyResolver.Current.GetService<IRepository<AccountProfile>>();
        }

        public IRepository<AccountProfile> AccountProfileRepository { get; set; }

        public IRepository<Account> AccountRepository { get; set; }

        public override string ApplicationName { get { return _applicationName; } set { _applicationName = value; } }

        public IRepository<Role> RoleRepository { get; set; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return new string[0];
        }

        public override string[] GetRolesForUser(string username)
        {
            var objUser = AccountProfileRepository.FindIncluding(x => x.Account.Name == username, x => x.Account, x => x.Role);
            if (objUser == null)
            {
                return null;
            }
            return new string[] { objUser.Role.Name };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}