using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApi.Application.Models
{
    public class AuthorArticleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
