using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalkerApp.Application.Interfaces
{
    public interface ILoginService
    {
        bool ValidateCredentials(string username, string password);
    }

}
