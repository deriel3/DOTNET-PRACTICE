using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoStartUp.Exceptions
{
    public class StartupNoRegistradoException: Exception
    {
        public StartupNoRegistradoException():base("Este Startup no esta registrado") { }
    }
}
