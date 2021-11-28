using ClientConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsoleApp.Services.Client
{
    public interface IClientService
    {
        public bool Login(LoginModel user);
    }
}
