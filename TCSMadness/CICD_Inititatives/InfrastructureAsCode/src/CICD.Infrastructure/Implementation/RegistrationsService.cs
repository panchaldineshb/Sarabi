using Autofac;
using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Domain;
using System;
using System.Linq;

namespace CICD.Infrastructure.Implementation
{
    public class UserValidator : IUserValidator
    {
        private User _user;

        public UserValidator(User user)
        {
            _user = user;
        }

        public bool Validate()
        {
            return false;
        }
    } // class

    public class ApplicationValidator : IApplicationValidator
    {
        private Application _application;

        public ApplicationValidator(Application application)
        {
            _application = application;
        }

        public bool Validate()
        {
            if (null == _application)
                throw new NullReferenceException("_application");
            if (0 == _application.Id)
                throw new NullReferenceException("_application.Id");
            if (string.IsNullOrEmpty(_application.Name))
                throw new NullReferenceException("_application.Name");

            return true;
        }
    } // class

    public class RegistrationsService : IRegistrationsService
    {
        private IApplicationRepository _applicationRepository;
        private IUserRepository _userRepository;

        private IValidator<Application> _applicationValidator;
        private IValidator<User> _userValidator;

        public RegistrationsService(
            IUserRepository userRepository, IApplicationRepository applicationRepository)
        {
            this._applicationRepository = applicationRepository;
            this._userRepository = userRepository;
        }

        public void Register(Application v)
        {
            _applicationValidator = new ApplicationValidator(v);
            _applicationValidator.Validate();
            _applicationRepository.Add(v);
        }

        public void Register(User v)
        {
            _userValidator = new UserValidator(v);
            _userValidator.Validate();
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
            _applicationValidator = new ApplicationValidator(v);
            _applicationValidator.Validate();
            _applicationRepository.Delete(v);
        }

        public void UnRegister(User v)
        {
            _userValidator = new UserValidator(v);
            _userValidator.Validate();
            _userRepository.Delete(v);
        }
    } // class
} // namespace