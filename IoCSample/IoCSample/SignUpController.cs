using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCSample.Framework;

namespace IoCSample
{
    public class SignUpController
    {
        public ControllerResponse Post(SignUpForm form)
        {
            var connection = new DatabaseConnection("connectionstring");

            var result = connection.ExecuteQuery("select * from user");

            if (result.Next())
            {
                return new ControllerResponse("User already exists");
            }

            connection.ExecuteNonQuery(String.Format(
                "insert into user (username, password) values ({0}, {1})",
                form.Email,
                form.Password));

            Mailbox mailbox = new Mailbox("donotreply@improvingenterprises.com");

            Message message = new Message
            {
                To = form.Email,
                Subject = "Welcome",
                Body = String.Format("You signed up. Your password is {0}.", form.Password)
            };

            mailbox.Send(message);

            return new ControllerResponse("OK");
        }
    }
}
