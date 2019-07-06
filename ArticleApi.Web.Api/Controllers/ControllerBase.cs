using ArticleApi.Application.Repository;
using ArticleApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ArticleApi.Web.Api.Controllers
{
    [ApiController]
    public class ControllerBase<TEntity> : Controller where TEntity : EntityBase<TEntity>, new()
    {
        protected readonly RepositoryBase<TEntity> Repository;

        public ControllerBase(RepositoryBase<TEntity> entityRepository)
        {
            Repository = entityRepository;
        }

        protected TEntity GetEntityNullInstance()
        {
            return new TEntity().GetNullInstance();
        }
    }
}
