using System;

namespace UI.Exceptions {

    internal class LoggerException:Exception {

        public LoggerException(string message) : base(message) { }

    }

}