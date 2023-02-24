using log4net;
using System;

namespace UI.Utils {

    internal class Logger {

        private readonly ILog log;
        private Logger(Type type) {
            log= LogManager.GetLogger(type);
            Console.WriteLine("jjjjjjj");
        }

    }

}
