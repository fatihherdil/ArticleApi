namespace ArticleApi.Domain.Entities
{
    public abstract class EntityBase<T> : IEntity
    {
        public abstract int Id { get; set; }

        public abstract T GetNullInstance();
    }
}
