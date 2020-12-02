using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using personal_manage.Common.dto;

namespace personal_manage.Common.util
{
    public class CacheHelper
    {

        /// <summary>  
        /// 获取数据缓存  
        /// </summary>  
        /// <param name="cacheKey">键</param>  
        public static object GetCache(string cacheKey)
        {
            var objCache = HttpRuntime.Cache.Get(cacheKey);
            return objCache;
        }
        /// <summary>  
        /// 设置数据缓存  
        /// </summary>  
        public static void SetCache(string key, object value)
        {
            var objCache = HttpRuntime.Cache;
            objCache.Insert(key, value);
        }


        /// <summary>
        /// 添加缓存
        /// </summary>
        public static void SetCache(string key, object value,int expiryTime)
        {
            HttpRuntime.Cache.Insert(key, value, null, DateTime.Now.AddSeconds(expiryTime), TimeSpan.Zero, CacheItemPriority.High, null);

        }

        /// <summary>  
        /// 移除指定数据缓存  
        /// </summary>  
        public static void RemoveAllCache(string cacheKey)
        {
            var cache = HttpRuntime.Cache;
            cache.Remove(cacheKey);
        }


        /// <summary>  
        /// 移除全部缓存  
        /// </summary>  
        public static void RemoveAllCache()
        {
            var cache = HttpRuntime.Cache;
            var cacheEnum = cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                cache.Remove(cacheEnum.Key.ToString());
            }
        }
    }
}
