using System;
using System.Collections.Generic;
using System.Text;

namespace SonicBoomDto
{
    public class LoginDto
    {
        public string Signer { get; set; } // Ethereum account that claim the signature
        public string Signature { get; set; } // The signature
        public string Message { get; set; } // The plain message
    }

    public class AccountDto
    {
        public string Address { get; set; } // Unique account name (the Ethereum account)
        //public string Name { get; set; } // The user name
        public string RecoveryEmail { get; set; } // The user Email
    }

    public class ConnectionDto
    {
        public string Account { get; set; }
        public Guid Nonce { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class MessageDto
    {
        public string Account { get; set; }
        public string Message { get; set; }
    }
}
