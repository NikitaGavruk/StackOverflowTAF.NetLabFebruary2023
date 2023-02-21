using System;

namespace Core.Exceptions {

    public class LoggerException : Exception {

        public LoggerException(string message) : base(message) { }

    }

}