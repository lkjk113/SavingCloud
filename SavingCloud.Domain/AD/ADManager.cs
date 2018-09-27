using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SavingCloud.Domain
{
    public class ADManager : IADManager
    {
        const int LOGON32_LOGON_INTERACTIVE = 2; //通过网络验证账户合法性
        const int LOGON32_PROVIDER_DEFAULT = 0; //使用默认的Windows 2000/NT NTLM验证方
        const string domainName = "isoftstone.com";

        [DllImport("advapi32.dll")]
        private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        public List<string> GetAllAccount()
        {
            List<string> objList = new List<string>();

            string myLDAPPath = "LDAP://"+ domainName;

            DirectoryEntry mySearchRoot = new DirectoryEntry(myLDAPPath);
            DirectorySearcher myDirectorySearcher = new DirectorySearcher(mySearchRoot);


            myDirectorySearcher.Filter = ("(objectClass=user)"); //user表示用户，group表示组
            foreach (SearchResult mySearchResult in myDirectorySearcher.FindAll())
            {
                if (mySearchResult != null)
                {
                    // Get the properties of the 'mySearchResult'.
                    ResultPropertyCollection myResultPropColl;
                    myResultPropColl = mySearchResult.Properties;

                    foreach (string myKey in myResultPropColl.PropertyNames)
                    {
                        objList.Add(myKey);
                    }
                    mySearchRoot.Dispose();
                }
            }
            return objList;
        }

        public bool CheckPassword(string username, string password)
        {
            username = username ?? "Administrator";

            IntPtr tokenHandle = new IntPtr(0);
            tokenHandle = IntPtr.Zero;

            bool result = LogonUser(username, domainName, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref tokenHandle);

            return result;
        }
    }
}
