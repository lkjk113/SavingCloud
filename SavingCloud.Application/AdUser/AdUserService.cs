using SavingCloud.Application.Article.Dto;
using SavingCloud.Domain;
using SavingCloud.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SavingCloud.Application
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class AdUserService : IAdUserService
    {
        //SavingCloudContainer db = new SavingCloudContainer();

        private readonly IADManager _ADManager;

        public AdUserService(IADManager ADManage)
        {
            _ADManager = ADManage;
        }


        /// <summary>
        /// 登录域用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            return _ADManager.CheckPassword(username, password);
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllUsername()
        {
            return _ADManager.GetAllAccount();
        }
    }
}