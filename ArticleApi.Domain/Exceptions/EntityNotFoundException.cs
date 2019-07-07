using ArticleApi.Domain.Entities;
using System;
using System.Net;
using ArticleApi.Domain.Interfaces;

namespace ArticleApi.Domain.Exceptions
{
    public class EntityNotFoundException<T> : EntityNotFoundException where T : class, IEntity
    {

        public EntityNotFoundException() :
            base($"{typeof(T)} Entity Not Found !")
        {

        }
    }

    public class EntityNotFoundException : ExceptionBase
    {
        public object Entity { get; private set; }

        public EntityNotFoundException(object entity) : base($"{entity.GetType().Name} Entity Not Found !")
        {
            Entity = entity;
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    }
}
