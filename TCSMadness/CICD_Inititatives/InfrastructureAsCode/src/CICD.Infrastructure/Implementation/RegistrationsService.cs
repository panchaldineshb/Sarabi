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
        private INodeRepository _nodeRepository;
        private ITokenRepository _tokenRepository;

        private IValidator<Application> _applicationValidator;
        private IValidator<User> _userValidator;

        public RegistrationsService(
            IUserRepository userRepository, IApplicationRepository applicationRepository, INodeRepository nodeRepository, ITokenRepository tokenRepository)
        {
            this._applicationRepository = applicationRepository;
            this._userRepository = userRepository;
            this._nodeRepository = nodeRepository;
            this._tokenRepository = tokenRepository;
        }

        public bool ValidateToken(string token)
        {
            var entity = _tokenRepository.FindBy(t => t.Key == token);
            if (entity.Any()) return true;
            return false;
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

        public string AddUser(User v)
        {
            string tokenKey = string.Empty;

            _userRepository.Add(v);
            Token t = new Token();
            t.User = v;
            tokenKey = _tokenRepository.CreateRegistrationToken(t);

            return tokenKey;
        }

        public string AddApplication(Application v)
        {
            string tokenKey = string.Empty;

            _applicationRepository.Add(v);
            Token t = new Token();
            t.Application = v;
           tokenKey =  _tokenRepository.CreateRegistrationToken(t);

            return tokenKey;
        }

        public string AddNode(Node v)
        {
            string tokenKey = string.Empty;

            _nodeRepository.Add(v);
            Token t = new Token();
            t.Node = v;
            tokenKey = _tokenRepository.CreateRegistrationToken(t);

            return tokenKey;
        }
    } // class
} // namespace