using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingCloud.Domain
{
    public interface IADManager : ITransientDependency
    {

        List<string> GetAllAccount();

        bool CheckPassword(string username, string password);

    }
}
