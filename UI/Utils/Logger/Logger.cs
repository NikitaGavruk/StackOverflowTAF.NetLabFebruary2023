using log4net;
using System;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace UI.Utils.Logger {

    public class Logger {

        private readonly ILog log;

        public Logger(Type type) {
            log= LogManager.GetLogger(type);
        }

        public void Debug(string methodName) {
            log.Debug(methodName);
        }

        public void Info(string message) {
            log.Info(message);
        }

        public void Error(string message, string exe) {
            log.Error(message+" outcome:"+exe);
        }

    }

}