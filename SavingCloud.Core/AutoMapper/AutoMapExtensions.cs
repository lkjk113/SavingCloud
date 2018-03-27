using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SavingCloud
{
    public static class AutoMapExtensions
    {
        static List<Type> types = new List<Type>();

        /// <summary>
        /// 标记为需要map
        /// </summary>
        /// <param name="assembly"></param>
        public static void NeedAutoMap(this Assembly assembly)
        {
            types.AddRange(assembly.GetTypes().Where(type =>
            {
                var typeInfo = type.GetTypeInfo();
                return typeInfo.IsDefined(typeof(AutoMapAttribute)) ||
                       typeInfo.IsDefined(typeof(AutoMapFromAttribute)) ||
                       typeInfo.IsDefined(typeof(AutoMapToAttribute));
            }));
        }

        /// <summary>
        /// 根据特性创建mapping
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="type"></param>
        internal static void CreateAutoAttributeMaps(this IMapperConfigurationExpression configuration, Type type)
        {
            foreach (var autoMapAttribute in type.GetTypeInfo().GetCustomAttributes<AutoMapAttributeBase>())
            {
                autoMapAttribute.CreateMap(configuration, type);
            }
        }

        /// <summary>
        /// 创建程序集的Automapper
        /// </summary>
        /// <param name="assembly"></param>
        public static void CreateMapping()
        {
            Action<IMapperConfigurationExpression> configurer = configuration =>
            {
                foreach (var type in types)
                {
                    configuration.CreateAutoAttributeMaps(type);
                }
            };

            Mapper.Initialize(configurer);
            types = null;
        }



        /// <summary>
        /// 创建目标实例并且map
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDestination MapTo<TDestination>(this object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// map到已存在的实例
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }
    }
}