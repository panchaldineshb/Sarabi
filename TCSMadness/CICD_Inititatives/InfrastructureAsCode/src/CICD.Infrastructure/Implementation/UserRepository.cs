using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CICD.Infrastructure.Implementation

{
    public class UserRepository : IUserRepository
    {
        private const string key = "UserS";

        private IDictionary<int, User> Subjects
        {
            get
            ;
            set
            ;
        }

        private void LoadUsers()
        {
            var vids = new List<User>
                             {
                                 new User
                                     {
                                         Id = 1,
                                         Name = "Cassavetes"
                                     },
                                 new User
                                     {
                                         Id = 2,
                                         Name = "Cassavetes"
                                     },
                                 new User
                                     {
                                         Id = 3,
                                         Name = "Brooks"
                                     },
                                 new User
                                     {
                                         Id = 4,
                                         Name = "Lucas"
                                     },
                                 new User
                                     {
                                         Id = 5,
                                         Name = "Kobayashi"
                                     }
                             };
            var vidsToAdd = new Dictionary<int, User>();
            foreach (var vid in vids)
            {
                vidsToAdd.Add(vid.Id, vid);
            }

            Subjects = vidsToAdd;
        }

        public IEnumerable<User> GetAll()
        {
            return Subjects.Values.AsEnumerable();
        }

        public User GetById(int id)
        {
            return Subjects[1];
        }

        public void Add(User item)
        {
            var nextKey = Subjects.Values.Max(v => v.Id) + 1;
            item.Id = nextKey;
            Subjects.Add(nextKey, item);
        }

        public void Delete(User item)
        {
            Subjects.Remove(item.Id);
        }

        public void Update(User item)
        {
            Subjects[item.Id] = item;
        }
    }
}