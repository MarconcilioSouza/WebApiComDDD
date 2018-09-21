using ConectCar.Framework.Infrastructure.Log;
using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectCar.Framework.Infrastructure.Ioc.Log
{
    /// <summary>
    /// Contaneir para resolver Logger
    /// </summary>
    public static class IocLoggerContainer
    {
        public static ILogger ResolveLogger(this Container container)
        {
            var logTool = container.Resolve<ILogger>();

            return logTool;
        }

        public static void RegisterLogger(this Container container)
        {
            container.Register<ILogger, LogTool>();
        }
    }
}
