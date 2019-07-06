using ArticleApi.Domain.Entities;

namespace ArticleApi.Application.Interfaces
{
    public interface IDto<TEntity> where TEntity : EntityBase<TEntity>, new()
    {
        TEntity ConvertToBo();
    }
}
