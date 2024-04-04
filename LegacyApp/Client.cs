namespace LegacyApp
{
    public class Client
    {
        private string _name;
        private int _clientId;
        private string _email;
        private string _address;
        private string _type;

        public string Name 
        { 
            get => _name; 
            internal set => _name = value; 
        }

        public int ClientId 
        { 
            get => _clientId; 
            internal set => _clientId = value; 
        }

        public string Email 
        { 
            get => _email; 
            internal set => _email = value; 
        }

        public string Address 
        { 
            get => _address; 
            internal set => _address = value; 
        }

        public string Type 
        { 
            get => _type; 
            set => _type = value; 
        }
    }
}