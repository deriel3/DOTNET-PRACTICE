using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoStartUp.Exceptions
{
    public class StartupYaRegistradoException: Exception
    {
        public StartupYaRegistradoException():base("Este Startup ya esta registrado") { }
    }
}
