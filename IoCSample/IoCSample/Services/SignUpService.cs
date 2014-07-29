using IoCSample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCSample.Services
{
    public class SignUpService : ISignUpService
    {
        private readonly DatabaseConnection _connection;

        public SignUpService(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public bool SignUp(string email, string password)
        {
            bool userExists = GetUserExists(email);
            if (userExists)
            {
                return false;
            }

            _connection.ExecuteNonQuery(String.Format(
                "insert into user (username, password) values ({0}, {1})",
                email,
                password));

            Mailbox mailbox = new Mailbox("donotreply@improvingenterprises.com");

            Message message = new Message
            {
                To = email,
                Subject = "Welcome",
                Body = String.Format("You signed up. Your password is {0}.", password)
            };

            mailbox.Send(message);

            return true;
        }

        private bool GetUserExists(string email)
        {
            var result = _connection.ExecuteQuery(
                String.Format("select * from user where username = {0}", email));

            bool userExists = result.Next();
            return userExists;
        }
    }
}
