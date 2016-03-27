using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Domain;
using System;
using System.Linq;

namespace CICD.Infrastructure.Implementation
{
    public class RegistrationsService : IRegistrationsService
    {
        private IApplicationRepository _applicationRepository;
        private IUserRepository _userRepository;

        public RegistrationsService(IUserRepository userRepository, IApplicationRepository applicationRepository)
        {
            this._applicationRepository = applicationRepository;
            this._userRepository = userRepository;
        }

        public void Register(Application v)
        {
            _applicationRepository.Add(v);
        }

        public void Register(User v)
        {
            _userRepository.Add(v);
        }

        public void UnRegister(int id)
        {
            var user = _userRepository.GetAll().Where(v => v.Id == id).Single();
            if (null == user)
            {
                var application = _userRepository.GetAll().Where(v => v.Id == id).Single();
                if (null == application)
                {
                    throw new NullReferenceException("application");
                }
                else
                    UnRegister(application);
            }
            else
            {
                UnRegister(user);
            }
        }

        public void UnRegister(Application v)
        {
            _applicationRepository.Delete(v);
        }

        public void UnRegister(User v)
        {
            _userRepository.Delete(v);
        }
    }
}