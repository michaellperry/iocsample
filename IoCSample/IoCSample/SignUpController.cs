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
        private readonly ISignUpService _service;

        public SignUpController(ISignUpService service)
        {
            _service = service;
        }

        public ControllerResponse Post(SignUpForm form)
        {
            bool ok = _service.SignUp(form.Email, form.Password);

            if (!ok)
                return new ControllerResponse("User already exists");
            else
                return new ControllerResponse("OK");
        }
    }
}
