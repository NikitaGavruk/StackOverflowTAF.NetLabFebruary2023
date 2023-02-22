using System;

namespace API.Exceptions {

    public class CreateRequestException : Exception {
        public CreateRequestException() : base() { }
        public CreateRequestException(string message) : base(message) { }
    }

}
