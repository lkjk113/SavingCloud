using SavingCloud.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SavingCloud.Web.Controllers
{
    public class AdUserController : ControllerBase
    {
        private readonly IAdUserService _userService;

        public AdUserController(IAdUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 登录域用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            return _userService.Login(username, password);
        }

        /// <summary>
        /// 获取所有用户名
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllUsername()
        {
            return _userService.GetAllUsername();
        }
    }
}
