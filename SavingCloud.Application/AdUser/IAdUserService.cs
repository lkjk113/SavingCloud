using SavingCloud.Application.Article.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingCloud.Application
{
    public interface IAdUserService : ITransientDependency
    {
        /// <summary>
        /// 登录域用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool Login(string username, string password);

        /// <summary>
        /// 获取所有用户名
        /// </summary>
        /// <returns></returns>
        List<string> GetAllUsername();

    }
}
