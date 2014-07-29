using Autofac;
using IoCSample.Framework;
using IoCSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IoCSample
{
    public class Application
    {
        private SignUpController _signUpController;

        public void Init()
        {
            //DatabaseConnection connection = new DatabaseConnection("connectionstring");
            //ISignUpService signUpService = new SignUpService(connection);
            //SignUpController controller = new SignUpController(signUpService);
            //_signUpController = controller;

            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<SignUpController>();
            builder.RegisterType<SignUpService>()
                .AsImplementedInterfaces();
            builder.RegisterType<DatabaseConnection>();
            builder.RegisterInstance(new DatabaseConfiguration
            {
                ConnectionString = "connectionString"
            });

            IContainer container = builder.Build();

            SignUpController controller = container.Resolve<SignUpController>();
            _signUpController = controller;
        }
    }
}
