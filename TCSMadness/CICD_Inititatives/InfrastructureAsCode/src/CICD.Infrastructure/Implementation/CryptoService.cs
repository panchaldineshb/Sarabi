using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CICD.Infrastructure.Implementation
{
    public class CryptoService : ICryptoService
    {
        private IRepository<Video> repository;

        public CryptoService(IRepository<Video> repository)
        {
            this.repository = repository;
        }

        public Video GetById(int id)
        {
            return repository.GetAll().Where(v => v.Id == id).Single();
        }

        public IEnumerable<Video> GetAll()
        {
            return repository.GetAll();
        }

        public void Add(Video v)
        {
            repository.Add(v);
        }
    }
}