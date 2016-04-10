using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Domain;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace CICD.Infrastructure.Implementation

{
    public class VideoRepository : IRepository<Video>
    {
        private const string key = "VIDEOS";

        private IDictionary<int, Video> Videos
        {
            get
            ;
            set
            ;
        }

        private void LoadVideos()
        {
            var vids = new List<Video>
                             {
                                 new Video
                                     {
                                         Id = 1,
                                         Director = "Cassavetes",
                                         RentalDays = 3,
                                         RentalPrice = 3.99M,
                                         Title = "Shadows",
                                         YearReleased = 1958
                                     },
                                 new Video
                                     {
                                         Id = 2,
                                         Director = "Cassavetes",
                                         RentalDays = 3,
                                         RentalPrice = 3.99M,
                                         Title = "Faces",
                                         YearReleased = 1968
                                     },
                                 new Video
                                     {
                                         Id = 3,
                                         Director = "Brooks",
                                         RentalDays = 5,
                                         RentalPrice = 2.50M,
                                         Title = "Blazing Saddles",
                                         YearReleased = 1977
                                     },
                                 new Video
                                     {
                                         Id = 4,
                                         Director = "Lucas",
                                         RentalDays = 3,
                                         RentalPrice = 2.50M,
                                         Title = "Star Wars Episode IV: A New Hope",
                                         YearReleased = 1977
                                     },
                                 new Video
                                     {
                                         Id = 5,
                                         Director = "Kobayashi",
                                         RentalDays = 2,
                                         RentalPrice = 3.25M,
                                         Title = "Hara Kiri",
                                         YearReleased = 1958
                                     }
                             };
            var vidsToAdd = new Dictionary<int, Video>();
            foreach (var vid in vids)
            {
                vid.RetailPrice = 19.99M;
                vidsToAdd.Add(vid.Id, vid);
            }

            Videos = vidsToAdd;
        }

        public IEnumerable<Video> GetAll()
        {
            return Videos.Values.AsEnumerable();
        }


        public IEnumerable<Video> FindBy(Expression<Func<Video, bool>> predicate)
        {
            return null;
        }

        public Video GetById(int id)
        {
            return Videos[1];
        }

        public void Add(Video item)
        {
            var nextKey = Videos.Values.Max(v => v.Id) + 1;
            item.Id = nextKey;
            Videos.Add(nextKey, item);
        }

        public void Delete(Video item)
        {
            Videos.Remove(item.Id);
        }

        public void Update(Video item)
        {
            Videos[item.Id] = item;
        }
    }
}