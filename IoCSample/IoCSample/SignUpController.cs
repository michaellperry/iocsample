using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCSample.Framework;
using IoCSample.Services;

namespace IoCSample
{
    public class SignUpController
    {
        private readonly DatabaseConnection _connection;

        public SignUpController()
        {
            _connection = new DatabaseConnection("connectionstring");
        }

        public ControllerResponse Post(SignUpForm form)
        {
            SignUpService service = new SignUpService(_connection);
            bool ok= service.SignUp(form.Email, form.Password);

            if (!ok)
                return new ControllerResponse("User already exists");
            else
                return new ControllerResponse("OK");
        }
    }
}
