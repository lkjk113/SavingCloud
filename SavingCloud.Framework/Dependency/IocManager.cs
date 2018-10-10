using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingCloud.Framework.Dependency
{
    /// <summary>
    /// Ioc管理，需要时获取已注册的对象。应用程序启动时，要初始化ResolveFunc
    /// </summary>
    public class IocManager
    {
        static IocManager _default = new IocManager();

        private IocManager() { }
        public static IocManager Default
        {
            get
            {
                return _default;
            }
        }


        /// <summary>
        /// 从IOC根范围解析对象(一般用于单例对象的解析)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            var t = typeof(T);
            return (T)ResolveFunc(t);
        }
        public Func<Type, Object> ResolveFunc { private get; set; }

        /// <summary>
        /// 注册对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Register<T>()
        {
            var t = typeof(T);
            return (T)RegisterFunc(t);
        }
        public Func<Type, Object> RegisterFunc { private get; set; }


        /// <summary>
        /// 注册动态webapi控制器代理类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T RegisterDynamicApiProxy<T>()
        {
            var t = typeof(T);
            return (T)RegisterDynamicApiProxyFunc(t);
        }
        public Func<Type, Object> RegisterDynamicApiProxyFunc { private get; set; }
    }
}