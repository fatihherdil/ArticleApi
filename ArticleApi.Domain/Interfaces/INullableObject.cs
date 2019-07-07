using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApi.Domain.Interfaces
{
    public interface INullableObject<T> where T: class, new()
    {
        T GetNullInstance();
    }
}
