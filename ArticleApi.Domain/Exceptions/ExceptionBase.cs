using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace ArticleApi.Domain.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        public abstract HttpStatusCode StatusCode { get; }

        protected ExceptionBase()
        {
            
        }

        protected ExceptionBase(SerializationInfo serializationInfo, StreamingContext streamingContext):base(serializationInfo, streamingContext)
        {
            
        }

        protected ExceptionBase(string message):base(message)
        {
            
        }

        protected ExceptionBase(string message, Exception innerException):base(message, innerException)
        {
            
        }
    }
}
