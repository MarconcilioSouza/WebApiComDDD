using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectCar.Framework.Infrastructure.Json
{
    public interface ISerializerJson
    {
        string Serialize<T>(T entity);
        T Deserialize<T>(string json);
    }
}
