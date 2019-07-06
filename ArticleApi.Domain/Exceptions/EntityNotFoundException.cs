using ArticleApi.Domain.Entities;
using System;

namespace ArticleApi.Domain.Exceptions
{
    public class EntityNotFoundException<T> : Exception where T : class, IEntity
    {

        public EntityNotFoundException() :
            base($"{typeof(T)} Entity Not Found !")
        {

        }
    }
}
