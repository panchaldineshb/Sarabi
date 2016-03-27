﻿using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CICD.Infrastructure.Implementation

{
    public class ApplicationRepository : IApplicationRepository
    {
        private const string key = "ApplicationS";

        private IDictionary<int, Application> Subjects
        {
            get
            ;
            set
            ;
        }

        private void LoadApplications()
        {
            var vids = new List<Application>
                             {
                                 new Application
                                     {
                                         Id = 1,
                                         Name = "Cassavetes"
                                     },
                                 new Application
                                     {
                                         Id = 2,
                                         Name = "Cassavetes"
                                     },
                                 new Application
                                     {
                                         Id = 3,
                                         Name = "Brooks"
                                     },
                                 new Application
                                     {
                                         Id = 4,
                                         Name = "Lucas"
                                     },
                                 new Application
                                     {
                                         Id = 5,
                                         Name = "Kobayashi"
                                     }
                             };
            var vidsToAdd = new Dictionary<int, Application>();
            foreach (var vid in vids)
            {
                vidsToAdd.Add(vid.Id, vid);
            }

            Subjects = vidsToAdd;
        }

        public IEnumerable<Application> GetAll()
        {
            return Subjects.Values.AsEnumerable();
        }

        public Application GetById(int id)
        {
            return Subjects[1];
        }

        public void Add(Application item)
        {
            var nextKey = Subjects.Values.Max(v => v.Id) + 1;
            item.Id = nextKey;
            Subjects.Add(nextKey, item);
        }

        public void Delete(Application item)
        {
            Subjects.Remove(item.Id);
        }

        public void Update(Application item)
        {
            Subjects[item.Id] = item;
        }
    }
}