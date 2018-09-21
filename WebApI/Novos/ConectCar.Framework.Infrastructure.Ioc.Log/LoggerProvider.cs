using ConectCar.Framework.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectCar.Framework.Infrastructure.Ioc.Log
{
    public class LoggerProvider
    {
        private static ILogger logger;

        public static ILogger GetLogger()
        {
            if (logger == null)
                logger = IocContainer.Container.ResolveLogger();

            return logger;
        }
    }
}
