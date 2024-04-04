using System;

namespace LegacyApp
{
    public class UserService
    {
        private readonly ClientRepository _clientRepository;
        private readonly UserCreditService _userCreditService;

        public UserService()
        {
            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!CheckNameLegit(firstName,lastName) || !CheckEmailLegit(email))
            {
                return false;
            }
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
            {
                age--;
            }

            if (!CheckAgeLegit(age))
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else
            {
                int creditLimit = _userCreditService.GetCreditLimit(user.LastName);
                user.CreditLimit = client.Type == "ImportantClient" ? creditLimit * 2 : creditLimit;
                user.HasCreditLimit = true;
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        private bool CheckNameLegit(string firstName , string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckEmailLegit(string email)
        {
            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckAgeLegit(int age)
        {
            if (age < 21)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
