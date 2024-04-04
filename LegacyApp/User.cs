using System;

namespace LegacyApp
{
    public class User
    {
        private object _client;
        private DateTime _dateOfBirth;
        private string _emailAddress;
        private string _firstName;
        private string _lastName;
        private bool _hasCreditLimit;
        private int _creditLimit;

        public object Client 
        { 
            get => _client; 
            internal set => _client = value; 
        }

        public DateTime DateOfBirth 
        { 
            get => _dateOfBirth; 
            internal set => _dateOfBirth = value; 
        }

        public string EmailAddress 
        { 
            get => _emailAddress; 
            internal set => _emailAddress = value; 
        }

        public string FirstName 
        { 
            get => _firstName; 
            internal set => _firstName = value; 
        }

        public string LastName 
        { 
            get => _lastName; 
            internal set => _lastName = value; 
        }

        public bool HasCreditLimit 
        { 
            get => _hasCreditLimit; 
            internal set => _hasCreditLimit = value; 
        }

        public int CreditLimit 
        { 
            get => _creditLimit; 
            internal set => _creditLimit = value; 
        }
    }
}
