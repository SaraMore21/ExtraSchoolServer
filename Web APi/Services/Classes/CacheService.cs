using Microsoft.AspNetCore.Http;
using Ninject.Activation.Caching;
using Microsoft.Extensions.Caching.Memory;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Classes;
//using System.Web.Caching;‏

namespace Services.Classes
{

    public class CacheService : ICacheService
    {
        public readonly ISchoolService _ISchoolService;
        public /*static*/ List<ListCodeTable> CodeTableList;


        public CacheService(ISchoolService ISchoolService)
        {
            _ISchoolService = ISchoolService;
        }
        public void select()
        {
           CodeTableList = _ISchoolService.GetAllTable();
        }

        //public static CacheService()
        //{

        //}


        //public void save()
        //{
        //    HttpContext.Current.Cache.Add("mykey", 123456, null, Cache.NoAbsoluteExpiration,
        //        TimeSpan.FromMinutes(60), CacheItemPriority.Normal, null);
        //}

        //public void select()
        //{
        //    string userId = "123456"; // from parameter
        //    int? mykey = HttpContext.Current.Cache["mykey_" + userId] as int?;
        //    if (mykey == null)
        //    {
        //        //go to database

        //        //add to cache
        //        HttpContext.Current.Cache["mykey"] = 123;
        //    }
        //}

        //public void remove()
        //{
        //    //on update ( removekey from cache )
        //    HttpContext.Current.Cache.Remove("mykey");‏
        //}

    }
}
