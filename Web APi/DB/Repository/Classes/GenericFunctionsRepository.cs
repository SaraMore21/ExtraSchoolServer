using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DB.Repository.Classes
{
    [Serializable]
    public static class GenericFunctionsRepository
    {
        public static T Clone<T>(this T obj)
        {
            return (T)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(obj));
        }
        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }



    }
}
