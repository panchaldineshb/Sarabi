using System.Linq;
using FsaStore.Core.Abstracts;
using FsaStore.Core.Models;

namespace FsaStore.Core.Extensions
{
    public static class AccountProfileRepositoryExtensions
    {
        private static readonly int BCRYPT_WORK_FACTOR = 11;

        public static string Encode(this IRepository<AccountProfile> repository, string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCRYPT_WORK_FACTOR);
        }

        public static string Encode(this IRepository<AccountProfile> repository, string password, int workfactor)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workfactor);
        }

        public static string Encode(this IRepository<AccountProfile> repository, string password, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        public static AccountProfile GetByEmail(this IRepository<AccountProfile> repository, string email)
        {
            return repository.Find(acc => acc.Account.Email == email);
        }

        public static string GetRoleForAccount(this IRepository<AccountProfile> repository, string email)
        {
            var entity = repository.GetByEmail(email);
            return entity.Role.Name;
        }

        public static void RegisterProfile(this IRepository<AccountProfile> repository, AccountProfile accountData, string password)
        {
            accountData.Account.Password = repository.Encode(password);
            repository.Upsert(accountData);
        }

        public static bool Verify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        public static bool VerifyUser(this IRepository<AccountProfile> repository, string username, string password)
        {
            var entity = repository.Find(acc => acc.Name == username);
            if (null == entity) return false;
            return Verify(password, entity.Account.Password);
        }
    }
}