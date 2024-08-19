﻿namespace WebApplication2.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() { }

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }

        public NotFoundException(string name, object key): base($"Not Found enity \"{name}\" ({key}).") { }
    }
}
