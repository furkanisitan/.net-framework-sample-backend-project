﻿using PostSharp.Aspects;
using PostSharp.Serialization;
using Shop.Core.CrossCuttingConcerns.Caching;
using System;
using System.Linq;
using System.Reflection;

namespace Shop.Business.Aspects.Postsharp.CacheAspects
{
    /// <summary>
    /// If there is cache item in the cache for the related method, it returns it;
    /// otherwise it adds the return value of the method to the cache.
    /// </summary>
    [PSerializable]
    public sealed class CacheAttribute : MethodInterceptionAspect
    {
        private Type _cacheManagerType;
        private int _cacheDuration;
        private ICacheManager _cacheManager;

        /// <param name="cacheManagerType">Type of cache manager class.</param>
        /// <param name="duration">Cache durations in minutes.</param>
        public CacheAttribute(Type cacheManagerType, int duration = 60)
        {
            _cacheManagerType = cacheManagerType;
            _cacheDuration = duration;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (!typeof(ICacheManager).IsAssignableFrom(_cacheManagerType))
                throw new Exception("Wrong Cache Manager");

            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheManagerType);
            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = $"{args.Method.ReflectedType?.Namespace}.{args.Method.ReflectedType?.Name}.{args.Method.Name}";
            var arguments = args.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

            if (_cacheManager.Contains(key)) args.ReturnValue = _cacheManager.Get<object>(key);
            else
            {
                base.OnInvoke(args);
                _cacheManager.Add(key, args.ReturnValue, _cacheDuration);
            }
        }
    }
}
