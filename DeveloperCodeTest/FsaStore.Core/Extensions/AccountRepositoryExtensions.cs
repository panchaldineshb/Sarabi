using System.Linq;
using FsaStore.Core.Abstracts;
using FsaStore.Core.Models;

namespace FsaStore.Core.Extensions
{
    public static class AccountRepositoryExtensions
    {
        private static readonly int BCRYPT_WORK_FACTOR = 11;

        public static string Encode(this IRepository<Account> repository, string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCRYPT_WORK_FACTOR);
        }

        public static string Encode(this IRepository<Account> repository, string password, int workfactor)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workfactor);
        }

        public static string Encode(this IRepository<Account> repository, string password, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        public static Account GetByEmail(this IRepository<Account> repository, string email)
        {
            return repository.Find(acc => acc.Email == email);
        }

        public static void RegisterAccount(this IRepository<Account> repository, Account accountData, string password)
        {
            accountData.Password = repository.Encode(password);
            repository.Upsert(accountData);
        }

        public static bool Verify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        public static bool VerifyUser(this IRepository<Account> repository, string username, string password)
        {
            var entity = repository.Find(acc => acc.Name == username);
            if (null == entity) return false;
            return Verify(password, entity.Password);
        }
    }
}