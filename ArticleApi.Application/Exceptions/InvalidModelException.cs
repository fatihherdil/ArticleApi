using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ArticleApi.Domain.Exceptions;

namespace ArticleApi.Application.Exceptions
{
    public class InvalidModelException : ExceptionBase
    {
        public InvalidModelException():base("Submitted Model Is Not Valid !")
        {
            
        }

        public InvalidModelException(string message):base(message)
        {

        }

        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}
